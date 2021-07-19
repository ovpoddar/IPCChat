using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private Socket _sarverSocket;
        private Socket _clientSocket;
        private byte[] _buffer;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOpenport_Click(object sender, EventArgs e)
        {
            try
            {
                _sarverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var port = GetIpPort();
                _sarverSocket.Bind(port);
                _sarverSocket.Listen(10);
                _sarverSocket.BeginAccept(AcceptClient, null);
                logging($"port is activate on this address{port.Address}{port.Port}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AcceptClient(IAsyncResult ar)
        {
            _clientSocket = _sarverSocket.EndAccept(ar);
            _buffer = new byte[_clientSocket.ReceiveBufferSize];

            var message = Encoding.ASCII.GetBytes(" connected", 0, 10);
            _clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, SendData, null);
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, DataReceived, null);
            _sarverSocket.BeginAccept(AcceptClient, null);
        }

        private void DataReceived(IAsyncResult ar)
        {
            var receved = _clientSocket.EndReceive(ar);
            if (receved == 0)
            {
                return;
            }
            string message = Encoding.ASCII.GetString(_buffer, 0, receved);
            logging("Client: " + message);
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, DataReceived, null);
        }

        private void SendData(IAsyncResult ar)
        {
            _clientSocket.EndSend(ar);
        }

        void logging(string message)
        {
            Invoke((Action)delegate
            {
                listBox1.Items.Add(message);
            });
        }

        private IPEndPoint GetIpPort()
        {
            var ip = string.IsNullOrWhiteSpace(TxtIp.Text) ? IPAddress.Any : IPAddress.Parse(TxtIp.Text);
            var port = string.IsNullOrWhiteSpace(TxtPort.Text) ? 100 : int.Parse(TxtPort.Text);
            return new IPEndPoint(ip, port);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            logging("Server: " + TxtMessage.Text);
            _clientSocket.Send(Encoding.ASCII.GetBytes(TxtMessage.Text));
        }
    }
}
