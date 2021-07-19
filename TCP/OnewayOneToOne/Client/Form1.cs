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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Parse(TxtIp.Text), int.Parse(TxtPort.Text);
            var stream = tcpClient.GetStream();
            stream.Write(Encoding.ASCII.GetBytes(TxtMessage.Text));
            stream.Flush();
            stream.Close();            
        }
    }
}
