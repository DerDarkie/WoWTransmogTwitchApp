using System;
using TwitchLib.Client;
using TwitchLib.Client.Models;
using TwitchLib.Client.Events;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;
using WoWTransmogTwitchApp.Forms;

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

        private string _Arg1;
        private int _Arg2;

        public bool Missing_Arg1 { get; private set; }
        public int Summe { get; private set; }
        public int Summe2 { get; private set; }

        public int _Char { get; private set; }
        private delegate void SafeCallDelegate(string text);
        public ConnectionCredentials creds = new ConnectionCredentials(Settings.Default.botname, Settings.Default.oauthtoken);
        public bool _isConnected;
        private int anzahl;
        private int _startvote;
        public int vote1;
        public int vote2;
        public int vote3;
        public int vote4;
        public int vote5;
        public int vote6;
        public int vote7;
        public int vote8;
        public int vote9;
        public int vote10;
        public int charid;
        private int joined;

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

            CheckEventStatus();

            if (anzahl == 1)
            {
                if (e.ChatMessage.Message.Contains("!joinevent"))
                {

                    string[] subs = e.ChatMessage.Message.Split(null, 2);
                    var totalElements = subs.Count();
                    if (totalElements == 2)
                    {
                        _Arg1 = subs[1];
                        Missing_Arg1 = false;
                    }
                    else
                    {
                        Missing_Arg1 = true;
                    }
                    if (Missing_Arg1)
                    {
                        string msg = _displayname + ", Du musst nach dem Command Deinen Charaktername eingeben (mit Leerzeichen trennen)";
                        SendMsg(msg);
                        return;
                    }
                    else
                    {
                        string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                        SqlConnection connection = new SqlConnection(cn_string);
                        string query = @"SELECT * FROM Teilnehmer WHERE Username = '" + _displayname + "'";
                        SqlDataAdapter da = new SqlDataAdapter(query, connection);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            string msg = _displayname + ", Dein Charakter: " + _Arg1 + " wurde bereits eingetragen.";
                            SendMsg(msg);
                        }
                        else
                        {
                            _startvote = 0;
                            string sql_Text2 = @"INSERT INTO Teilnehmer (charname, Username, wertung, anzahl) VALUES ('" + _Arg1.Replace("'", "''") + "', '" + _displayname + "', '" + _startvote + "', '" + _startvote + "')";
                            Db_execute(sql_Text2);
                            string msg = _displayname + ", Dein Charakter: " + _Arg1 + " wurde eingetragen.";
                            SendMsg(msg);
                        }
                    }
                }
            }
            else if (anzahl == 3)
            {
                if (e.ChatMessage.Message.Contains("!vote"))
                {

                    string[] subs = e.ChatMessage.Message.Split(null, 3);
                    var totalElements = subs.Count();
                    if (totalElements == 3)
                    {
                        _Arg1 = subs[1];
                        // _Arg2 = Int32.Parse(subs[2]);
                        if (subs[2].Contains(","))
                        {
                            string msg = _displayname + ", Du kannst nur ganze Zahlen eingeben, um eine Wertung abzugeben";
                            SendMsg(msg);
                            return;
                        }
                        else
                        {
                            _Arg2 = Int32.Parse(subs[2]);
                            if (_Arg2 >= 1 && _Arg2 <= 10)
                            {
                                _Arg2 = Int32.Parse(subs[2]);
                            }
                            else
                            {
                                string msg = _displayname + ", Du kannst nur ganze Zahlen von 1 bis 10 eingeben, um eine Wertung abzugeben";
                                SendMsg(msg);
                                return;
                            }
                        }
                        Missing_Arg1 = false;
                        
                    }
                    else
                    {
                        Missing_Arg1 = true;
                    }
                    if (Missing_Arg1)
                    {
                        string msg = _displayname + ", Du musst !vote Charname wertung (Beispiel: !vote Hobbit 6) eingeben, um eine Wertung abzugeben";
                        SendMsg(msg);
                        return;
                    }
                    else
                    {
                        string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                        string sql_Text = @"SELECT vote1, vote2, vote3, vote4, vote5, vote6, vote7, vote8, vote9, vote10, Id  FROM Teilnehmer WHERE charname = '" + _Arg1 + "' ";
                        SqlConnection cn = new SqlConnection(cn_string);
                        SqlCommand cmd = new SqlCommand(sql_Text, cn);
                        cmd.Connection.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                vote1 = Convert.ToInt32(dr[0]);
                                vote2 = Convert.ToInt32(dr[1]);
                                vote3 = Convert.ToInt32(dr[2]);
                                vote4 = Convert.ToInt32(dr[3]);
                                vote5 = Convert.ToInt32(dr[4]);
                                vote6 = Convert.ToInt32(dr[5]);
                                vote7 = Convert.ToInt32(dr[6]);
                                vote8 = Convert.ToInt32(dr[7]);
                                vote9 = Convert.ToInt32(dr[8]);
                                vote10 = Convert.ToInt32(dr[9]);

                                charid = Convert.ToInt32(dr[10]);
                            }
                            dr.Close();
                        }
                        cmd.Connection.Close();
                        switch (_Arg2)
                        {
                            case 1:
                                string sql_text1 = @"UPDATE Teilnehmer SET vote1 = vote1 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text1);
                                break;
                            case 2:
                                string sql_text2 = @"UPDATE Teilnehmer SET vote2 = vote2 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text2);
                                break;
                            case 3:
                                string sql_text3 = @"UPDATE Teilnehmer SET vote3 = vote3 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text3);
                                break;
                            case 4:
                                string sql_text4 = @"UPDATE Teilnehmer SET vote4 = vote4 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text4);
                                break;
                            case 5:
                                string sql_text5 = @"UPDATE Teilnehmer SET vote5 = vote5 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text5);
                                break;
                            case 6:
                                string sql_text6 = @"UPDATE Teilnehmer SET vote6 = vote6 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text6);
                                break;
                            case 7:
                                string sql_text7 = @"UPDATE Teilnehmer SET vote7 = vote7 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text7);
                                break;
                            case 8:
                                string sql_text8 = @"UPDATE Teilnehmer SET vote8 = vote8 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text8);
                                break;
                            case 9:
                                string sql_text9 = @"UPDATE Teilnehmer SET vote9 = vote9 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text9);
                                break;
                            case 10:
                                string sql_text10 = @"UPDATE Teilnehmer SET vote10 = vote10 +1 WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                                Db_execute(sql_text10);
                                break;
                        }

                        double Summe = (1 * vote1) + (2 * vote2) + (3 * vote3) + (4 * vote4) + (5 * vote5) + (6 * vote6) + (7 * vote7) + (8 * vote8) + (9 * vote9) + (10 * vote10) + _Arg2;
                        double Summe2 = vote1 + vote2 + vote3 + vote4 + vote5 + vote6 + vote7 + vote8 + vote9 + vote10 + 1;
                        double _new_wertung = Summe / Summe2;
                        string s = _new_wertung.ToString(".00");

                        string sql_text_check = @"SELECT VotedId FROM VotedIds WHERE UserId = '" + _userName + "'";
                        SqlCommand cmd4 = new SqlCommand(sql_text_check, cn);
                        cmd4.Connection.Open();
                        SqlDataReader dr4 = cmd4.ExecuteReader();
                        if (dr4.HasRows)
                        {
                            while (dr4.Read())
                            {
                                _Char = ((int)dr4["VotedId"]);
                            }
                            dr4.Close();
                            cmd4.Connection.Close();
                        }
                        if (_Char == charid)
                        {
                            string msg = _displayname + ", Du hast diesen Charakter bereits bewertet!";
                            SendMsg(msg);
                        }
                        else if ( charid < 1)
                        {
                            string msg = _displayname + ", Dieser Charaktername ist nicht angemeldet !";
                            SendMsg(msg);
                        }
                        else
                        {
                            SqlConnection cn2 = new SqlConnection(cn_string);
                            string sql_Text2 = @"UPDATE Teilnehmer SET wertung = @wertung, anzahl = '" + Summe2 + "' WHERE charname = '" + _Arg1 + "' AND signed = '1'";
                            SqlCommand cmd5 = new SqlCommand(sql_Text2, cn2);
                            cmd5.Parameters.Add("@wertung", SqlDbType.Decimal).Value = Convert.ToDecimal(s, CultureInfo.CurrentCulture);
                            cmd5.Connection.Open();
                            cmd5.ExecuteNonQuery();
                            cmd5.Connection.Close();

                            string sql_insert = @"INSERT INTO VotedIds (UserId, VotedId) VALUES ('" + _userName + "', '" + charid + "')";
                            Db_execute(sql_insert);
                            string msg = _displayname + ", Du hast den Charakter: " + _Arg1 + " mit " + _Arg2 + " bewertet. Die Gesamtwertung für " + _Arg1 + ": ist jetzt: " + s;
                            SendMsg(msg);

                        }
                    }
                }
            }
        }
        
        private int Db_execute(string sql_Text)
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            SqlConnection cn = new SqlConnection(cn_string);

            SqlCommand cmd = new SqlCommand(sql_Text, cn);
            cmd.Connection.Open();
            int nResult = cmd.ExecuteNonQuery();

            return nResult;
        }

        public void CheckEventStatus()
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            string sql_Text = @"SELECT status FROM event ";
            SqlConnection cn = new SqlConnection(cn_string);
            SqlCommand cmd = new SqlCommand(sql_Text, cn);
            cmd.Connection.Open();
            SqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                dr.Read();
                anzahl = dr.GetInt32(0);
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            if (msg != null)
            {
                client.SendMessage(Settings.Default.channel, msg);
                ChatText?.Invoke($"{DateTime.Now} -  {msg}");
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