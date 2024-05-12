
namespace WoWTransmogTwitchApp.Forms
{
    partial class FormCompetitors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCompetitors));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CompGridView = new System.Windows.Forms.DataGridView();
            this.TxtCompID = new System.Windows.Forms.TextBox();
            this.TxtCharname = new System.Windows.Forms.TextBox();
            this.TxtStatus = new System.Windows.Forms.TextBox();
            this.TxtAnzahl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblchar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtSignedTotal = new System.Windows.Forms.TextBox();
            this.BtnSignComp = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboJoins = new System.Windows.Forms.ComboBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.CompGridView);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(849, 573);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teilnehmerliste";
            // 
            // CompGridView
            // 
            this.CompGridView.AllowUserToAddRows = false;
            this.CompGridView.AllowUserToDeleteRows = false;
            this.CompGridView.AllowUserToResizeColumns = false;
            this.CompGridView.AllowUserToResizeRows = false;
            this.CompGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CompGridView.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.CompGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CompGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CompGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CompGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.CompGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.CompGridView.Location = new System.Drawing.Point(3, 25);
            this.CompGridView.MultiSelect = false;
            this.CompGridView.Name = "CompGridView";
            this.CompGridView.ReadOnly = true;
            this.CompGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CompGridView.Size = new System.Drawing.Size(843, 545);
            this.CompGridView.TabIndex = 0;
            this.CompGridView.SelectionChanged += new System.EventHandler(this.CompGridView_SelectionChanged);
            // 
            // TxtCompID
            // 
            this.TxtCompID.BackColor = System.Drawing.Color.MidnightBlue;
            this.TxtCompID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCompID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCompID.ForeColor = System.Drawing.Color.White;
            this.TxtCompID.Location = new System.Drawing.Point(1065, 427);
            this.TxtCompID.Name = "TxtCompID";
            this.TxtCompID.Size = new System.Drawing.Size(327, 26);
            this.TxtCompID.TabIndex = 1;
            // 
            // TxtCharname
            // 
            this.TxtCharname.BackColor = System.Drawing.Color.MidnightBlue;
            this.TxtCharname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCharname.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCharname.ForeColor = System.Drawing.Color.White;
            this.TxtCharname.Location = new System.Drawing.Point(1065, 459);
            this.TxtCharname.Name = "TxtCharname";
            this.TxtCharname.Size = new System.Drawing.Size(327, 26);
            this.TxtCharname.TabIndex = 1;
            // 
            // TxtStatus
            // 
            this.TxtStatus.BackColor = System.Drawing.Color.MidnightBlue;
            this.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStatus.ForeColor = System.Drawing.Color.White;
            this.TxtStatus.Location = new System.Drawing.Point(1065, 491);
            this.TxtStatus.Name = "TxtStatus";
            this.TxtStatus.Size = new System.Drawing.Size(327, 26);
            this.TxtStatus.TabIndex = 1;
            // 
            // TxtAnzahl
            // 
            this.TxtAnzahl.BackColor = System.Drawing.Color.MidnightBlue;
            this.TxtAnzahl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAnzahl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAnzahl.ForeColor = System.Drawing.Color.White;
            this.TxtAnzahl.Location = new System.Drawing.Point(1065, 523);
            this.TxtAnzahl.Name = "TxtAnzahl";
            this.TxtAnzahl.Size = new System.Drawing.Size(327, 26);
            this.TxtAnzahl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(924, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Teilnehmer ID:";
            // 
            // lblchar
            // 
            this.lblchar.AutoSize = true;
            this.lblchar.BackColor = System.Drawing.Color.Transparent;
            this.lblchar.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchar.ForeColor = System.Drawing.Color.White;
            this.lblchar.Location = new System.Drawing.Point(918, 462);
            this.lblchar.Name = "lblchar";
            this.lblchar.Size = new System.Drawing.Size(141, 23);
            this.lblchar.TabIndex = 2;
            this.lblchar.Text = "Charaktername:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(990, 494);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(867, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Anzahl an Wertungen:";
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefresh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.ForeColor = System.Drawing.Color.White;
            this.BtnRefresh.Image = global::WoWTransmogTwitchApp.Properties.Resources.refresh2_klein;
            this.BtnRefresh.Location = new System.Drawing.Point(1065, 741);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(155, 37);
            this.BtnRefresh.TabIndex = 3;
            this.BtnRefresh.Text = "Aktualisieren";
            this.BtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.Transparent;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Image = global::WoWTransmogTwitchApp.Properties.Resources.close_icon21;
            this.BtnDelete.Location = new System.Drawing.Point(1226, 741);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(166, 37);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "Eintrag löschen";
            this.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Controls.Add(this.TxtSignedTotal);
            this.groupBox2.Controls.Add(this.BtnSignComp);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ComboJoins);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(849, 202);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anmeldungen";
            // 
            // TxtSignedTotal
            // 
            this.TxtSignedTotal.BackColor = System.Drawing.Color.MidnightBlue;
            this.TxtSignedTotal.ForeColor = System.Drawing.Color.White;
            this.TxtSignedTotal.Location = new System.Drawing.Point(403, 167);
            this.TxtSignedTotal.Name = "TxtSignedTotal";
            this.TxtSignedTotal.Size = new System.Drawing.Size(100, 29);
            this.TxtSignedTotal.TabIndex = 3;
            // 
            // BtnSignComp
            // 
            this.BtnSignComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSignComp.Location = new System.Drawing.Point(519, 156);
            this.BtnSignComp.Name = "BtnSignComp";
            this.BtnSignComp.Size = new System.Drawing.Size(312, 40);
            this.BtnSignComp.TabIndex = 2;
            this.BtnSignComp.Text = "Charakteranmeldung bestätigen";
            this.BtnSignComp.UseVisualStyleBackColor = true;
            this.BtnSignComp.Click += new System.EventHandler(this.BtnSignComp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(394, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Maximal 20 Anmeldungen möglich. Bisher bestätigt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Anmeldung bestätgen:";
            // 
            // ComboJoins
            // 
            this.ComboJoins.AllowDrop = true;
            this.ComboJoins.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ComboJoins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboJoins.FormattingEnabled = true;
            this.ComboJoins.Location = new System.Drawing.Point(199, 28);
            this.ComboJoins.Name = "ComboJoins";
            this.ComboJoins.Size = new System.Drawing.Size(632, 29);
            this.ComboJoins.TabIndex = 0;
            // 
            // TxtUsername
            // 
            this.TxtUsername.BackColor = System.Drawing.Color.MidnightBlue;
            this.TxtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.ForeColor = System.Drawing.Color.White;
            this.TxtUsername.Location = new System.Drawing.Point(1065, 555);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(327, 26);
            this.TxtUsername.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(907, 558);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "Angemeldet von:";
            // 
            // FormCompetitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WoWTransmogTwitchApp.Properties.Resources.bg_gross;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1404, 805);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblchar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.TxtAnzahl);
            this.Controls.Add(this.TxtStatus);
            this.Controls.Add(this.TxtCharname);
            this.Controls.Add(this.TxtCompID);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCompetitors";
            this.Text = "Teilnehmer";
            this.Load += new System.EventHandler(this.FormCompetitors_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView CompGridView;
        private System.Windows.Forms.TextBox TxtCompID;
        private System.Windows.Forms.TextBox TxtCharname;
        private System.Windows.Forms.TextBox TxtStatus;
        private System.Windows.Forms.TextBox TxtAnzahl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblchar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSignComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox ComboJoins;
        private System.Windows.Forms.TextBox TxtSignedTotal;
        private System.Windows.Forms.Label label6;
    }
}