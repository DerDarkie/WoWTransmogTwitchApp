using System;
using System.Windows.Forms;

namespace WoWTransmogTwitchApp.Forms
{
    public partial class FormAccountManager : Form
    {
        public FormAccountManager()
        {
            InitializeComponent();
        }
        private void FormAccountManager_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        public void Load_Data()
        {
            string botname = Settings.Default.botname;
            BotName.Text = botname;
            string channel = Settings.Default.channel;
            Channel.Text = channel;
            string oauth = Settings.Default.oauthtoken;
            Oauth.Text = oauth;
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            Settings.Default.botname = BotName.Text;
            Settings.Default.channel = Channel.Text;
            Settings.Default.oauthtoken = Oauth.Text;
            
            Settings.Default.Save();
            Load_Data();
        }
        private void BtnClear_Click(object sender, EventArgs e)
        {
            Settings.Default.botname = "deinbotname";
            Settings.Default.channel = "channeltojoin";
            Settings.Default.oauthtoken = "testtoken";
            Settings.Default.Save();
            Load_Data();
        }
    }
}
