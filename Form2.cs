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

        public Form2(ChatServer server, ChatClient client)
        {
            InitializeComponent();
            this.server = server;
            this.client = client;
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
                client.SendString(TypeTextBox.Text);
            }
            else if (server != null)
            {
                server.SendToAll(TypeTextBox.Text, null);
            }
            TypeTextBox.Clear();
        }

        public void HideCurrentForm()
        {
            this.Hide();
        }

        public void ShowCurrentForm()
        {
            this.Show();
        }
    }
}
