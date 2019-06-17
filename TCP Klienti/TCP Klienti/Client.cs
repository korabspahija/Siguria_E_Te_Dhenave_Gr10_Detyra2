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
using System.IO;
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

        protected bool ValidateEmail(TextBox txtEmail, ErrorProvider errorProvider1)
        {
            bool bStatus = true;

            string email = txtEmail.Text.TrimEnd();

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                errorProvider1.SetError(txtEmail, "");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "Invalid Email!");
                bStatus = false;
            }
            return bStatus;
        }

        protected bool ValidateField(TextBox textbox, string Errormsg, ErrorProvider errorProvider1)
        {

            bool bStatus = true;

            if (textbox.Text == "")
            {
                errorProvider1.SetError(textbox, Errormsg);
                bStatus = false;
            }
            else
            {
                errorProvider1.SetError(textbox, "");
            }
            return bStatus;
        }

        protected void AllowOnlyNumeric(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Connected)
                MessageBox.Show("Duhet të lidheni me server!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            bool bValidEmriMbiemri = ValidateField(txtEmriMbiemri, "Emri Mbiemri duhet të shënohet!", errorProvider1);
            bool bValidEmail = ValidateEmail(txtEmail, errorProvider1);
            bool bValidLendaPreferuar = ValidateField(txtLendaPreferuar, "Lenda e preferuar duhet të shënohet!", errorProvider1);
            bool bValidNotaMesatare = ValidateField(txtNotaMesatare, "Nota mesatare duhet të shënohet!", errorProvider1);
            bool bValidUserName = ValidateField(txtUserName, "UserName-i duhet të shënohet!", errorProvider1);
            bool bValidPassword = ValidateField(txtPassword, "Pasword-i duhet të shënohet!", errorProvider1);

            if (!bValidEmriMbiemri || !bValidEmail || !bValidLendaPreferuar || !bValidNotaMesatare || !bValidUserName || !bValidPassword)
                MessageBox.Show("Të dhënat janë jo valide!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    
                    string SendCommand =  json;                    
                    SendRequestToSrv("Regjistrimi " + DesEnkriptimi(SendCommand));

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

        private void txtPaga_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumeric(sender, e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Connected)
                MessageBox.Show("Duhet të lidheni me server!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            bool bValidUserName = ValidateField(txtUserName1, "UserName-i duhet të shënohet!", errorProvider1);
            bool bValidPassword = ValidateField(txtPassword1, "Pasword-i duhet të shënohet!", errorProvider1);

            if (!bValidUserName || !bValidPassword)
                MessageBox.Show("Të dhënat janë jo valide!", "Vërejtje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                try
                {
                    Login login = new Login();
                    login.userId = txtUserName1.Text.Trim();
                    login.PasswordHash = txtPassword1.Text.Trim();
                    string json = JsonConvert.SerializeObject(login);
                    string SendCommand = "Authentifikimi " + json;
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
        private string DesEnkriptimi(string tekstiPerEnkriptim)
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
