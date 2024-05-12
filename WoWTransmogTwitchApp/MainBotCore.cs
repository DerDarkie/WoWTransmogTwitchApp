using System;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;
using TwitchLib.Api;
using TwitchLib.Api.Core;
using TwitchLib.Api.Events;
using TwitchLib.Api.Helix;
using TwitchLib.Api.Helix.Models;
using TwitchLib.Api.Helpers;
using TwitchLib.Api.Interfaces;
using TwitchLib.Api.Services;
using TwitchLib.Api.Services.Events;
using TwitchLib.Api.ThirdParty.ModLookup;
using TwitchLib.Api.V5.Models;
using TwitchLib.Api.V5.Models.Users;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Enums.Internal;
using TwitchLib.Communication.Events;
using TwitchLib.Communication.Clients;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WoWTransmogTwitchApp.Classes;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using WoWTransmogTwitchApp.Forms;
using System.Linq;

namespace WoWTransmogTwitchApp
{
    class BotMainCore
    {
        public string pongmsg = "PONG :tmi.twitch.tv";
        public Action<bool> Connected;
        public Action<string> LogTxt;
        public Action<string> ChatText;
        public Action<string> ViewerText;
        public Action<string> ViewerText2;
        public string _userName;
        public string _displayname;
        public string _username;
        public string _cmdtxt;
        public static TwitchClient client;
        public string ChatTextListBox { get; set; }
        public string ViewerTextListBox { get; set; }
        private delegate void SafeCallDelegate(string text);
        public ConnectionCredentials creds = new ConnectionCredentials(Settings.Default.botname, Settings.Default.oauthtoken);
        private bool _isConnected;

        public void Connect(bool isLogging)
        {
            client = new TwitchClient();
            client.Initialize(creds, Settings.Default.channel);
            client.OnConnectionError += Client_OnConnectionError;
            client.OnConnected += Client_OnConnected;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnUserJoined += Client_OnUserJoind;
            client.OnUserLeft += Client_OnUserLeft;

            if (isLogging)
            {
                client.OnLog += Client_OnLog;
            }
            client.Connect();
            client.SendRaw("CAP REQ :twitch.tv/membership");
            client.SendRaw("CAP REQ :twitch.tv/tags");
            client.SendRaw("CAP REQ :twitch.tv/commands");

        }
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.Contains("PING :tmi.twitch.tv"))
            {
                SendPong(pongmsg);
            }
            ChatText?.Invoke($"{DateTime.Now} - {e.ChatMessage.DisplayName}: {e.ChatMessage.Message}");
            _displayname = e.ChatMessage.DisplayName.ToString();
            _userName = e.ChatMessage.Username;
        }
        
        private void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            _cmdtxt = e.Command.CommandText.ToString();
            _username = e.Command.ChatMessage.Username.ToString();
        }
        private void Client_OnUserJoind(object sender, OnUserJoinedArgs e)
        {
            _userName = e.Username;

            ViewerText?.Invoke($"{_userName}");

            //User checken
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            SqlConnection connection = new SqlConnection(cn_string);
            string query = @"SELECT Username FROM viewer WHERE username = '" + _userName + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                connection.Open();
                string update_query = @"UPDATE viewer SET LastOnline = '" + DateTime.Now + "' WHERE username = '" + _userName + "';";
                SqlCommand cmd = new SqlCommand(update_query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                connection.Open();
                string insert_query = @"INSERT INTO viewer (username, LastOnline) VALUES ('" + _userName + "', '" + DateTime.Now + "');";
                SqlCommand cmd = new SqlCommand(insert_query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        private void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            ViewerText2?.Invoke($"{ e.Username}");
        }
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Connected?.Invoke(true);
            _isConnected = true;
        }
        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            string message = "Es konnte keine Verbindung aufgebaut werden. Überprüfe deinen Internetverbindung";
            string caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
            return;
        }
        internal void Disconnect()
        {
            Connected?.Invoke(false);
            client.Disconnect();
            _isConnected = false;
        }
        public void SendMsg(string msg)
        {
            if (_isConnected)
            {
                if (msg != null)
                {
                    client.SendMessage(Settings.Default.channel, msg);
                    ChatText?.Invoke($"{DateTime.Now} -  {msg}");
                }
            }
            else
            {
                string message = "Bot ist nicht Online !.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
        }
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            LogTxt?.Invoke(e.Data);
        }
        public void SendPong(string pongmsg)
        {
            client.SendRaw(pongmsg);
        }

    }
}