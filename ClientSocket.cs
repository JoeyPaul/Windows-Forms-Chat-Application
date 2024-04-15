using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace C__Windows_Forms_Application
{
    public class ClientSocket
    {
        public string username = "";
        public Socket? socket; // Port/IP
        public const int BUFFER_SIZE = 2048;
        public byte[] buffer = new byte[BUFFER_SIZE];
    }
}
