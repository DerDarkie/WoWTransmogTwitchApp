using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WoWTransmogTwitchApp.Classes;

namespace WoWTransmogTwitchApp.Forms
{
    public partial class FormUser : Form
    {
        public int Zeile;
        public DataTable t1 = new DataTable();
        public DataTable t2 = new DataTable();
        public FormUser()
        {
            InitializeComponent();
        }
        private void FormUser_Load(object sender, EventArgs e)
        {
            t1.Columns.Add("Id").MaxLength = 2;
            t1.Columns.Add("username").MaxLength = 45;
            t1.Columns.Add("LastOnline").MaxLength = 25;
            UserGridView.ColumnHeadersVisible = false;
            UserGridView.RowHeadersVisible = false;

            Liste_laden();
        }
        private void Liste_laden()
        {
            string cn_string = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            SqlConnection cn = new SqlConnection(cn_string);
            string sql_Text = @"SELECT * FROM viewer";
            SqlDataAdapter sql_adapt = new SqlDataAdapter(sql_Text, cn);
            DataTable dtUser = new DataTable();
            sql_adapt.Fill(dtUser);
            UserGridView.DataSource = dtUser;
        }
        private void UserGridView_SelectionChanged(object sender, EventArgs e)
        {
            UserGridView = sender as DataGridView;
            try
            {
                Zeile = UserGridView.CurrentCell.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten: " + ex.Message + " - " + ex.Source);
            }
            TxtUserId.Text = UserGridView.Rows[Zeile].Cells[0].Value.ToString();
            TxtUsername.Text = UserGridView.Rows[Zeile].Cells[1].Value.ToString();
            TxtLastOnline.Text = UserGridView.Rows[Zeile].Cells[2].Value.ToString();
            
        }
        private void BtnUserRefresh_Click(object sender, EventArgs e)
        {
            RefreshUser();
        }
        private void RefreshUser()
        {
            string RefreshId = TxtUserId.Text;
            string new_Name = TxtUsername.Text;
            
            string sql_Text = "UPDATE viewer SET username = '" + new_Name + "' WHERE Id = '" + RefreshId + "';";
            Db_execute(sql_Text);
            Liste_laden();
        }
        private void BtnUserDelete_Click(object sender, EventArgs e)
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
        private void DelUser()
        {
            string DelItemId = TxtUserId.Text;
            string sql_Text = "DELETE FROM viewer WHERE Id = " + DelItemId;
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
    }
}
