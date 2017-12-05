using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PasswordHashing
    {

        public const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
        public static Random rnd = new Random();


        public PasswordHashing()
        {

        }

        public static string CryptPassword(string password)
        {
            string hashedPassword = "";
            using (MD5 md5 = MD5.Create())
            {
                StringBuilder builder = new StringBuilder();
                foreach (byte b in md5.ComputeHash(Encoding.UTF8.GetBytes(password)))
                {
                    builder.Append(b.ToString("x2").ToLower());
                }
                return hashedPassword = builder.ToString();
            }
        }

        public static string GenerateSalt(int length)
        {
            string result = "";

            for (int i = 0; i <= length; i++)
            {
                result += AllowedChars[rnd.Next(AllowedChars.Length - 1)];
            }
            return result;
        }
    }
}
