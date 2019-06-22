using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;
using System.Security.Cryptography;

namespace Server_TCP
{
    class ConnectionHandler
    {
        private Socket Klienti;
        private static int lidhjet = 0;
        private string eDhenaEardhur;
        RSACryptoServiceProvider objRsa = new RSACryptoServiceProvider();

        private  PasswordHash pswhash = new PasswordHash();

        public ConnectionHandler(Socket klienti)
        {
            this.Klienti = klienti;
        }

        public void HandleConnection()
        {
            try
            {
                lidhjet++;
                Console.WriteLine("U pranua klienti i ri: {0} lidhje aktive", lidhjet);
                SendData(DefaultFunctions());


                while (true)
                {
                    string mesazhiDekriptuar = ReceiveData().Substring(11);
                    Console.WriteLine(dekriptimiDES(mesazhiDekriptuar));

                    if (eDhenaEardhur.ToUpper().StartsWith("REGJISTRIMI"))
                    {
                        int poz = eDhenaEardhur.IndexOf(" ");
                        string command = eDhenaEardhur.Substring(0, poz);
                        string sjson = eDhenaEardhur.Substring(poz + 1);

                        if (command.ToUpper() == "REGJISTRIMI")
                        {
                            SendData(Regjistrimi(sjson));
                        }
                        else
                        {
                            SendData("Operacioini nuk eshte valid!");

                        }
                    }
                }
            }
            catch (Exception)
            {
                lidhjet--;
            }
        }

        private void SendData(string data)
        {
           this.Klienti.Send(Encoding.ASCII.GetBytes(data));
        }

        private string ReceiveData()
        {
            byte[] data = new byte[512];
            int recv = this.Klienti.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            eDhenaEardhur = stringData;
            return stringData;
        }

        private string DefaultFunctions()
        {
            string allFunctions = "\n";
            return allFunctions;
        }

        //Metodat
        private string Regjistrimi(string sjson)
        {
            string return_value = "";
            bool UserExist = false;
            try
            {
                //Studentet studenti = JsonConvert.DeserializeObject<Studentet>(sjson);
                Studentet studenti = JsonConvert.DeserializeObject<Studentet>(sjson);
                string Hashpassword = pswhash.CreateHash(studenti.PasswordHash);
                studenti.PasswordHash = Hashpassword;

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
                return_value = "Te dhenat jane pranuar me sukses";
            }

            return return_value;
        }
        ///DES DEKRIPTIMI/////
        private string dekriptimiDES(string tekstiPerDekriptim)
        {
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            objDES.Key = Encoding.UTF8.GetBytes("12345678");
            objDES.IV = Encoding.UTF8.GetBytes("12345678");
            objDES.Padding = PaddingMode.Zeros;
            objDES.Mode = CipherMode.CBC;

            byte[] byteCiphertexti = Convert.FromBase64String(tekstiPerDekriptim);
            MemoryStream ms = new MemoryStream(byteCiphertexti);

            byte[] byteTextiDekriptuar = new byte[ms.Length];
            CryptoStream cs =
                new CryptoStream(ms,
                        objDES.CreateDecryptor(),
                        CryptoStreamMode.Read);
            cs.Read(byteTextiDekriptuar, 0, byteTextiDekriptuar.Length);
            cs.Close();

            return Encoding.UTF8.GetString(byteTextiDekriptuar);
        }
    }
}
