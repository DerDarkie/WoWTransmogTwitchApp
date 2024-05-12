using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WoWTransmogTwitchApp.Forms
{
    public partial class FormCompetition : Form
    {
        private delegate void SafeCallDelegate(string text);
        public bool _isConnected;
        public FormCompetition()
        {
            InitializeComponent();
        }
        private BotMainCore _maincore;
        private bool _isCon;
        public int status;
        

        private void FormCompetition_Load(object sender, EventArgs e)
        {
            _isCon = FormBotManager._isConnected;
            if (!_isCon)
            {
                _maincore = new BotMainCore();
                TxtBotStatus.ForeColor = Color.Black;
                TxtBotStatus.BackColor = Color.Red;
                SetOnlineStatustext("Offline");
                _isConnected = false;
            }
            else
            {
                _maincore = new BotMainCore();
                TxtBotStatus.ForeColor = Color.Black;
                TxtBotStatus.BackColor = Color.Green;
                SetOnlineStatustext("Online");
                _isConnected = true;
            }
            TxtCompwtitors.Text = GetAmountOfComp().ToString();
            TxtTotalVotes.Text = GetAmountOfVotes().ToString();
            TxtTeilnehmer.Text = GetAmountOfTeilnehmer().ToString();
            LblWin1.Visible = false;
            LblWin2.Visible = false;
            LblWin3.Visible = false;
            //ResetWertungen();
            CheckStatus();
            if (status == 0)//inactive
            {
                BtnStartJoins.Enabled = true;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Firebrick;
                TxtEventStatus.Text = "Event inaktiv";
            }
            else if (status == 1)//startet join
            {
                BtnStartJoins.Enabled = false;
                BtnStopJoins.Enabled = true;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Green;
                TxtEventStatus.Text = "Event gestartet";
            }
            else if( status == 2)//stopped join
            {
                BtnStartJoins.Enabled = true;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = true;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Yellow;
                TxtEventStatus.Text = "Abmelden beendet";
            }
            else if (status == 3)//started vote
            {
                BtnStartJoins.Enabled = false;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = true;
                BtnStopVote.Enabled = true;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Aquamarine;
                TxtEventStatus.Text = "Bewertung gestartet";
            }
            else if (status == 4)//paused vote
            {
                BtnStartJoins.Enabled = true;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = true;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = true;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Yellow;
                TxtEventStatus.Text = "Bewertung pausiert";
            }
            else if (status == 5)//ended vote
            {
                BtnStartJoins.Enabled = false;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = true;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.BlueViolet;
                TxtEventStatus.Text = "Bewertung beendet";
            }
            else if (status == 6)//resuts
            {
                BtnStartJoins.Enabled = false;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.BlueViolet;
                LblWin1.Visible = true;
                LblWin1.Text = "1. Platz - GEWINNER";
                LblWin2.Visible = true;
                LblWin2.Text = "2. Platz";
                LblWin3.Visible = true;
                LblWin3.Text = "3. PLatz";
                TxtEventStatus.Text = "Ergebnis";
            }
            LoadCompBars();
        }
        private void LoadCompBars()
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            string sql_Text = @"SELECT charname, wertung FROM Teilnehmer WHERE signed = '1' ORDER BY wertung DESC";
            SqlConnection cn = new SqlConnection(cn_string);
            SqlCommand cmd = new SqlCommand(sql_Text, cn);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                int count = 1;
                while (dr.Read())
                {
                        string Cname = dr[0].ToString();
                        int wertung = Convert.ToInt32(dr[1]);
                        decimal _wertung = Convert.ToDecimal(dr[1]);
                        if (this.Controls.Find("LblComp" + count.ToString(), true).FirstOrDefault() is Label lbl)
                        {
                            if (Cname != null)
                            {
                                lbl.Text = Cname;
                            }
                            else
                            {
                                lbl.Text = "N/A";
                            }
                        }
                        if (this.Controls.Find("ProgressBar" + count.ToString(), true).FirstOrDefault() is ProgressBar pgb)
                        {
                            if (wertung > 0)
                            {
                                pgb.Value = (wertung * 100) / 10;
                            }
                            else
                            {
                                pgb.Value = 0;
                            }
                        }
                        if (this.Controls.Find("TxtValue" + count.ToString(), true).FirstOrDefault() is TextBox tb)
                        {
                            if (wertung > 0)
                            {
                                tb.Text = _wertung.ToString();
                            }
                            else
                            {
                                tb.Text = "0";
                            }
                        }
                        count++;
                }
            }
        }

        public void CheckStatus()
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
                status = dr.GetInt32(0);
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int GetAmountOfComp()
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            int count = 0;
            string sql_text = @"SELECT COUNT (*) FROM Teilnehmer";

            using (SqlConnection connection = new SqlConnection(cn_string))
            {
                using(SqlCommand cmdCount = new SqlCommand(sql_text, connection))
                {
                    connection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
        public int GetAmountOfTeilnehmer()
        {
            string _active = "1";
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            int count = 0;
            string sql_text = @"SELECT COUNT (*) FROM Teilnehmer WHERE signed = " + _active;

            using (SqlConnection connection = new SqlConnection(cn_string))
            {
                using (SqlCommand cmdCount = new SqlCommand(sql_text, connection))
                {
                    connection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
        public int GetAmountOfVotes()
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            int count = 0;
            string sql_text = @"SELECT COUNT (*) FROM VotedIds";

            using (SqlConnection connection = new SqlConnection(cn_string))
            {
                using (SqlCommand cmdCount = new SqlCommand(sql_text, connection))
                {
                    connection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
        private void SetOnlineStatustext(string text)
        {
            if (TxtBotStatus.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetOnlineStatustext);
                TxtBotStatus.Invoke(d, new object[] { text });
            }
            else
            {
                TxtBotStatus.Text = text;
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
        private void BtnStartJoins_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                string message = "Der Bot ist nicht Online. Bitte verbinde den Bot erst zum Chat.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            else 
            {
                string RefreshId = "1";
                string new_status = "1";
                string sql_Text = "UPDATE event SET status = '" + new_status + "' WHERE Id = '" + RefreshId + "';";
                Db_execute(sql_Text);
                BtnStartJoins.Enabled = false;
                BtnStopJoins.Enabled = true;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Green;
                TxtEventStatus.Text = "Event gestartet";
                string msg_text = "Die Anmeldungen für den Transmog-Wettbewerb wurden gestartet! Um dich für die Teilnahme einzutragen, gib im Chat: !joinevent Charname ein.";
                _maincore.SendMsg(msg_text);
                FormCompetition_Load(null, EventArgs.Empty);
            }
        }
        private void BtnStopJoins_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                string message = "Der Bot ist nicht Online. Bitte verbinde den Bot erst zum Chat.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {
                string RefreshId = "1";
                string new_status = "2";
                string sql_Text = "UPDATE event SET status = '" + new_status + "' WHERE Id = '" + RefreshId + "';";
                Db_execute(sql_Text);
                BtnStartJoins.Enabled = true;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = true;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Yellow;
                TxtEventStatus.Text = "Anmelden beendet";
                string msg_text = "Die Anmeldungen für den Transmog-Wettbewerb wurden gestoppt! Keine weitere Anmeldung möglich.";
                _maincore.SendMsg(msg_text);
                FormCompetition_Load(null, EventArgs.Empty);
            }
        }
        private void BtnStartVote_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                string message = "Der Bot ist nicht Online. Bitte verbinde den Bot erst zum Chat.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {
                string RefreshId = "1";
                string new_status = "3";
                string sql_Text = "UPDATE event SET status = '" + new_status + "' WHERE Id = '" + RefreshId + "';";
                Db_execute(sql_Text);
                BtnStartJoins.Enabled = false;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = true;
                BtnStopVote.Enabled = true;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Aquamarine;
                TxtEventStatus.Text = "Bewertung gestartet";
                string msg_text = "Die Bewertung wurde gestartet. Bewerte die Teilnehmer mit: !vote Charname wertung (Beispiel: !vote Hobbit 6)";
                _maincore.SendMsg(msg_text);
                FormCompetition_Load(null, EventArgs.Empty);
            }
        }

        private void BtnPauseVote_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                string message = "Der Bot ist nicht Online. Bitte verbinde den Bot erst zum Chat.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {
                string RefreshId = "1";
                string new_status = "4";
                string sql_Text = "UPDATE event SET status = '" + new_status + "' WHERE Id = '" + RefreshId + "';";
                Db_execute(sql_Text);
                BtnStartJoins.Enabled = true;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = true;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = true;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.Yellow;
                TxtEventStatus.Text = "Bewertung pausiert";
                string msg_text = "Die Bewertung wurde pausiert. Bitte warte mit deiner Bewertung, bis sie wieder freigegeben werden.";
                _maincore.SendMsg(msg_text);
                FormCompetition_Load(null, EventArgs.Empty);
            }
        }
        private void BtnStopVote_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Willst du die Bewertungen beenden? Danach kann das Event nicht reaktiviert werden !", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (!_isConnected)
                    {
                        string message = "Der Bot ist nicht Online. Bitte verbinde den Bot erst zum Chat.";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, caption, buttons);
                        return;
                    }
                    else
                    {
                        string RefreshId = "1";
                        string new_status = "5";
                        string sql_Text = "UPDATE event SET status = '" + new_status + "' WHERE Id = '" + RefreshId + "';";
                        Db_execute(sql_Text);
                        BtnStartJoins.Enabled = false;
                        BtnStopJoins.Enabled = false;
                        BtnStartVote.Enabled = false;
                        BtnPauseVote.Enabled = false;
                        BtnStopVote.Enabled = false;
                        BtnResults.Enabled = true;
                        BtnCLoseEvent.Enabled = true;
                        TxtEventStatus.ForeColor = Color.Black;
                        TxtEventStatus.BackColor = Color.BlueViolet;
                        TxtEventStatus.Text = "Bewertung beendet";
                        string msg_text = "Die Bewertung wurden beendet. Keine weitere Bewertung möglich. Warte die Bekanntgabe des Ergebnisses ab.";
                        _maincore.SendMsg(msg_text);
                        FormCompetition_Load(null, EventArgs.Empty);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private void BtnResults_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                string message = "Der Bot ist nicht Online. Bitte verbinde den Bot erst zum Chat.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {
                
                string RefreshId = "1";
                string new_status = "6";
                string sql_Text = "UPDATE event SET status = '" + new_status + "' WHERE Id = '" + RefreshId + "';";
                Db_execute(sql_Text);
                BtnStartJoins.Enabled = false;
                BtnStopJoins.Enabled = false;
                BtnStartVote.Enabled = false;
                BtnPauseVote.Enabled = false;
                BtnStopVote.Enabled = false;
                BtnResults.Enabled = false;
                BtnCLoseEvent.Enabled = true;
                TxtEventStatus.ForeColor = Color.Black;
                TxtEventStatus.BackColor = Color.BlueViolet;
                TxtEventStatus.Text = "Ergebnis";
                LblWin1.Visible = true;
                LblWin1.Text = "1. Platz - GEWINNER";
                LblWin2.Visible = true;
                LblWin2.Text = "2. Platz";
                LblWin3.Visible = true;
                LblWin3.Text = "3. PLatz";
                string msg_text = "Die Ergebnisse: 1. Platz: " + LblComp1.Text + ", 2. Platz: " + LblComp2.Text + ", 3. Platz: " + LblComp3.Text + ". Herzlichen Glückwunsch !!!";
                _maincore.SendMsg(msg_text);
                FormCompetition_Load(null, EventArgs.Empty);
            }
        }
        private void BtnCLoseEvent_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Willst Du das Event wirklich schließen? Alle gespeicherten Daten gehen verloren !", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (!_isConnected)
                    {
                        string message = "Der Bot ist nicht Online. Bitte verbinde den Bot erst zum Chat.";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(message, caption, buttons);
                        return;
                    }
                    else
                    {
                        string RefreshId = "1";
                        string new_status = "0";
                        string sql_Text = @"UPDATE event SET status = '" + new_status + "' WHERE Id = '" + RefreshId + "';";
                        Db_execute(sql_Text);
                        string sql_del_comp = @"TRUNCATE TABLE Teilnehmer";
                        Db_execute(sql_del_comp);
                        string sql_del_votes = @"TRUNCATE TABLE VotedIds";
                        Db_execute(sql_del_votes);
                        FormCompetition_Load(null, EventArgs.Empty);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
