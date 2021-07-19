using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private NetworkStream? _stream;
        private string _name = string.Empty;

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
                    var tcpClient = new TcpClient();
                    tcpClient.BeginConnect(IPAddress.Parse(TxtIp.Text), int.Parse(TxtPort.Text), Connceting, tcpClient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Connceting(IAsyncResult ar)
        {
            var tcpClient = (TcpClient?)ar.AsyncState;
            tcpClient.EndConnect(ar);
            Logging($"connected to {TxtIp.Text}:{TxtPort.Text}");
            _stream = tcpClient.GetStream();
            var buffer = new byte[tcpClient.ReceiveBufferSize];
            _stream.BeginRead(buffer, 0, buffer.Length, DataReceved, buffer);
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
            var buffer = (byte[]?)ar.AsyncState;
            var receved = _stream.EndRead(ar);
            if (receved == 0 || buffer == null)
            {
                return;
            }
            string message = Encoding.ASCII.GetString(buffer, 0, receved);
            Logging("Server: " + message);
            _stream.BeginRead(buffer, 0, buffer.Length, DataReceved, buffer);
        }


        private void BtnSend_Click(object sender, EventArgs e)
        {
            Logging("Client: " + TxtMessage.Text);
            _stream.Write(Encoding.ASCII.GetBytes(TxtMessage.Text));
            _stream.Flush();
        }
    }
}
