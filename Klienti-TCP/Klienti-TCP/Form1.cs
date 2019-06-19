using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klienti_TCP
{
    public partial class Klienti : Form
    {
        public Klienti()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;

        private void Klienti_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            //Connect to server
            client.Connect("127.0.0.1", 2020);
        }
        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            //Update message to txtStatus
            txtMesazhi.Invoke((MethodInvoker)delegate()
            {
                txtMesazhi.Text += e.MessageString;
            });
        }

        private void BtnRuaj_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(txtEmri.Text, TimeSpan.FromSeconds(3));
        }
    }
}
