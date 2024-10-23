using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class Form1 : Form
    {
        Button currentButton;
        Random random;
        int tempIndex;
        Form acitveForm;
        public Form1()
        {
            InitializeComponent();
            MenuPanel.BackColor = Color.FromArgb(51, 51, 76);
            LogoPanel.BackColor = Color.FromArgb(39, 39, 58);
            TitlePanel.BackColor = Color.FromArgb(0, 150, 136);
            CloseButton.Visible = false;
            //Убираем рамку
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        #region Функции для перемещения окна
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }
        #endregion
        Color SelectThemeColor()
        {
            random = new Random();
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        void ActivateButton(object sender)
        {
            if (sender != null)
            {
                if (currentButton != (Button)sender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)sender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    TitlePanel.BackColor = color;
                    LogoPanel.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    CloseButton.Visible = true;
                }
            }
        }
        void DisableButton()
        {
            foreach (Control button in MenuPanel.Controls)
            {
                if (button is Button)
                {
                    button.BackColor = Color.FromArgb(51, 51, 76);
                    button.ForeColor = Color.Gainsboro;
                    button.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Products(), sender);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Orders(), sender);
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Customer(), sender);
        }

        private void ReportingButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Reporting(), sender);
        }

        private void NotificationsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Notifications(), sender);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Settings(), sender);
        }

        //Метод для открытия отдельной формы в DesktopPanel
        void OpenChildForm(Form childForm, object sender)
        {
            if (acitveForm != null)
            {
                acitveForm.Close();
            }
            ActivateButton(sender);
            acitveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.DesktopPanel.Controls.Add(childForm);
            this.DesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            TitleLabel.Text = childForm.Text;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (acitveForm != null)
            {
                acitveForm.Close();
            }
            Reset();
        }
        void Reset()
        {
            DisableButton();
            TitleLabel.Text = "HOME";
            TitlePanel.BackColor = Color.FromArgb(0, 150, 136);
            LogoPanel.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            CloseButton.Visible = false;
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
