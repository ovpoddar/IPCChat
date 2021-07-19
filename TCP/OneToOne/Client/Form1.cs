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

namespace Client
{
    public partial class Form1 : Form
    {
        private NetworkStream? _stream;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
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

        private void Connceting(IAsyncResult ar)
        {
            var tcpClient = (TcpClient?)ar.AsyncState;
            tcpClient.EndConnect(ar);
            Logging($"connected to {TxtIp.Text}:{TxtPort.Text}");
            _stream = tcpClient.GetStream();
            var buffer = new byte[tcpClient.ReceiveBufferSize];
            _stream.BeginRead(buffer, 0, buffer.Length, Reading, buffer);
        }

        private void Reading(IAsyncResult ar)
        {
            var buffer = (byte[]?)ar.AsyncState;
            var receved = _stream.EndRead(ar);
            if (receved == 0 || buffer == null)
            {
                return;
            }
            string message = Encoding.ASCII.GetString(buffer, 0, receved);
            Logging("Server: " + message);
            _stream.BeginRead(buffer, 0, buffer.Length, Reading, buffer);
        }

        private void Logging(string message)
        {
            Invoke(delegate
            {
                listBox1.Items.Add(message);
            });
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Logging("Client: " + TxtMessage.Text);
            _stream.Write(Encoding.ASCII.GetBytes(TxtMessage.Text));
            _stream.Flush();
        }
    }
}
