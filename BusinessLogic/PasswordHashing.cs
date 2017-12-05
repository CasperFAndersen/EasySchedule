using System;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic
{
    public class PasswordHashing
    {
        public const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
        public static Random Random = new Random();

        public static string HashPassword(string password)
        {
            StringBuilder builder = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                foreach (byte b in md5.ComputeHash(Encoding.UTF8.GetBytes(password)))
                {
                    builder.Append(b.ToString("x2").ToLower());
                }
                return builder.ToString();
            }
        }

        public static string GenerateSalt(int length)
        {
            string result = "";

            for (int i = 0; i <= length; i++)
            {
                result += AllowedChars[Random.Next(AllowedChars.Length - 1)];
            }
            return result;
        }
    }
}
