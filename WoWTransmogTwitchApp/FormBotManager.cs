using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WoWTransmogTwitchApp.Classes;

namespace WoWTransmogTwitchApp
{
    public partial class FormBotManager : Form
    {
        private int tempIndex;
        private Button currentButton;
        private readonly Random random;
        private Form activeForm;
        private delegate void SafeCallDelegate(string text);
        private BotMainCore _maincore;
        private bool _isLogging;
        public static bool _isConnected;
        public FormBotManager()
        {
            InitializeComponent();
            random = new Random();
            BtnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 8, 8));
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
              int nLeftRect,
              int nTopRect,
              int nRightRect,
              int nBottomRect,
              int nWidthEllipse,
              int nHeightEllipse
          );
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void TaskBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void FormBotManager_Load(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                _maincore = new BotMainCore();
                _maincore.LogTxt += SetLogtext;
                _maincore.Connected += SetOnlineStatus;
                _maincore.ChatText += SetChatText;
                _maincore.ViewerText += SetViewerText;
                _maincore.ViewerText2 += SetViewerText2;
                StatusBot.ForeColor = Color.Firebrick;
                SetOnlineStatustext("Offline");
                SetOnlineStatusbtntext("Verbinden");
                _isConnected = false;
                
            }
            else
            {
                StatusBot.ForeColor = Color.Green;
                SetOnlineStatustext("Online");
                SetOnlineStatusbtntext("Trennen");
                _isConnected = true;
            }
        }
        private void SetChatText(string text)
        {
            if (ChatTextListBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetChatText);
                ChatTextListBox.Invoke(d, new object[] { text });
            }
            else
            {
                ChatTextListBox.Items.Add(text);
                ChatTextListBox.SelectedIndex = ChatTextListBox.Items.Count - 1;
                ChatTextListBox.SelectedIndex = -1;
            }
        }
        private void SetViewerText(string text)
        {
            if (!ViewerListBox.Items.Contains(text))
            {
                if (ViewerListBox.InvokeRequired)
                {
                    var d = new SafeCallDelegate(SetViewerText);
                    ViewerListBox.Invoke(d, new object[] { text });
                }
                else
                {
                    ViewerListBox.Items.Add(text);
                    LblViewer.Text = "Viewer: " + ViewerListBox.Items.Count.ToString();
                }
            }
        }
        private void SetViewerText2(string text)
        {
            if (ViewerListBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetViewerText2);
                ViewerListBox.Invoke(d, new object[] { text });
            }
            else
            {
                ViewerListBox.Items.Remove(text);
                LblViewer.Text = "Viewer: " + ViewerListBox.Items.Count.ToString();
            }
        }
        private void BtnLogOff_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                string message = "Bitte erst Verbindung trennen, bevor Sie das Logging ein-/ausschalten.";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }

            if (_isLogging)
            {
                _isLogging = false;
                StatusLogs.ForeColor = Color.Firebrick;

                SetLoggingStatustext("Logs: Aus");
                SetLoggingStatusbtntext("Einschalten");

            }
            else
            {
                _isLogging = true;
                StatusLogs.ForeColor = Color.Green;
                SetLoggingStatustext("Logs: Ein");
                SetLoggingStatusbtntext("Ausschalten");

            }
        }
        private void SetLogtext(string text)
        {
            if (LogTextBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetLogtext);
                LogTextBox.Invoke(d, new object[] { text });
            }
            else
            {
                LogTextBox.Text += text;
                LogTextBox.SelectionStart = LogTextBox.Text.Length;
                LogTextBox.ScrollToCaret();
            }
        }
        private void SetLoggingStatustext(string text)
        {
            if (StatusLogs.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetLoggingStatustext);
                StatusLogs.Invoke(d, new object[] { text });
            }
            else
            {
                StatusLogs.Text = text;
            }
        }
        private void SetLoggingStatusbtntext(string text)
        {
            if (BtnLogOff.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetLoggingStatusbtntext);
                BtnLogOff.Invoke(d, new object[] { text });
            }
            else
            {
                BtnLogOff.Text = text;
            }
        }
        private void BarTimer_Tick(object sender, EventArgs e)
        {
            this.ServerstartBar.Increment(2);
            if (ServerstartBar.Value == 100)
            {
                BarTimer.Stop();
            }
        }
        private void BtnConnnect_Click(object sender, EventArgs e)
        {
            if (!_isConnected)
            {
                _maincore.Connect(_isLogging);
                this.BarTimer.Start();
            }
            else
            {
                _maincore.Disconnect();
            }
        }

        private void SetOnlineStatus(bool status)
        {
            if (status)
            {
                StatusBot.ForeColor = Color.Green;
                SetOnlineStatustext("Online");
                SetOnlineStatusbtntext("Trennen");
                BtnConnect.Image = global::WoWTransmogTwitchApp.Properties.Resources.connected_ico_25x_;
                _isConnected = true;
            }
            else
            {
                StatusBot.ForeColor = Color.Firebrick;
                SetOnlineStatustext("Offline");
                SetOnlineStatusbtntext("Verbinden");
                BtnConnect.Image = global::WoWTransmogTwitchApp.Properties.Resources.connect_ico_25x_;
                _isConnected = false;
                ServerstartBar.ResetText();
                ServerstartBar.Value = 0;
            }
        }
        private void SetOnlineStatustext(string text)
        {
            if (StatusBot.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetOnlineStatustext);
                StatusBot.Invoke(d, new object[] { text });
            }
            else
            {
                StatusBot.Text = text;
            }
        }
        private void SetOnlineStatusbtntext(string text)
        {
            if (BtnConnect.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetOnlineStatusbtntext);
                BtnConnect.Invoke(d, new object[] { text });
            }
            else
            {
                BtnConnect.Text = text;
            }
        }
        private void BtnCloseApp_MouseHover(object sender, EventArgs e)
        {
            this.BtnCloseApp.BackColor = Color.White;
        }
        private void BtnCloseApp_MouseLeave(object sender, EventArgs e)
        {
            this.BtnCloseApp.BackColor = Color.Transparent;
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("NewTimesRoman", 11.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    BtnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.LightBlue;
                    previousBtn.Font = new System.Drawing.Font("NewTimesRoman", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Dark Raffle Bot";
            currentButton = null;
            BtnCloseChildForm.Visible = false;
        }
        private void BtnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void BtnCloseApp_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Willst du das Programm wirklich beenden?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch
            {
                throw;
            }
        }
        private void BtnMsgSend_Click(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                _maincore.SendMsg(MessageText.Text);
                MessageText.Clear();
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
        private void MessageText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_isConnected)
                {
                    _maincore.SendMsg(MessageText.Text);
                    MessageText.Clear();
                }
                else
                {
                    string message = "Bot ist nicht Online !.";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                    return;
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void BtnAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormAccountManager(), sender);
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormUser(), sender);
        }

        private void TaskBar_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
