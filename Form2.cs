using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__Windows_Forms_Application
{
    public partial class Form2 : Form
    {
        ChatServer server = null;
        ChatClient client = null;
        Form chatForm;

        public Form2(ChatServer server, ChatClient client, Form chatForm)
        {
            InitializeComponent();
            this.server = server;
            this.client = client;
            this.chatForm = chatForm;
        }

        private void TypeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SendButton.Focused) // Check if SendButton is already focused
                    return;

                SendButton.Focus();
                e.Handled = true; // Prevent the Enter key from adding a new line in the TextBox

                SendButton_Click(sender, e);

                TypeTextBox.Focus();
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.SendString("!name " + TypeTextBox.Text);
                this.Close();
                chatForm.Show();
            }
            else if (server != null)
            {
                server.SendToAll(TypeTextBox.Text, null);
                this.Close();
                chatForm.Show();
            }
            TypeTextBox.Clear();
        }
    }
}
