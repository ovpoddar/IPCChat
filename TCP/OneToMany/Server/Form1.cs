using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private readonly List<byte[]> _clientsData = new List<byte[]>();
        private readonly List<NetworkStream> _clientStreams = new List<NetworkStream>();
        private int _currentAdded;

        public Form1()
        {
            InitializeComponent();
        }


        private IPEndPoint GetIpPort()
        {
            var ip = string.IsNullOrWhiteSpace(TxtIp.Text) ? IPAddress.Any : IPAddress.Parse(TxtIp.Text);
            var port = string.IsNullOrWhiteSpace(TxtPort.Text) ? 100 : int.Parse(TxtPort.Text);
            return new IPEndPoint(ip, port);
        }

        private void BtnOpenPort_Click(object sender, EventArgs e)
        {
            var port = GetIpPort();
            var tcpListener = new TcpListener(port);
            tcpListener.Start();

            Logging($"port is activate on this address{port.Address}:{port.Port}");
            tcpListener.BeginAcceptTcpClient(AcceptClients, tcpListener);
        }

        private void AcceptClients(IAsyncResult ar)
        {
            var tcpListener = (TcpListener)ar.AsyncState;
            var newMember = tcpListener.EndAcceptTcpClient(ar);
            var buffer = new byte[newMember.ReceiveBufferSize];

            var stream = newMember.GetStream();
            _clientsData.Add(buffer);
            _clientStreams.Add(stream);
            _currentAdded = _clientStreams.Count - 1;

            var message = Encoding.ASCII.GetBytes(" connected", 0, 10);



            stream.BeginWrite(message, 0, message.Length, SendData, null);
            stream.BeginRead(buffer, 0, buffer.Length, DataReceived, null);
            Invoke((Action)delegate
            {
                dataGridView1.Rows.Add(newMember.Client.AddressFamily, newMember.Available);
            });
            tcpListener.BeginAcceptTcpClient(AcceptClients, tcpListener);
        }

        private void SendData(IAsyncResult ar)
        {
            _clientStreams[_currentAdded].EndWrite(ar);
        }

        private void DataReceived(IAsyncResult ar)
        {
            var receved = _clientStreams[_currentAdded].EndRead(ar);
            if (receved == 0)
            {
                return;
            }
            string message = Encoding.ASCII.GetString(_clientsData[_currentAdded], 0, receved);
            Logging(message);
            _clientStreams[_currentAdded].BeginRead(_clientsData[_currentAdded], 0, _clientsData[_currentAdded].Length, DataReceived, null);
        }

        void Logging(string message)
        {
            Invoke(new MethodInvoker(() =>
            {
                listBox1.Items.Add(message);
            }));
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Logging("Me(server): " + TxtMessage.Text);
            _clientStreams[int.Parse(TxtIndex.Text)].Write(Encoding.ASCII.GetBytes(TxtMessage.Text));
            _clientStreams[int.Parse(TxtIndex.Text)].Flush();
        }
    }
}
