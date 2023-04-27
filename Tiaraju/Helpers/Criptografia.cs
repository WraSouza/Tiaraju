using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tiaraju.Helpers
{
    public class Criptografia
    {
        public static string CriptografaSenha(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(senha));

            byte[] result = md5.Hash;

            StringBuilder senhaCriptografada = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                senhaCriptografada.Append(result[i].ToString("x2"));
            }

            return senhaCriptografada.ToString();
        }
    }
}
