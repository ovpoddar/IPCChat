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
        private Socket _serverSocket;
        private List<byte[]> _clientsData = new List<byte[]>();
        private List<Socket> _clientsSocket = new List<Socket>();
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
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var port = GetIpPort();
            _serverSocket.Bind(port);
            Logging($"port is activate on this address{port.Address}:{port.Port}");
            _serverSocket.Listen(10);
            _serverSocket.BeginAccept(AcceptClients, null);
        }

        private void AcceptClients(IAsyncResult ar)
        {
            var newMember = _serverSocket.EndAccept(ar);
            var buffer = new byte[newMember.ReceiveBufferSize];

            _clientsSocket.Add(newMember);
            _clientsData.Add(buffer);
            _currentAdded = _clientsSocket.Count - 1;

            var message = Encoding.ASCII.GetBytes(" connected", 0, 10);

            newMember.BeginSend(message, 0, message.Length, SocketFlags.None, SendData, null);
            newMember.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, DataReceived, null);
            Invoke((Action)delegate
            {
                dataGridView1.Rows.Add(newMember.AddressFamily, newMember.Available);
            });

            _serverSocket.BeginAccept(AcceptClients, null);
        }

        private void SendData(IAsyncResult ar)
        {
            _clientsSocket[_currentAdded].EndSend(ar);
        }

        private void DataReceived(IAsyncResult ar)
        {
            var receved = _clientsSocket[_currentAdded].EndReceive(ar);
            if (receved == 0)
            {
                return;
            }
            string message = Encoding.ASCII.GetString(_clientsData[_currentAdded], 0, receved);
            Logging(message);
            _clientsSocket[_currentAdded].BeginReceive(_clientsData[_currentAdded], 0, _clientsData[_currentAdded].Length, SocketFlags.None, DataReceived, null);
        }

        void Logging(string message)
        {
            Invoke((Action)delegate
            {
                listBox1.Items.Add(message);
            });
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Logging("Me(server): " + TxtMessage.Text);
            _clientsSocket[int.Parse(TxtIndex.Text)].Send(Encoding.ASCII.GetBytes(TxtMessage.Text));
        }
    }
}
