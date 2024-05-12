
namespace WoWTransmogTwitchApp
{
    partial class FormBotManager
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBotManager));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.BtnAccount = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TaskBar = new System.Windows.Forms.Panel();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.BtnMaximize = new System.Windows.Forms.Button();
            this.BtnCloseApp = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.BtnCloseChildForm = new System.Windows.Forms.Button();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.BtnMsgSend = new System.Windows.Forms.Button();
            this.LblViewer = new System.Windows.Forms.Label();
            this.ViewerListBox = new System.Windows.Forms.ListBox();
            this.ChatTextListBox = new System.Windows.Forms.ListBox();
            this.StatusLogs = new System.Windows.Forms.Label();
            this.StatusBot = new System.Windows.Forms.Label();
            this.ServerstartBar = new System.Windows.Forms.ProgressBar();
            this.BtnLogOff = new System.Windows.Forms.Button();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BarTimer = new System.Windows.Forms.Timer(this.components);
            this.BtnUser = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.TaskBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.BtnUser);
            this.panelMenu.Controls.Add(this.BtnAccount);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 861);
            this.panelMenu.TabIndex = 0;
            // 
            // BtnAccount
            // 
            this.BtnAccount.BackColor = System.Drawing.Color.Transparent;
            this.BtnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAccount.FlatAppearance.BorderSize = 0;
            this.BtnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAccount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAccount.ForeColor = System.Drawing.Color.White;
            this.BtnAccount.Image = global::WoWTransmogTwitchApp.Properties.Resources.user1;
            this.BtnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAccount.Location = new System.Drawing.Point(0, 55);
            this.BtnAccount.Name = "BtnAccount";
            this.BtnAccount.Size = new System.Drawing.Size(198, 45);
            this.BtnAccount.TabIndex = 2;
            this.BtnAccount.Text = "Account";
            this.BtnAccount.UseVisualStyleBackColor = false;
            this.BtnAccount.Click += new System.EventHandler(this.BtnAccount_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 55);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WoWTransmogTwitchApp.Properties.Resources.wowlogo1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 42);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WoWTransmogTwitchApp.Properties.Resources.twitch;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(67, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(97, 48);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // TaskBar
            // 
            this.TaskBar.BackColor = System.Drawing.Color.Transparent;
            this.TaskBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TaskBar.Controls.Add(this.BtnMinimize);
            this.TaskBar.Controls.Add(this.BtnMaximize);
            this.TaskBar.Controls.Add(this.BtnCloseApp);
            this.TaskBar.Controls.Add(this.lblTitle);
            this.TaskBar.Controls.Add(this.BtnCloseChildForm);
            this.TaskBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaskBar.Location = new System.Drawing.Point(200, 0);
            this.TaskBar.Name = "TaskBar";
            this.TaskBar.Size = new System.Drawing.Size(1404, 56);
            this.TaskBar.TabIndex = 1;
            this.TaskBar.Paint += new System.Windows.Forms.PaintEventHandler(this.TaskBar_Paint);
            this.TaskBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskBar_MouseDown);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.BackgroundImage = global::WoWTransmogTwitchApp.Properties.Resources.minimize_window_32__1_;
            this.BtnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimize.Location = new System.Drawing.Point(1289, 11);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(30, 30);
            this.BtnMinimize.TabIndex = 2;
            this.BtnMinimize.UseVisualStyleBackColor = true;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnMaximize
            // 
            this.BtnMaximize.BackgroundImage = global::WoWTransmogTwitchApp.Properties.Resources.maximize_window_32__1_;
            this.BtnMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaximize.Location = new System.Drawing.Point(1325, 11);
            this.BtnMaximize.Name = "BtnMaximize";
            this.BtnMaximize.Size = new System.Drawing.Size(30, 30);
            this.BtnMaximize.TabIndex = 2;
            this.BtnMaximize.UseVisualStyleBackColor = true;
            this.BtnMaximize.Click += new System.EventHandler(this.BtnMaximize_Click);
            // 
            // BtnCloseApp
            // 
            this.BtnCloseApp.BackgroundImage = global::WoWTransmogTwitchApp.Properties.Resources.close_window_32;
            this.BtnCloseApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseApp.Location = new System.Drawing.Point(1361, 11);
            this.BtnCloseApp.Name = "BtnCloseApp";
            this.BtnCloseApp.Size = new System.Drawing.Size(30, 30);
            this.BtnCloseApp.TabIndex = 2;
            this.BtnCloseApp.UseVisualStyleBackColor = true;
            this.BtnCloseApp.Click += new System.EventHandler(this.BtnCloseApp_Click);
            this.BtnCloseApp.MouseLeave += new System.EventHandler(this.BtnCloseApp_MouseLeave);
            this.BtnCloseApp.MouseHover += new System.EventHandler(this.BtnCloseApp_MouseHover);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(86, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Dark Raffle Bot";
            // 
            // BtnCloseChildForm
            // 
            this.BtnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.BtnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseChildForm.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCloseChildForm.ForeColor = System.Drawing.Color.White;
            this.BtnCloseChildForm.Image = global::WoWTransmogTwitchApp.Properties.Resources.close_icon2;
            this.BtnCloseChildForm.Location = new System.Drawing.Point(5, 8);
            this.BtnCloseChildForm.Name = "BtnCloseChildForm";
            this.BtnCloseChildForm.Size = new System.Drawing.Size(44, 41);
            this.BtnCloseChildForm.TabIndex = 0;
            this.BtnCloseChildForm.UseVisualStyleBackColor = true;
            this.BtnCloseChildForm.Click += new System.EventHandler(this.BtnCloseChildForm_Click);
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.BackColor = System.Drawing.Color.Transparent;
            this.panelDesktopPane.Controls.Add(this.LogTextBox);
            this.panelDesktopPane.Controls.Add(this.MessageText);
            this.panelDesktopPane.Controls.Add(this.BtnMsgSend);
            this.panelDesktopPane.Controls.Add(this.LblViewer);
            this.panelDesktopPane.Controls.Add(this.ViewerListBox);
            this.panelDesktopPane.Controls.Add(this.ChatTextListBox);
            this.panelDesktopPane.Controls.Add(this.StatusLogs);
            this.panelDesktopPane.Controls.Add(this.StatusBot);
            this.panelDesktopPane.Controls.Add(this.ServerstartBar);
            this.panelDesktopPane.Controls.Add(this.BtnLogOff);
            this.panelDesktopPane.Controls.Add(this.BtnConnect);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(200, 56);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(1404, 805);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // LogTextBox
            // 
            this.LogTextBox.AllowDrop = true;
            this.LogTextBox.BackColor = System.Drawing.Color.DimGray;
            this.LogTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextBox.ForeColor = System.Drawing.Color.SeaShell;
            this.LogTextBox.Location = new System.Drawing.Point(307, 9);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(1085, 64);
            this.LogTextBox.TabIndex = 8;
            // 
            // MessageText
            // 
            this.MessageText.BackColor = System.Drawing.Color.RoyalBlue;
            this.MessageText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageText.ForeColor = System.Drawing.Color.White;
            this.MessageText.Location = new System.Drawing.Point(94, 757);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(1053, 29);
            this.MessageText.TabIndex = 7;
            this.MessageText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageText_KeyDown);
            // 
            // BtnMsgSend
            // 
            this.BtnMsgSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMsgSend.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMsgSend.ForeColor = System.Drawing.Color.White;
            this.BtnMsgSend.Location = new System.Drawing.Point(5, 757);
            this.BtnMsgSend.Name = "BtnMsgSend";
            this.BtnMsgSend.Size = new System.Drawing.Size(83, 29);
            this.BtnMsgSend.TabIndex = 6;
            this.BtnMsgSend.Text = "Senden";
            this.BtnMsgSend.UseVisualStyleBackColor = true;
            this.BtnMsgSend.Click += new System.EventHandler(this.BtnMsgSend_Click);
            // 
            // LblViewer
            // 
            this.LblViewer.AutoSize = true;
            this.LblViewer.BackColor = System.Drawing.Color.Transparent;
            this.LblViewer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblViewer.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblViewer.ForeColor = System.Drawing.Color.White;
            this.LblViewer.Location = new System.Drawing.Point(6, 92);
            this.LblViewer.Name = "LblViewer";
            this.LblViewer.Size = new System.Drawing.Size(55, 19);
            this.LblViewer.TabIndex = 5;
            this.LblViewer.Text = "Viewer:";
            // 
            // ViewerListBox
            // 
            this.ViewerListBox.AllowDrop = true;
            this.ViewerListBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.ViewerListBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewerListBox.ForeColor = System.Drawing.Color.White;
            this.ViewerListBox.FormattingEnabled = true;
            this.ViewerListBox.ItemHeight = 19;
            this.ViewerListBox.Location = new System.Drawing.Point(1153, 79);
            this.ViewerListBox.Name = "ViewerListBox";
            this.ViewerListBox.ScrollAlwaysVisible = true;
            this.ViewerListBox.Size = new System.Drawing.Size(239, 707);
            this.ViewerListBox.TabIndex = 4;
            // 
            // ChatTextListBox
            // 
            this.ChatTextListBox.AllowDrop = true;
            this.ChatTextListBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.ChatTextListBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatTextListBox.ForeColor = System.Drawing.Color.White;
            this.ChatTextListBox.FormattingEnabled = true;
            this.ChatTextListBox.HorizontalScrollbar = true;
            this.ChatTextListBox.ItemHeight = 19;
            this.ChatTextListBox.Location = new System.Drawing.Point(5, 130);
            this.ChatTextListBox.Name = "ChatTextListBox";
            this.ChatTextListBox.ScrollAlwaysVisible = true;
            this.ChatTextListBox.Size = new System.Drawing.Size(1142, 612);
            this.ChatTextListBox.TabIndex = 3;
            // 
            // StatusLogs
            // 
            this.StatusLogs.AutoSize = true;
            this.StatusLogs.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLogs.ForeColor = System.Drawing.Color.White;
            this.StatusLogs.Location = new System.Drawing.Point(146, 52);
            this.StatusLogs.Name = "StatusLogs";
            this.StatusLogs.Size = new System.Drawing.Size(56, 21);
            this.StatusLogs.TabIndex = 2;
            this.StatusLogs.Text = "Status";
            // 
            // StatusBot
            // 
            this.StatusBot.AutoSize = true;
            this.StatusBot.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBot.ForeColor = System.Drawing.Color.White;
            this.StatusBot.Location = new System.Drawing.Point(146, 12);
            this.StatusBot.Name = "StatusBot";
            this.StatusBot.Size = new System.Drawing.Size(56, 21);
            this.StatusBot.TabIndex = 2;
            this.StatusBot.Text = "Status";
            // 
            // ServerstartBar
            // 
            this.ServerstartBar.BackColor = System.Drawing.Color.DarkOrange;
            this.ServerstartBar.Location = new System.Drawing.Point(6, 114);
            this.ServerstartBar.Name = "ServerstartBar";
            this.ServerstartBar.Size = new System.Drawing.Size(458, 10);
            this.ServerstartBar.TabIndex = 1;
            // 
            // BtnLogOff
            // 
            this.BtnLogOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogOff.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogOff.ForeColor = System.Drawing.Color.White;
            this.BtnLogOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogOff.Location = new System.Drawing.Point(5, 45);
            this.BtnLogOff.Name = "BtnLogOff";
            this.BtnLogOff.Size = new System.Drawing.Size(135, 35);
            this.BtnLogOff.TabIndex = 1;
            this.BtnLogOff.Text = "Logging";
            this.BtnLogOff.UseVisualStyleBackColor = true;
            this.BtnLogOff.Click += new System.EventHandler(this.BtnLogOff_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConnect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConnect.ForeColor = System.Drawing.Color.White;
            this.BtnConnect.Image = global::WoWTransmogTwitchApp.Properties.Resources.connect_ico_25x_;
            this.BtnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConnect.Location = new System.Drawing.Point(5, 6);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(135, 35);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "Verbinden";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnnect_Click);
            // 
            // BarTimer
            // 
            this.BarTimer.Tick += new System.EventHandler(this.BarTimer_Tick);
            // 
            // BtnUser
            // 
            this.BtnUser.BackColor = System.Drawing.Color.Transparent;
            this.BtnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUser.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUser.ForeColor = System.Drawing.Color.White;
            this.BtnUser.Image = global::WoWTransmogTwitchApp.Properties.Resources.hold;
            this.BtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.Location = new System.Drawing.Point(0, 100);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(198, 45);
            this.BtnUser.TabIndex = 4;
            this.BtnUser.Text = "Zuschauer";
            this.BtnUser.UseVisualStyleBackColor = false;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // FormBotManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::WoWTransmogTwitchApp.Properties.Resources.bg_gross;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1604, 861);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.TaskBar);
            this.Controls.Add(this.panelMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBotManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dark Raffle Bot";
            this.Load += new System.EventHandler(this.FormBotManager_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.TaskBar.ResumeLayout(false);
            this.TaskBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.panelDesktopPane.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BtnAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TaskBar;
        private System.Windows.Forms.Button BtnCloseChildForm;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button BtnCloseApp;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.Button BtnMaximize;
        private System.Windows.Forms.Timer BarTimer;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.ProgressBar ServerstartBar;
        private System.Windows.Forms.Label StatusBot;
        private System.Windows.Forms.ListBox ChatTextListBox;
        private System.Windows.Forms.ListBox ViewerListBox;
        private System.Windows.Forms.Label LblViewer;
        private System.Windows.Forms.Button BtnMsgSend;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button BtnLogOff;
        private System.Windows.Forms.Label StatusLogs;
        private System.Windows.Forms.Button BtnUser;
    }
}

