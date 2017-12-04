using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordHashing hashing = new PasswordHashing();
            string hashed = hashing.CryptPassword("");

            Console.WriteLine(hashed);
            Console.ReadLine();
        }
    }
}
