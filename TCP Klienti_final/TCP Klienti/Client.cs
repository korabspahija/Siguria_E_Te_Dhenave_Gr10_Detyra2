using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Security.Cryptography;

namespace TCP_Klienti
{
    public partial class Client : Form
    {

        RSACryptoServiceProvider objRsa = new RSACryptoServiceProvider();
        public static Socket server;
        static string receivedData;
        private string IP_Address = "";
        private int PortNo = 0;
        private bool Connected;
        public Client()
        {
            InitializeComponent();
            this.MinimizeBox = false;
        }
        private void SendDataToServer(string data)
        {
            server.Send(Encoding.ASCII.GetBytes(data));
        }

        private string ReceiveDataFromServer()
        {
            byte[] data = new byte[512];
            int recv_data = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, recv_data);
            receivedData = stringData;
            return stringData;
        }
        private void SendRequestToSrv(string teksti)
        {
            try
            {
                server.Send(Encoding.ASCII.GetBytes(teksti));
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message.ToString());
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[512];

            if (txtIP.Text.Trim() != "" && txtPorti.Text.Trim() != "")
            {
                IP_Address = txtIP.Text.Trim();
                PortNo = Convert.ToInt32(txtPorti.Text.Trim());

                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP_Address), PortNo);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    server.Connect(ipep);

                    txtReceiveAnswer.AppendText("Jeni të lidhur me serverin:" + txtIP.Text + " dhe Portin: " + txtPorti.Text + "\n");
                    BWchatLog.RunWorkerAsync();
                    txtReceiveAnswer.AppendText("\n\n" + ReceiveDataFromServer());
                    Connected = true;
                }
                catch (SocketException ex)
                {
                    txtReceiveAnswer.AppendText("E pamundur që të lidheni me server. Ju lutem kontrolloni IP adresen dhe portin!");
                    txtReceiveAnswer.AppendText("\n" + ex.ToString());
                    Connected = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please fill IP Address and/or Port first!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Connected)
                MessageBox.Show("Duhet të lidheni me server!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                try
                {
                    Studenti student = new Studenti();
                    student.emriMbiemri = txtEmriMbiemri.Text.Trim();
                    student.email = txtEmail.Text.Trim();
                    student.notaMesatare = Convert.ToDecimal(txtNotaMesatare.Text.Trim());
                    student.userId = txtUserName.Text.Trim();
                    student.lendaPreferuar = txtLendaPreferuar.Text.Trim();
                    student.PasswordHash = txtPassword.Text.Trim();


                    string json = JsonConvert.SerializeObject(student);
                    string SendCommand = "Regjistrimi " + enkriptimiDES(json);                    
                    SendRequestToSrv(SendCommand);

                    txtReceiveAnswer.AppendText("\n");
                    txtReceiveAnswer.Refresh();
                    txtReceiveAnswer.AppendText("\n" + ReceiveDataFromServer());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }   

        }

        private void Client_Load(object sender, EventArgs e)
        {

        }
        ///DES ENKRIPTIMI/////
        private string enkriptimiDES(string tekstiPerEnkriptim)
        {
            DESCryptoServiceProvider objDES =
                new DESCryptoServiceProvider();
            objDES.Key = Encoding.UTF8.GetBytes("12345678");
            objDES.IV = Encoding.UTF8.GetBytes("12345678");
            objDES.Padding = PaddingMode.Zeros;
            objDES.Mode = CipherMode.CBC;

            byte[] bytePlaintext =
                Encoding.UTF8.GetBytes(tekstiPerEnkriptim);
            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms,
                                objDES.CreateEncryptor(),
                                CryptoStreamMode.Write);
            cs.Write(bytePlaintext, 0, bytePlaintext.Length);
            cs.Close();

            byte[] byteCiphertexti = ms.ToArray();
            return Convert.ToBase64String(byteCiphertexti);
            //Encoding.UTF8.GetString(byteCiphertexti);

        }
    }
}
