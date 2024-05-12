using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace WoWTransmogTwitchApp.Forms
{
    public partial class FormCompetitors : Form
    {
        public int Zeile;
        public DataTable t1 = new DataTable();
        private string _Name;
        private int _newstatus;
        public FormCompetitors()
        {
            InitializeComponent();
            GetJoinsList();

        }
        private void FormCompetitors_Load(object sender, EventArgs e)
        {
            t1.Columns.Add("Id").MaxLength = 2;
            t1.Columns.Add("charname").MaxLength = 45;
            t1.Columns.Add("wertung").MaxLength = 25;
            t1.Columns.Add("anzahl").MaxLength = 3;
            t1.Columns.Add("Username").MaxLength = 25;
            t1.Columns.Add("signed").MaxLength = 3;
            CompGridView.ColumnHeadersVisible = false;
            CompGridView.RowHeadersVisible = false;
            Liste_laden();
            if (GetAmountOfTeilnehmer() >= 20)
            {
                BtnSignComp.Enabled = false;
            }
            else
            {
                BtnSignComp.Enabled = true;
            }
            
        }
        private void Liste_laden()
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            SqlConnection cn = new SqlConnection(cn_string);
            string sql_Text = @"SELECT * FROM Teilnehmer WHERE signed = 1";
            SqlDataAdapter sql_adapt = new SqlDataAdapter(sql_Text, cn);
            DataTable dtUser = new DataTable();
            sql_adapt.Fill(dtUser);
            CompGridView.DataSource = dtUser;
        }
        public void GetJoinsList()
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            string sql_Text = @"SELECT charname FROM Teilnehmer WHERE signed = 0 ";
            SqlConnection cn = new SqlConnection(cn_string);
            SqlDataAdapter da = new SqlDataAdapter(sql_Text, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ComboJoins.DataSource = dt;
            ComboJoins.DisplayMember = "charname";
            ComboJoins.ValueMember = "charname";
            TxtSignedTotal.Text = GetAmountOfTeilnehmer().ToString();
        }
        private void BtnSignComp_Click(object sender, EventArgs e)
        {
            _Name = ComboJoins.SelectedValue.ToString();
            _newstatus = 1;
            string sql_Text = "UPDATE Teilnehmer SET signed = '" + _newstatus + "' WHERE charname = '" + _Name + "';";
            Db_execute(sql_Text);
            GetJoinsList();
            Liste_laden();
        }
        private void CompGridView_SelectionChanged(object sender, EventArgs e)
        {
            CompGridView = sender as DataGridView;
            try
            {
                Zeile = CompGridView.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten: " + ex.Message + " - " + ex.Source);
            }
            TxtCompID.Text = CompGridView.Rows[Zeile].Cells[0].Value.ToString();
            TxtCharname.Text = CompGridView.Rows[Zeile].Cells[1].Value.ToString();
            
            TxtAnzahl.Text = CompGridView.Rows[Zeile].Cells[3].Value.ToString();
            TxtUsername.Text = CompGridView.Rows[Zeile].Cells[4].Value.ToString();
            switch((int)CompGridView.Rows[Zeile].Cells[5].Value)
            {
                case 0:
                    TxtStatus.Text = "angemeldet - nicht bestätigt";
                    TxtStatus.BackColor = Color.Red;
                    break;
                case 1:
                    TxtStatus.Text = "ANGEMELDET - BESTÄTIGT";
                    TxtStatus.BackColor = Color.Green;
                    break;
            }

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
        private void RefreshUser()
        {
            string RefreshId = TxtCompID.Text;
            string new_Name = TxtCharname.Text;
            string new_wertung = TxtStatus.Text;
            int new_anzahl = Convert.ToInt32(this.TxtAnzahl.Text);
            string sql_Text = "UPDATE Teilnehmer SET charname = '" + new_Name + "', signed = '" + new_wertung + "', anzahl = '" + new_anzahl +"' WHERE Id = '" + RefreshId + "';";
            Db_execute(sql_Text);
            Liste_laden();
        }
        private void DelUser()
        {
            string DelItemId = TxtCompID.Text;
            string sql_Text = "DELETE FROM Teilnehmer WHERE Id = " + DelItemId;
            Db_execute(sql_Text);
            Liste_laden();
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
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Willst du den ausgewählten User wirklich löschen?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    DelUser();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
