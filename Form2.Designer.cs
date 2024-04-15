namespace C__Windows_Forms_Application
{
    partial class Form2
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
            TypeTextBox = new TextBox();
            SendButton = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // TypeTextBox
            // 
            TypeTextBox.Location = new Point(43, 66);
            TypeTextBox.Name = "TypeTextBox";
            TypeTextBox.Size = new Size(333, 23);
            TypeTextBox.TabIndex = 0;
            TypeTextBox.KeyDown += TypeTextBox_KeyDown;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(382, 66);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(75, 23);
            SendButton.TabIndex = 1;
            SendButton.Text = "Create";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ButtonFace;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Verdana", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox1.Location = new Point(69, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(363, 48);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "Create User Name";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 117);
            Controls.Add(richTextBox1);
            Controls.Add(SendButton);
            Controls.Add(TypeTextBox);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TypeTextBox;
        private Button SendButton;
        private RichTextBox richTextBox1;
    }
}