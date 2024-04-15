using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;

namespace C__Windows_Forms_Application
{
    public class ChatClient : ChatBase
    {
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientSocket clientSocket = new ClientSocket();

        private Form clientForm;
        private Button joinServerButton;
        private Button hostButton;
        private TextBox serverPortTextBox;
        private TextBox myPortTextBox;
        private TextBox serverIPTextBox;
        private RichTextBox myPortLabel;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.Label serverIPLabel;

        private List<Control> serverInfoControls = new List<Control>();

        public int serverPort;
        public string serverIP = "";

        // Creator Static Function
        public static ChatClient CreateInstance(int port, int serverPort, string serverIP, TextBox chatTextBox, 
            Form clientForm, TextBox serverPortTextBox, TextBox serverIPTextBox, Button hostButton, Button joinServerButton,
            RichTextBox portLabel, System.Windows.Forms.Label IPLabel, System.Windows.Forms.Label serverPortLabel,
            TextBox myPortTextBox)
        {
            ChatClient? chatClient = null;
            if (port > 0 && port < 65535 && serverPort > 0 && serverPort < 65535
                && serverIP.Length > 0 && chatTextBox != null) 
            { 
                chatClient = new ChatClient();
                chatClient.port = port;
                chatClient.serverPort = serverPort;
                chatClient.serverIP = serverIP;
                chatClient.chatTextBox = chatTextBox;
                chatClient.clientSocket.socket = chatClient.socket;

                chatClient.clientForm = clientForm;
                chatClient.serverPortTextBox = serverPortTextBox;
                chatClient.serverIPTextBox = serverIPTextBox;
                chatClient.myPortTextBox = myPortTextBox;
                chatClient.hostButton = hostButton;
                chatClient.joinServerButton = joinServerButton;
                chatClient.myPortLabel = portLabel;
                chatClient.serverPortLabel = serverPortLabel;
                chatClient.serverIPLabel = IPLabel;

                // Add controls to the serverInfoControls list so we deactivate UI elements easily
                chatClient.serverInfoControls.Add(chatClient.serverPortTextBox);
                chatClient.serverInfoControls.Add(chatClient.serverIPTextBox);
                chatClient.serverInfoControls.Add(chatClient.hostButton);
                chatClient.serverInfoControls.Add(chatClient.joinServerButton);
                chatClient.serverInfoControls.Add(chatClient.serverPortLabel);
                chatClient.serverInfoControls.Add(chatClient.serverIPLabel);
                chatClient.serverInfoControls.Add(chatClient.myPortTextBox);
            }
            return chatClient;
        }

        public void ConnectToServer()
        {
            int attempts = 0;
            while(!socket.Connected) 
            { 
                if (attempts > 5) { return; }
                try
                {
                    attempts++;
                    SetChat("Connection Attempt: " + attempts);
                    socket.Connect(serverIP, serverPort);
                }
                catch(Exception ex)
                {
                    AddToChat("Error: " + ex.Message + "\n");
                }
                AddToChat("Connected!");

                // Hide the irrelevent information
                HideServerInformation();
                ModifyDisplayForChat();

                // Start the thread to receive data from the server.
                clientSocket.socket.BeginReceive(clientSocket.buffer, 0, ClientSocket.BUFFER_SIZE,
                                                SocketFlags.None, ReceiveCallback, clientSocket);
            }
        }

        // Every time data is receieved from the server, this function reads the data. 
        public void ReceiveCallback(IAsyncResult AR)
        {
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;

            int received;
            try
            {
                received = currentClientSocket.socket.EndReceive(AR);
            }
            catch(SocketException ex) 
            {
                AddToChat("Error: " + ex.Message);
                AddToChat("Disconnecting...");
                currentClientSocket.socket.Close();
                return;
            }

            byte[] recBuff = new byte[received];
            Array.Copy(currentClientSocket.buffer, recBuff, received);
            string text = Encoding.ASCII.GetString(recBuff);

            // The data at this point is likely a chat message. 
            // Send to chat unless it is not a chat message.
            AddToChat(text);

            // Start thread again to receive more data.
            currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0, ClientSocket.BUFFER_SIZE,
                                                SocketFlags.None, ReceiveCallback, currentClientSocket);

        }

        public void SendString(string text)
        {
            // Send data to the server.
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        public void Close()
        {
            socket.Close();
        }

        private void HideServerInformation()
        {
            clientForm.Invoke((MethodInvoker)(() =>
            {
                foreach (Control control in serverInfoControls)
                {
                    control.Hide();
                }
            }));
        }
        private void ModifyDisplayForChat()
        {
            // Change the size & position of the textbox & modify a label to display "Chat". 
            chatTextBox.Location = new Point(chatTextBox.Location.X, chatTextBox.Location.Y - 40);
            chatTextBox.Size = new Size(chatTextBox.Size.Width, chatTextBox.Size.Height + 40);
            myPortLabel.Text = "Chat";

            // Adjust the size and location of "Chat" 
            myPortLabel.SelectAll();
            myPortLabel.SelectionFont = new Font(myPortLabel.Font, FontStyle.Bold);
            myPortLabel.Location = new Point(myPortLabel.Location.X, myPortLabel.Location.Y + 5);
            myPortLabel.Size = new Size(myPortLabel.Size.Width, myPortLabel.Size.Height + 10);

            // Change the "Chat" font size 
            Font currentFont = myPortLabel.Font;
            Font newFont = new Font(currentFont.FontFamily, currentFont.Size + 6, currentFont.Style);
            myPortLabel.Font = newFont;

        }
    }
}
