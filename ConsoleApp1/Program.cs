using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess;
using BusinessLogic;
using DatabaseAccess.Employees;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository db = new EmployeeRepository();
            string hashed = PasswordHashing.CryptPassword("hardToCrack");
            string hased2 = PasswordHashing.CryptPassword("HardToCrack");
            string froberg = PasswordHashing.CryptPassword("hejhej");
            string arne = PasswordHashing.CryptPassword("JegErUngOgVildEndnu");
            string tobias = PasswordHashing.CryptPassword("CanYouGuessMyPass");
            string stefan = PasswordHashing.CryptPassword("ItsaHardHardLife");
            Employee e = db.GetEmployeeByUsername("MikkelP");

            Console.WriteLine("Hashed code 1: " + hashed + "\n" +
                              "Hashed code 2: " + hased2 + "\n" +
                              "DbHashed code: " + e.Password);
            Console.WriteLine("Froberg: " + froberg);
            Console.WriteLine("Arne : " + arne);
            Console.WriteLine("Tobias: " + tobias);
            Console.WriteLine("Stefan: " + stefan);
            Console.ReadLine();
        }
    }
}
