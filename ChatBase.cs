using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__Windows_Forms_Application
{
    public class ChatBase
    {
        public TextBox chatTextBox;
        public int port;

        // Chat Text Box Functions
        public void SetChat(String str)
        {
            // Send message from this thread to the main thread
            chatTextBox.Invoke((Action)delegate
            {
                chatTextBox.Text = str;
                chatTextBox.AppendText(Environment.NewLine);
            });
        }
        public void AddToChat(string str)
        {
            chatTextBox.Invoke((Action)delegate
            {
                chatTextBox.AppendText(str);
                chatTextBox.AppendText(Environment.NewLine);
            });
        }
    }
}