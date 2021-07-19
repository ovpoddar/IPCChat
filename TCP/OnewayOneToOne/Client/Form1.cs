using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tcpClient = new TcpClient();
            tcpClient.BeginConnect(IPAddress.Parse(TxtIp.Text), 45400, callBack, tcpClient);
        }

        private void callBack(IAsyncResult ar)
        {
            var tcpClient = (TcpClient)ar.AsyncState;
            var stream = tcpClient.GetStream();
            var text = Encoding.ASCII.GetBytes(TxtMessage.Text);
            stream.Write(text);
            stream.Flush();
        }
    }
}
