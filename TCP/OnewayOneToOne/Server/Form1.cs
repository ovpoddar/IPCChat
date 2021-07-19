using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
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

        private void BtnOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                var ipPort = GetIpPort();
                var tcpListener = new TcpListener(ipPort);
                tcpListener.Start();
                tcpListener.BeginAcceptTcpClient(Acceptstart, tcpListener);
                Invoke((Action)delegate
                {
                    listBox1.Items.Add($"port is activate on this address{ipPort.Address}{ipPort.Port}");
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Acceptstart(IAsyncResult ar)
        {
            var tcpListener = (TcpListener)ar.AsyncState;
            var user = tcpListener.EndAcceptTcpClient(ar);
            var buffer = new byte[user.ReceiveBufferSize];

            NetworkStream = user.GetStream();
            NetworkStream.BeginRead(buffer, 0, buffer.Length, readData, buffer);
        }


        void readData(IAsyncResult ar)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IPEndPoint GetIpPort()
        {
            var ip = string.IsNullOrWhiteSpace(TxtIp.Text) ? IPAddress.Any : IPAddress.Parse(TxtIp.Text);
            var port = 45400;
            return new IPEndPoint(ip, port);
        }
    }
}
