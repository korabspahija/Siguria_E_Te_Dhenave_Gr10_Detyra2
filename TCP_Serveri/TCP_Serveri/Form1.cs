using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TCP_Serveri
{
    public partial class Serveri : Form
    {
        DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
        string key;
        string iv;
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
        private string encrypt(string plaintext, string key, string iv)
        {
            objDes.Key = Encoding.Default.GetBytes(key);
            objDes.IV = Encoding.Default.GetBytes(iv);
            objDes.Padding = PaddingMode.Zeros;
            objDes.Mode = CipherMode.CBC;


            byte[] bytePlaintexti = Encoding.UTF8.GetBytes(plaintext);

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, objDes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(bytePlaintexti, 0, bytePlaintexti.Length);
            cs.Close();

            byte[] byteCiphertexti = ms.ToArray();

            return Convert.ToBase64String(byteCiphertexti);

        }
        private string decrypt(string ciphertext)
        {
            string[] info = ciphertext.Split('.');
            key = info[1];
            iv = info[0];
            objDes.Key = Encoding.Default.GetBytes(info[1]);
            objDes.IV = Encoding.Default.GetBytes(info[0]);
            objDes.Padding = PaddingMode.Zeros;
            objDes.Mode = CipherMode.CBC;

            byte[] byteCiphertexti = Convert.FromBase64String(info[2]);
            MemoryStream ms = new MemoryStream(byteCiphertexti);
            CryptoStream cs = new CryptoStream(ms, objDes.CreateDecryptor(), CryptoStreamMode.Read);

            byte[] byteTextiDekriptuar = new byte[ms.Length];
            cs.Read(byteTextiDekriptuar, 0, byteTextiDekriptuar.Length);
            cs.Close();


            return Encoding.UTF8.GetString(byteTextiDekriptuar);
        }
        static public byte[] RSAEncryption(byte[] Data, RSAParameters RSAKey)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey); encryptedData = RSA.Encrypt(Data, false);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        
         public byte[] RSADecryption(byte[] Data, RSAParameters RSAKey)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, false);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
