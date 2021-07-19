using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (!socket.Connected)
                socket.Connect(IPAddress.Parse("127.0.0.1"), 1000);
            socket.Send(Encoding.ASCII.GetBytes("hlw"));
            socket.Dispose();
        }
    }
}
