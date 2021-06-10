using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private Socket _clientSocket;
        private byte[] _buffer;
        private string _name;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("provide name to connect");
                return;
            }
            else
            {
                _name = TxtName.Text;
                TxtName.Hide();
                TxtPort.Width = 200;
                try
                {
                    _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    _clientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse(TxtIp.Text), int.Parse(TxtPort.Text)), this.Connceting, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Connceting(IAsyncResult ar)
        {
            _clientSocket.EndConnect(ar);
            Logging($"connected to {TxtIp.Text}:{TxtPort.Text}");
            _buffer = new byte[_clientSocket.ReceiveBufferSize];
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, DataReceved, null);
        }

        private void Logging(string message)
        {
            Invoke((Action)delegate
            {
                listBox1.Items.Add(message);
            });
        }

        private void DataReceved(IAsyncResult ar)
        {
            var receved = _clientSocket.EndReceive(ar);
            if (receved == 0)
            {
                return;
            }
            string message = Encoding.ASCII.GetString(_buffer, 0, receved);
            Logging("Server: " + message);
            _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, DataReceved, null);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Logging($"{_name}: {TxtMessage.Text}");
            _clientSocket.Send(Encoding.ASCII.GetBytes($"{_name}: {TxtMessage.Text}"));
        }
    }
}
