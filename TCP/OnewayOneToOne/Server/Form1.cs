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

        private void Acceptstart(IAsyncResult ar)
        {
            var tcpListener = (TcpListener)ar.AsyncState;
            var user = tcpListener.EndAcceptTcpClient(ar);
            var buffer = new byte[user.ReceiveBufferSize];

            NetworkStream =user.GetStream();
            NetworkStream.BeginRead(buffer, 0, buffer.Length, readData, buffer);
            tcpListener.BeginAcceptTcpClient(Acceptstart, tcpListener);
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
            NetworkStream.BeginRead(buffer, 0, buffer.Length, readData, buffer);
        }


        private void BtnOpenPort_Click(object sender, EventArgs e)
        {
            var ipPort = GetIpPort();
            var tcpListener = new TcpListener(ipPort);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(Acceptstart, tcpListener);
        }


        private IPEndPoint GetIpPort()
        {
            var ip = string.IsNullOrWhiteSpace(TxtIp.Text) ? IPAddress.Any : IPAddress.Parse(TxtIp.Text);
            var port = 45400;
            return new IPEndPoint(ip, port);
        }
    }
}
