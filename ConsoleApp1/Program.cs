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
            Employee e = db.GetEmployeeByUsername("MikkelP");


            Console.WriteLine("Hashed code: " + hashed + " " + "password from db: " + e.Password);
            Console.ReadLine();
        }
    }
}
