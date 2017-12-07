using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using RestSharp;

namespace ConsoleAppForTestingMailgun
{
    class Program
    {
        static void Main(string[] args)
        {
            MailSender mailSender = new MailSender();
            string subject = "test from console";
            string message = "test from the console text";
            mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, message, 1);
            Console.ReadKey();
        }
    }
}
