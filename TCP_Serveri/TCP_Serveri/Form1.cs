using Newtonsoft.Json;
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
        private PasswordHash pswhash = new PasswordHash();
        RNGCryptoServiceProvider RNGprovider = new RNGCryptoServiceProvider();
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
                //Korab Spahija 8
            

              string[] mesazhiArray = e.MessageString.Split(' ');
                txtMesazhi.Text += e.MessageString;
                Studentet studenti = new Studentet();
                studenti.emri = mesazhiArray[0];
                studenti.mbiemri = mesazhiArray[1];
                studenti.notaMesatare = mesazhiArray[2];
                studenti.email = mesazhiArray[3];
                studenti.userId = mesazhiArray[4];
                studenti.PasswordHash = pswhash.CreateHash(mesazhiArray[5]);
                studenti.lendaPreferuar = mesazhiArray[6];
                string path = "Studentet.json";
                string json = JsonConvert.SerializeObject(studenti);
                Regjistrimi(json);
                e.ReplyLine(string.Format("You said: {0}", mesazhiArray));
                
            });
        }
        
        

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Start server host
            txtMesazhi.Text += "Server starting...";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("127.0.0.1");
            server.Start(ip, 2020);
        }
        private string Regjistrimi(string sjson)
        {
            string return_value = "";
            bool UserExist = false;
            try
            {

                //Studentet studenti = JsonConvert.DeserializeObject<Studentet>(sjson);
                Studentet studenti = JsonConvert.DeserializeObject<Studentet>(sjson);
                           
                string path = "Studentet.json";
                if (File.Exists(path))
                {
                    sjson = File.ReadAllText(path);
                    if (String.IsNullOrEmpty(sjson))
                    {
                        List<Studentet> lstStudentet = new List<Studentet>();
                        lstStudentet.Add(studenti);
                        File.WriteAllText(path, JsonConvert.SerializeObject(lstStudentet), Encoding.UTF8);
                    }
                    else
                    {
                        List<Studentet> lstStudentet = JsonConvert.DeserializeObject<List<Studentet>>(sjson);
                        foreach (Studentet item in lstStudentet)
                        {
                            if (item.userId == studenti.userId)
                            {
                                return_value = "ERROR - Ekziston sudenti me username :" + studenti.userId;
                                UserExist = true;
                                break;
                            }
                        }
                        if (!UserExist)
                        {
                            lstStudentet.Add(studenti);
                            File.WriteAllText(path, JsonConvert.SerializeObject(lstStudentet), Encoding.UTF8);
                            return_value = "OK - Jeni regjistruar me sukses me username " + studenti.userId;
                        }
                    }
                }
                else
                {
                    List<Studentet> lstStudentit = new List<Studentet>();
                    lstStudentit.Add(studenti);
                    File.WriteAllText(path, JsonConvert.SerializeObject(lstStudentit), Encoding.UTF8);
                    return_value = "OK - Jeni regjistruar me sukses me username " + studenti.userId;
                }
            }
            catch (Exception ex)
            {
                return_value = ex.Message;
            }

            return return_value;
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
   
