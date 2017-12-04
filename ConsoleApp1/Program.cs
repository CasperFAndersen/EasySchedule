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
            Employee e = db.GetEmployeeByUsername("MikkelP");


            Console.WriteLine("Hashed code 1: " + hashed + " " + 
                              "Hashed code 2: " + hased2 + " " +  
                              "password from db: " + e.Password);
            Console.ReadLine();
        }
    }
}
