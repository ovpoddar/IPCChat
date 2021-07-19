using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Socket Server { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1000));
            Server.Listen(10);
            Server.BeginAccept(Acceptstart, null);
        }
        private void Acceptstart(IAsyncResult ar)
        {
            var user = Server.EndAccept(ar);
            var buffer = new byte[user.ReceiveBufferSize];
            user.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, senddata, null);

            void senddata(IAsyncResult ar)
            {
                var received = user.EndReceive(ar);
                if (received == 0)
                    return;
                var message = Encoding.ASCII.GetString(buffer, 0, received);
                Invoke((Action)delegate
                {
                    listBox1.Items.Add(message);
                });
                user.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, senddata, null);
            }
            Server.BeginAccept(Acceptstart, null);
        }
    }
}
