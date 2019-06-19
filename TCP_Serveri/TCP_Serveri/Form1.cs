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


namespace TCP_Serveri
{
    public partial class Serveri : Form
    {
        public Serveri()
        {
            InitializeComponent();
        }
        SimpleTcpServer server;
        private void Serveri_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            //Update mesage to txtStatus
            txtMesazhi.Invoke((MethodInvoker)delegate ()
            {
                txtMesazhi.Text += e.MessageString;
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }
        
        

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Start server host
            txtMesazhi.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            server.Start(ip, Convert.ToInt32(2020));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();  
        }

    }
}
