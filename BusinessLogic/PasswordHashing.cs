using System;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic
{
    public class PasswordHashing
    {
        public const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
        public static Random Random = new Random();

        /// <summary>
        /// This method uses the MD5 from VisualStudios to hash passwords.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>
        /// Returns a hashed string.
        /// </returns>
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

        public static string GenerateSalt()
        {
            string result = "";

            for (int i = 0; i <= 10; i++)
            {
                result += AllowedChars[Random.Next(AllowedChars.Length - 1)];
            }
            return result;
        }
    }
}
