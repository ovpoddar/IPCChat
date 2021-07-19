using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public NetworkStream NetworkStream { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Server = new TcpListener(new IPEndPoint(IPAddress.Parse(TxtIp.Text), int.Parse(TxtPort.Text)));
            Server.Start();
            Server.BeginAcceptTcpClient(Acceptstart, Server);
        }
        private void Acceptstart(IAsyncResult ar)
        {
            var Server = (TcpListener)ar.AsyncState;
            var user = Server.EndAcceptTcpClient(ar);
            var buffer = new byte[user.ReceiveBufferSize];

            NetworkStream =user.GetStream();
            NetworkStream.BeginRead(buffer, 0, buffer.Length, readData, buffer);
            Server.BeginAcceptTcpClient(Acceptstart, Server);
        }


        void readData(IAsyncResult ar)
        {
            var buffer = (byte[])ar.AsyncState;
            var received = NetworkStream.EndRead(ar);
            if (received == 0 || buffer == null)
                return; 
            var message = Encoding.ASCII.GetString(buffer, 0, received);
            Invoke((Action)delegate
            {
                listBox1.Items.Add(message);
            });
            NetworkStream.BeginRead(buffer, 0, buffer.Length, readData, null);
        }
    }
}
