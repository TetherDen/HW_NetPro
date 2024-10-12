namespace Exchanger_Client
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
            IpLabel = new Label();
            PortLabel = new Label();
            IpTextBox = new TextBox();
            PortTextBox = new TextBox();
            SendButton = new Button();
            MessageTextBox = new TextBox();
            MessageLabel = new Label();
            OutputListBox = new ListBox();
            SuspendLayout();
            // 
            // IpLabel
            // 
            IpLabel.AutoSize = true;
            IpLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            IpLabel.Location = new Point(12, 21);
            IpLabel.Name = "IpLabel";
            IpLabel.Size = new Size(21, 15);
            IpLabel.TabIndex = 0;
            IpLabel.Text = "IP:";
            // 
            // PortLabel
            // 
            PortLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            PortLabel.Location = new Point(164, 17);
            PortLabel.Name = "PortLabel";
            PortLabel.Size = new Size(43, 23);
            PortLabel.TabIndex = 1;
            PortLabel.Text = "Port:";
            PortLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IpTextBox
            // 
            IpTextBox.Location = new Point(39, 18);
            IpTextBox.Name = "IpTextBox";
            IpTextBox.Size = new Size(100, 23);
            IpTextBox.TabIndex = 2;
            IpTextBox.Text = "127.0.0.1";
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(213, 17);
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(100, 23);
            PortTextBox.TabIndex = 3;
            PortTextBox.Text = "777";
            // 
            // SendButton
            // 
            SendButton.Location = new Point(371, 247);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(77, 36);
            SendButton.TabIndex = 4;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // MessageTextBox
            // 
            MessageTextBox.Location = new Point(12, 300);
            MessageTextBox.Multiline = true;
            MessageTextBox.Name = "MessageTextBox";
            MessageTextBox.Size = new Size(448, 111);
            MessageTextBox.TabIndex = 5;
            // 
            // MessageLabel
            // 
            MessageLabel.AutoSize = true;
            MessageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            MessageLabel.Location = new Point(12, 282);
            MessageLabel.Name = "MessageLabel";
            MessageLabel.Size = new Size(58, 15);
            MessageLabel.TabIndex = 6;
            MessageLabel.Text = "Message:";
            // 
            // OutputListBox
            // 
            OutputListBox.FormattingEnabled = true;
            OutputListBox.ItemHeight = 15;
            OutputListBox.Location = new Point(12, 77);
            OutputListBox.Name = "OutputListBox";
            OutputListBox.Size = new Size(448, 154);
            OutputListBox.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 429);
            Controls.Add(OutputListBox);
            Controls.Add(MessageLabel);
            Controls.Add(MessageTextBox);
            Controls.Add(SendButton);
            Controls.Add(PortTextBox);
            Controls.Add(IpTextBox);
            Controls.Add(PortLabel);
            Controls.Add(IpLabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IpLabel;
        private Label PortLabel;
        private TextBox IpTextBox;
        private TextBox PortTextBox;
        private Button SendButton;
        private TextBox MessageTextBox;
        private Label MessageLabel;
        private ListBox OutputListBox;
    }
}
