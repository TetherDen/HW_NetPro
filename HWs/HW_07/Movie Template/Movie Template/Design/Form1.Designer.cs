
namespace Design
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MenuPanel = new System.Windows.Forms.Panel();
            SettingsButton = new System.Windows.Forms.Button();
            NotificationsButton = new System.Windows.Forms.Button();
            ReportingButton = new System.Windows.Forms.Button();
            CustomerButton = new System.Windows.Forms.Button();
            OrderButton = new System.Windows.Forms.Button();
            MoviesButton = new System.Windows.Forms.Button();
            LogoPanel = new System.Windows.Forms.Panel();
            LogoLabel = new System.Windows.Forms.Label();
            TitlePanel = new System.Windows.Forms.Panel();
            MinimizeButton = new System.Windows.Forms.Button();
            MaximizeButton = new System.Windows.Forms.Button();
            CloseFormButton = new System.Windows.Forms.Button();
            CloseButton = new System.Windows.Forms.Button();
            TitleLabel = new System.Windows.Forms.Label();
            DesktopPanel = new System.Windows.Forms.Panel();
            MenuPanel.SuspendLayout();
            LogoPanel.SuspendLayout();
            TitlePanel.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPanel
            // 
            MenuPanel.Controls.Add(SettingsButton);
            MenuPanel.Controls.Add(NotificationsButton);
            MenuPanel.Controls.Add(ReportingButton);
            MenuPanel.Controls.Add(CustomerButton);
            MenuPanel.Controls.Add(OrderButton);
            MenuPanel.Controls.Add(MoviesButton);
            MenuPanel.Controls.Add(LogoPanel);
            MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            MenuPanel.Location = new System.Drawing.Point(0, 0);
            MenuPanel.Name = "MenuPanel";
            MenuPanel.Size = new System.Drawing.Size(220, 583);
            MenuPanel.TabIndex = 0;
            // 
            // SettingsButton
            // 
            SettingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            SettingsButton.FlatAppearance.BorderSize = 0;
            SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SettingsButton.ForeColor = System.Drawing.Color.Gainsboro;
            SettingsButton.Image = (System.Drawing.Image)resources.GetObject("SettingsButton.Image");
            SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            SettingsButton.Location = new System.Drawing.Point(0, 380);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            SettingsButton.Size = new System.Drawing.Size(220, 60);
            SettingsButton.TabIndex = 6;
            SettingsButton.Text = "   Settings";
            SettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            SettingsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // NotificationsButton
            // 
            NotificationsButton.Dock = System.Windows.Forms.DockStyle.Top;
            NotificationsButton.FlatAppearance.BorderSize = 0;
            NotificationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NotificationsButton.ForeColor = System.Drawing.Color.Gainsboro;
            NotificationsButton.Image = Properties.Resources.alarm;
            NotificationsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            NotificationsButton.Location = new System.Drawing.Point(0, 320);
            NotificationsButton.Name = "NotificationsButton";
            NotificationsButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            NotificationsButton.Size = new System.Drawing.Size(220, 60);
            NotificationsButton.TabIndex = 5;
            NotificationsButton.Text = "   Notifications";
            NotificationsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            NotificationsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            NotificationsButton.UseVisualStyleBackColor = true;
            NotificationsButton.Click += NotificationsButton_Click;
            // 
            // ReportingButton
            // 
            ReportingButton.Dock = System.Windows.Forms.DockStyle.Top;
            ReportingButton.FlatAppearance.BorderSize = 0;
            ReportingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ReportingButton.ForeColor = System.Drawing.Color.Gainsboro;
            ReportingButton.Image = Properties.Resources.bar_chart;
            ReportingButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ReportingButton.Location = new System.Drawing.Point(0, 260);
            ReportingButton.Name = "ReportingButton";
            ReportingButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            ReportingButton.Size = new System.Drawing.Size(220, 60);
            ReportingButton.TabIndex = 4;
            ReportingButton.Text = "   Reporting";
            ReportingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ReportingButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ReportingButton.UseVisualStyleBackColor = true;
            ReportingButton.Click += ReportingButton_Click;
            // 
            // CustomerButton
            // 
            CustomerButton.Dock = System.Windows.Forms.DockStyle.Top;
            CustomerButton.FlatAppearance.BorderSize = 0;
            CustomerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CustomerButton.ForeColor = System.Drawing.Color.Gainsboro;
            CustomerButton.Image = Properties.Resources.value2;
            CustomerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            CustomerButton.Location = new System.Drawing.Point(0, 200);
            CustomerButton.Name = "CustomerButton";
            CustomerButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            CustomerButton.Size = new System.Drawing.Size(220, 60);
            CustomerButton.TabIndex = 3;
            CustomerButton.Text = "   Customer";
            CustomerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            CustomerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            CustomerButton.UseVisualStyleBackColor = true;
            CustomerButton.Click += CustomerButton_Click;
            // 
            // OrderButton
            // 
            OrderButton.Dock = System.Windows.Forms.DockStyle.Top;
            OrderButton.FlatAppearance.BorderSize = 0;
            OrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            OrderButton.ForeColor = System.Drawing.Color.Gainsboro;
            OrderButton.Image = Properties.Resources.shopping_list;
            OrderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            OrderButton.Location = new System.Drawing.Point(0, 140);
            OrderButton.Name = "OrderButton";
            OrderButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            OrderButton.Size = new System.Drawing.Size(220, 60);
            OrderButton.TabIndex = 2;
            OrderButton.Text = "   Orders";
            OrderButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            OrderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            OrderButton.UseVisualStyleBackColor = true;
            OrderButton.Click += OrderButton_Click;
            // 
            // MoviesButton
            // 
            MoviesButton.Dock = System.Windows.Forms.DockStyle.Top;
            MoviesButton.FlatAppearance.BorderSize = 0;
            MoviesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MoviesButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            MoviesButton.ForeColor = System.Drawing.Color.Gainsboro;
            MoviesButton.Image = Properties.Resources.shopping_cart;
            MoviesButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            MoviesButton.Location = new System.Drawing.Point(0, 80);
            MoviesButton.Name = "MoviesButton";
            MoviesButton.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            MoviesButton.Size = new System.Drawing.Size(220, 60);
            MoviesButton.TabIndex = 1;
            MoviesButton.Text = "   Products";
            MoviesButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            MoviesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            MoviesButton.UseVisualStyleBackColor = true;
            MoviesButton.Click += ProductButton_Click;
            // 
            // LogoPanel
            // 
            LogoPanel.Controls.Add(LogoLabel);
            LogoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            LogoPanel.Location = new System.Drawing.Point(0, 0);
            LogoPanel.Name = "LogoPanel";
            LogoPanel.Size = new System.Drawing.Size(220, 80);
            LogoPanel.TabIndex = 0;
            // 
            // LogoLabel
            // 
            LogoLabel.AutoSize = true;
            LogoLabel.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LogoLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            LogoLabel.Location = new System.Drawing.Point(42, 24);
            LogoLabel.Name = "LogoLabel";
            LogoLabel.Size = new System.Drawing.Size(113, 30);
            LogoLabel.TabIndex = 0;
            LogoLabel.Text = "Your Logo";
            // 
            // TitlePanel
            // 
            TitlePanel.Controls.Add(MinimizeButton);
            TitlePanel.Controls.Add(MaximizeButton);
            TitlePanel.Controls.Add(CloseFormButton);
            TitlePanel.Controls.Add(CloseButton);
            TitlePanel.Controls.Add(TitleLabel);
            TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            TitlePanel.Location = new System.Drawing.Point(220, 0);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new System.Drawing.Size(743, 80);
            TitlePanel.TabIndex = 1;
            TitlePanel.MouseDown += TitlePanel_MouseDown;
            // 
            // MinimizeButton
            // 
            MinimizeButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            MinimizeButton.FlatAppearance.BorderSize = 0;
            MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MinimizeButton.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            MinimizeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            MinimizeButton.Location = new System.Drawing.Point(638, 3);
            MinimizeButton.Name = "MinimizeButton";
            MinimizeButton.Size = new System.Drawing.Size(30, 30);
            MinimizeButton.TabIndex = 4;
            MinimizeButton.Text = "_";
            MinimizeButton.UseVisualStyleBackColor = true;
            MinimizeButton.Click += MinimizeButton_Click;
            // 
            // MaximizeButton
            // 
            MaximizeButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            MaximizeButton.FlatAppearance.BorderSize = 0;
            MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MaximizeButton.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            MaximizeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            MaximizeButton.Location = new System.Drawing.Point(674, 3);
            MaximizeButton.Name = "MaximizeButton";
            MaximizeButton.Size = new System.Drawing.Size(30, 30);
            MaximizeButton.TabIndex = 3;
            MaximizeButton.Text = "O";
            MaximizeButton.UseVisualStyleBackColor = true;
            MaximizeButton.Click += MaximizeButton_Click;
            // 
            // CloseFormButton
            // 
            CloseFormButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CloseFormButton.FlatAppearance.BorderSize = 0;
            CloseFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseFormButton.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            CloseFormButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            CloseFormButton.Location = new System.Drawing.Point(710, 3);
            CloseFormButton.Name = "CloseFormButton";
            CloseFormButton.Size = new System.Drawing.Size(30, 30);
            CloseFormButton.TabIndex = 2;
            CloseFormButton.Text = "X";
            CloseFormButton.UseVisualStyleBackColor = true;
            CloseFormButton.Click += CloseFormButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.Dock = System.Windows.Forms.DockStyle.Left;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CloseButton.Image = Properties.Resources.cross_out;
            CloseButton.Location = new System.Drawing.Point(0, 0);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(75, 80);
            CloseButton.TabIndex = 1;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // TitleLabel
            // 
            TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            TitleLabel.Location = new System.Drawing.Point(314, 24);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new System.Drawing.Size(76, 30);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "HOME";
            // 
            // DesktopPanel
            // 
            DesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            DesktopPanel.Location = new System.Drawing.Point(220, 80);
            DesktopPanel.Name = "DesktopPanel";
            DesktopPanel.Size = new System.Drawing.Size(743, 503);
            DesktopPanel.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(963, 583);
            Controls.Add(DesktopPanel);
            Controls.Add(TitlePanel);
            Controls.Add(MenuPanel);
            Name = "Form1";
            Text = "Form1";
            MenuPanel.ResumeLayout(false);
            LogoPanel.ResumeLayout(false);
            LogoPanel.PerformLayout();
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.Button MoviesButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button NotificationsButton;
        private System.Windows.Forms.Button ReportingButton;
        private System.Windows.Forms.Button CustomerButton;
        private System.Windows.Forms.Button OrderButton;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label LogoLabel;
        private System.Windows.Forms.Panel DesktopPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button CloseFormButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button MaximizeButton;
    }
}

