using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Pokesharp.Util {

    class Encryptor {

        public static string MD5(string str) {

            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++) {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();

        }

    }

}