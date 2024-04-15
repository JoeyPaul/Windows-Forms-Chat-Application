namespace C__Windows_Forms_Application
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
            MyPortTextBox = new TextBox();
            HostButton = new Button();
            labelServerPort = new Label();
            ServerPortTextBox = new TextBox();
            labelServerID = new Label();
            ServerIPTextBox = new TextBox();
            JoinServerButton = new Button();
            ChatTextBox = new TextBox();
            label3 = new Label();
            TypeTextBox = new TextBox();
            SendButton = new Button();
            labelMyPort = new RichTextBox();
            SuspendLayout();
            // 
            // MyPortTextBox
            // 
            MyPortTextBox.Location = new Point(12, 27);
            MyPortTextBox.Name = "MyPortTextBox";
            MyPortTextBox.Size = new Size(100, 23);
            MyPortTextBox.TabIndex = 1;
            MyPortTextBox.Text = "9994";
            // 
            // HostButton
            // 
            HostButton.Location = new Point(12, 56);
            HostButton.Name = "HostButton";
            HostButton.Size = new Size(100, 23);
            HostButton.TabIndex = 2;
            HostButton.Text = "Host Server";
            HostButton.UseVisualStyleBackColor = true;
            HostButton.Click += HostButton_Click;
            // 
            // labelServerPort
            // 
            labelServerPort.AutoSize = true;
            labelServerPort.Location = new Point(139, 9);
            labelServerPort.Name = "labelServerPort";
            labelServerPort.Size = new Size(64, 15);
            labelServerPort.TabIndex = 3;
            labelServerPort.Text = "Server Port";
            // 
            // ServerPortTextBox
            // 
            ServerPortTextBox.Location = new Point(139, 27);
            ServerPortTextBox.Name = "ServerPortTextBox";
            ServerPortTextBox.Size = new Size(100, 23);
            ServerPortTextBox.TabIndex = 4;
            ServerPortTextBox.Text = "9994";
            // 
            // labelServerID
            // 
            labelServerID.AutoSize = true;
            labelServerID.Location = new Point(266, 9);
            labelServerID.Name = "labelServerID";
            labelServerID.Size = new Size(52, 15);
            labelServerID.TabIndex = 6;
            labelServerID.Text = "Server IP";
            // 
            // ServerIPTextBox
            // 
            ServerIPTextBox.Location = new Point(266, 27);
            ServerIPTextBox.Name = "ServerIPTextBox";
            ServerIPTextBox.Size = new Size(198, 23);
            ServerIPTextBox.TabIndex = 7;
            ServerIPTextBox.Text = "127.0.0.1";
            // 
            // JoinServerButton
            // 
            JoinServerButton.Location = new Point(139, 56);
            JoinServerButton.Name = "JoinServerButton";
            JoinServerButton.Size = new Size(100, 23);
            JoinServerButton.TabIndex = 8;
            JoinServerButton.Text = "Join Server";
            JoinServerButton.UseVisualStyleBackColor = true;
            JoinServerButton.Click += JoinServerButton_Click;
            // 
            // ChatTextBox
            // 
            ChatTextBox.BackColor = SystemColors.ControlLightLight;
            ChatTextBox.Location = new Point(12, 85);
            ChatTextBox.Multiline = true;
            ChatTextBox.Name = "ChatTextBox";
            ChatTextBox.ReadOnly = true;
            ChatTextBox.ScrollBars = ScrollBars.Vertical;
            ChatTextBox.Size = new Size(452, 250);
            ChatTextBox.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 344);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 10;
            label3.Text = "Chat";
            // 
            // TypeTextBox
            // 
            TypeTextBox.Location = new Point(50, 341);
            TypeTextBox.Name = "TypeTextBox";
            TypeTextBox.Size = new Size(338, 23);
            TypeTextBox.TabIndex = 11;
            TypeTextBox.KeyDown += TypeTextBox_KeyDown;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(393, 341);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(70, 23);
            SendButton.TabIndex = 12;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            SendButton.KeyDown += SendButton_KeyDown;
            // 
            // labelMyPort
            // 
            labelMyPort.BackColor = SystemColors.ButtonFace;
            labelMyPort.BorderStyle = BorderStyle.None;
            labelMyPort.Location = new Point(12, 9);
            labelMyPort.Multiline = false;
            labelMyPort.Name = "labelMyPort";
            labelMyPort.ReadOnly = true;
            labelMyPort.ScrollBars = RichTextBoxScrollBars.None;
            labelMyPort.Size = new Size(66, 18);
            labelMyPort.TabIndex = 13;
            labelMyPort.Text = "My Port";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 384);
            Controls.Add(labelMyPort);
            Controls.Add(SendButton);
            Controls.Add(TypeTextBox);
            Controls.Add(label3);
            Controls.Add(ChatTextBox);
            Controls.Add(JoinServerButton);
            Controls.Add(ServerIPTextBox);
            Controls.Add(labelServerID);
            Controls.Add(ServerPortTextBox);
            Controls.Add(labelServerPort);
            Controls.Add(HostButton);
            Controls.Add(MyPortTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox MyPortTextBox;
        private Button HostButton;
        private Label labelServerPort;
        private TextBox ServerPortTextBox;
        private Label labelServerID;
        private TextBox ServerIPTextBox;
        private Button JoinServerButton;
        private TextBox ChatTextBox;
        private Label label3;
        private TextBox TypeTextBox;
        private Button SendButton;
        private RichTextBox labelMyPort;
    }
}