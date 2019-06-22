using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Server_TCP
{
    class X509
    {
        public static byte[] merrCelesinPublik()
        {
            //string Certificate = "C:\\Users\\PC\\Desktop\\Certifikata_X509\\CertifikataX509.pfx";
            string Certificate = "CertifikataX509.pfx";
            X509Certificate2 cert = new X509Certificate2(File.ReadAllBytes(Certificate), "12345678", X509KeyStorageFlags.MachineKeySet);

            byte[] celesipublik = cert.GetPublicKey();
            //string result = System.Convert.ToBase64String(celesipublik)    

            return cert.GetPublicKey();
        }

    }
}
