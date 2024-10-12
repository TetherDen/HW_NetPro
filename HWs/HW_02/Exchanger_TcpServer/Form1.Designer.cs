namespace Exchanger_TcpServer
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
            IpTextBox = new TextBox();
            IPLabel = new Label();
            PortTextBox = new TextBox();
            PortLabel = new Label();
            StartServerButton = new Button();
            MessagesList = new ListBox();
            MessageLabel = new Label();
            SuspendLayout();
            // 
            // IpTextBox
            // 
            IpTextBox.Location = new Point(90, 26);
            IpTextBox.Name = "IpTextBox";
            IpTextBox.Size = new Size(100, 23);
            IpTextBox.TabIndex = 4;
            IpTextBox.Text = "127.0.0.1";
            // 
            // IPLabel
            // 
            IPLabel.AutoSize = true;
            IPLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            IPLabel.Location = new Point(49, 29);
            IPLabel.Name = "IPLabel";
            IPLabel.Size = new Size(21, 15);
            IPLabel.TabIndex = 7;
            IPLabel.Text = "IP:";
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(300, 26);
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(123, 23);
            PortTextBox.TabIndex = 9;
            PortTextBox.Text = "777";
            // 
            // PortLabel
            // 
            PortLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PortLabel.Location = new Point(240, 26);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(54, 23);
            PortLabel.TabIndex = 8;
            PortLabel.Text = "Port:";
            PortLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StartServerButton
            // 
            StartServerButton.Location = new Point(479, 21);
            StartServerButton.Name = "StartServerButton";
            StartServerButton.Size = new Size(120, 31);
            StartServerButton.TabIndex = 10;
            StartServerButton.Text = "Start Server";
            StartServerButton.UseVisualStyleBackColor = true;
            StartServerButton.Click += StartServerButton_Click;
            // 
            // MessagesList
            // 
            MessagesList.FormattingEnabled = true;
            MessagesList.ItemHeight = 15;
            MessagesList.Location = new Point(49, 199);
            MessagesList.Name = "MessagesList";
            MessagesList.Size = new Size(601, 229);
            MessagesList.TabIndex = 11;
            // 
            // MessageLabel
            // 
            MessageLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MessageLabel.Location = new Point(49, 156);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(124, 28);
            MessageLabel.TabIndex = 12;
            MessageLabel.Text = "Messages:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 445);
            Controls.Add(MessageLabel);
            Controls.Add(MessagesList);
            Controls.Add(StartServerButton);
            Controls.Add(PortTextBox);
            Controls.Add(PortLabel);
            Controls.Add(IPLabel);
            Controls.Add(IpTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IpTextBox;
        private Label IPLabel;
        private TextBox PortTextBox;
        private Label PortLabel;
        private Button StartServerButton;
        private ListBox MessagesList;
        private Label MessageLabel;
    }
}
