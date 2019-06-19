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

namespace Klienti_TCP
{
    public partial class Klienti : Form
    {
        public static string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
       
        string key=GetUniqueKey(4); 
        string iv=GetUniqueKey(4);

        string[] sendingArray = new string[7]; 

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

            sendingArray[0] = txtEmri.Text;
            sendingArray[1] = txtMbiemri.Text;
            sendingArray[2] = txtNotaMesatare.Text;
            sendingArray[3] = txtEmail.Text;
            sendingArray[4] = txtUsername.Text;
            sendingArray[5] = txtPassword.Text;
            sendingArray[6] = txtLendaPreferuar.Text;

            string test = string.Join(" ", sendingArray);
            string test1 = DESencrypt(test,key,iv);
            client.WriteLineAndGetReply(test1, TimeSpan.FromSeconds(3));
        }
        private string DESencrypt(string plaintext, string key, string iv)
        {
            objDes.Key = RSAEncryption(Encoding.Default.GetBytes(key),);
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
        private string DESdecrypt(string ciphertext)
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
