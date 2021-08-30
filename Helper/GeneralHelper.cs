using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Sistema_de_Calificaciones.Helper
{
    public class GeneralHelper
    {

        public static string EncriptarPassword(string pass)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var textSha = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                var sb = new StringBuilder(textSha.Length * 2);

                foreach(byte b in textSha)
                {
                    sb.Append(b.ToString());

                }
                return sb.ToString();
            }
        }

    }
}