using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;

namespace C__Windows_Forms_Application
{
    public class ChatServer : ChatBase
    {
        public Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        // Connected Clients
        public List<ClientSocket> clientSockets = new List<ClientSocket>();

        // Helper Creator Function
        public static ChatServer CreateInstance(int port, TextBox chatTextBox)
        {
            ChatServer? chatServer = null;
            if (port > 0 && port < 65535 && chatTextBox != null) 
            { 
                chatServer = new ChatServer();
                chatServer.port = port;
                chatServer.chatTextBox = chatTextBox;
            }
            return chatServer;
        }

        public void SetupServer()
        {
            chatTextBox.Text += "Loading Server... \n";
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(0);
            // Start thread to read connected clients.
            serverSocket.BeginAccept(AcceptCallback, this);
            chatTextBox.Text += "Loading Complete...\n";
        }

        public void CloseAllSockets()
        {
            foreach(ClientSocket clientSocket in clientSockets) 
            {
                clientSocket.socket.Shutdown(SocketShutdown.Both);
                clientSocket.socket.Close();
            }
            clientSockets.Clear();
            serverSocket.Close();
        }

        public void AcceptCallback(IAsyncResult AR)
        {
            Socket joiningSocket;
            try
            {
                // Retreive the socket information from the connected client
                joiningSocket = serverSocket.EndAccept(AR); // Socket Data: Port & IP
            }
            catch (ObjectDisposedException) 
            {
                return;
            }
            ClientSocket newClientSocket = new ClientSocket();
            newClientSocket.socket = joiningSocket;
            clientSockets.Add(newClientSocket);

            // Start a thread to send and receive data between the server and the client. 
            joiningSocket.BeginReceive(newClientSocket.buffer, 0, 
                ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, newClientSocket);
            AddToChat("Client Connected. Ready to receive data...");

            // The new client is connected. We can allow another client to join. 
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        // This function is called every time data is received from a client.
        public void ReceiveCallback(IAsyncResult AR) 
        {
            // Retreive the ClientSocket from "IAsyncResult AR"
            ClientSocket currentClientSocket = (ClientSocket)AR.AsyncState;

            int received;
            // new line to test git
            try
            {
                received = currentClientSocket.socket.EndReceive(AR);
            }
            catch(SocketException ex)
            {
                AddToChat("Error: " + ex.Message);
                AddToChat("Disconnecting Client...");
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
                return;
            }
            // Build the byte array for the text 
            byte[] recBuf = new byte[received];
            Array.Copy(currentClientSocket.buffer, recBuf, received);
            // Convert the received byte data into a string
            string text = Encoding.ASCII.GetString(recBuf);

            AddToChat(text);
            // Check for commands before sending the string to the chat. 
            if (text.ToLower() == "!commands")
            {
                byte[] data = Encoding.ASCII.GetBytes("Commands: !commands !about !who !whisper !exit");
                currentClientSocket.socket.Send(data);
                AddToChat("Commands sent to: " + currentClientSocket.username);
            }
            else if (text.ToLower() == "!exit")
            {
                currentClientSocket.socket.Shutdown(SocketShutdown.Both);
                currentClientSocket.socket.Close();
                clientSockets.Remove(currentClientSocket);
                AddToChat(currentClientSocket.username + " disconnected...");
                return;
            }
            else
            {
                // Normal Chat Message
                SendToAll(currentClientSocket.username + ": " + text, currentClientSocket);
            }

            // Received the data from the current client, make a new thread to receive more data.
            currentClientSocket.socket.BeginReceive(currentClientSocket.buffer, 0,
               ClientSocket.BUFFER_SIZE, SocketFlags.None, ReceiveCallback, currentClientSocket);
        }

        public void SendToAll(string str, ClientSocket from)
        {
            // Send the message to all of the clients except the "from" client
            foreach(ClientSocket clientSocket in clientSockets)
            {
                if (from == null || !from.socket.Equals(clientSocket))
                {
                    byte[] data = Encoding.ASCII.GetBytes(str); // convert string to byte array
                    clientSocket.socket.Send(data);
                }
            }
        }
    }
}
