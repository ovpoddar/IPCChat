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
        private NetworkStream? _stream;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOpenport_Click(object sender, EventArgs e)
        {
            try
            {
                var ipPort = GetIpPort();
                var tcpListener = new TcpListener(ipPort);
                tcpListener.Start();
                tcpListener.BeginAcceptTcpClient(AcceptClient, tcpListener);
                logging($"port is activate on this address{ipPort.Address}{ipPort.Port}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private IPEndPoint GetIpPort()
        {
            var ip = string.IsNullOrWhiteSpace(TxtIp.Text) ? IPAddress.Any : IPAddress.Parse(TxtIp.Text);
            var port = string.IsNullOrWhiteSpace(TxtPort.Text) ? 100 : int.Parse(TxtPort.Text);
            return new IPEndPoint(ip, port);
        }


        private void AcceptClient(IAsyncResult ar)
        {
            var tcpListener = (TcpListener?)ar.AsyncState;
            var tcpClient = tcpListener.EndAcceptTcpClient(ar);
            var buffer = new byte[tcpClient.ReceiveBufferSize];

            _stream = tcpClient.GetStream();
            var message = Encoding.ASCII.GetBytes(" connected", 0, 10);
            _stream.BeginWrite(message, 0, message.Length, SendData, null);
            _stream.BeginRead(buffer, 0, buffer.Length, DataReceived, buffer);
            tcpListener.BeginAcceptTcpClient(AcceptClient, tcpListener);
        }

        private void SendData(IAsyncResult ar)
        {
            _stream.EndWrite(ar);
            _stream.Flush();
        }

        private void DataReceived(IAsyncResult ar)
        {
            var buffer =(byte[]?)ar.AsyncState;
            var receved = _stream.EndRead(ar);
            if (receved == 0 || buffer == null)
            {
                return;
            }
            string message = Encoding.ASCII.GetString(buffer, 0, receved);
            logging("Client: " + message);
            _stream.BeginRead(buffer, 0, buffer.Length, DataReceived, buffer);
        }

        void logging(string message)
        {
            Invoke((Action)delegate
            {
                listBox1.Items.Add(message);
            });
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            logging("Server: " + TxtMessage.Text);
            _stream.Write(Encoding.ASCII.GetBytes(TxtMessage.Text));
            _stream.Flush();
        }

    }
}
