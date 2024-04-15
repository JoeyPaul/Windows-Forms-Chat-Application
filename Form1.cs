namespace C__Windows_Forms_Application
{
    public partial class Form1 : Form
    {
        ChatServer server = null;
        ChatClient client = null;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void HostButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    int port = int.Parse(MyPortTextBox.Text);
                    server = ChatServer.CreateInstance(port, ChatTextBox);
                    if (server == null)
                    {
                        throw new Exception("Incorrect Port Value!"); // Exits try block
                    }
                    server.SetupServer();
                }
                catch (Exception ex)
                {
                    ChatTextBox.Text += "Error: " + ex.Message + "\n";
                }
            }
        }

        private void JoinServerButton_Click(object sender, EventArgs e)
        {
            if (CanHostOrJoin())
            {
                try
                {
                    int port = int.Parse(MyPortTextBox.Text);
                    int serverPort = int.Parse(ServerPortTextBox.Text);
                    client = ChatClient.CreateInstance(port, serverPort, ServerIPTextBox.Text,
                        ChatTextBox, Form1.ActiveForm, ServerPortTextBox, ServerIPTextBox, HostButton, JoinServerButton,
                        labelMyPort, labelServerID, labelServerPort, MyPortTextBox);
                    if (client == null)
                    {
                        throw new Exception("Incorrect Port Value!");
                    }
                    client.ConnectToServer();
                }
                catch (Exception ex)
                {
                    ChatTextBox.Text += "Error: " + ex.Message + "\n";
                }
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

        public bool CanHostOrJoin()
        {
            if (server == null && client == null)
                return true;
            else return false; // Has already become a client or a server.
        }

        private void SendButton_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (client != null)
            //    {
            //        client.SendString(TypeTextBox.Text);
            //    }
            //    else if (server != null)
            //    {
            //        server.SendToAll(TypeTextBox.Text, null);
            //    }
            //}
        }

        public void HideServerInformation()
        {
            MyPortTextBox.Hide();
            labelMyPort.Hide();
            labelServerPort.Hide();
            labelServerID.Hide();
            ServerPortTextBox.Hide();
            ServerIPTextBox.Hide();
            HostButton.Hide();
            JoinServerButton.Hide();
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
    }
}