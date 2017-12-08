using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Core;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ScheduleShift shift = new ScheduleShift()
            {
                Employee = new Employee
                {
                    Id = 1,
                    DepartmentId = 1,
                    IsAdmin = true,
                    IsEmployed = true,
                    Mail = "hej@hej.dk",
                    Name = "Mikkel Paulsen",
                    NumbOfHours = 10,
                    Password = "hardToCrack",
                    Phone = "12312323",
                    Salt = "jadkfa",
                    Username = "MikkelP"
                },
                Hours = 10,
                Id = 1,
                IsForSale = true,
                StartTime = new DateTime(2017, 10, 30, 10, 20, 00)
            };
            MailSender mailSender = new MailSender();
            string subject = "A new shift has been set for sale";
            string text = shift.Employee.Name + " has set a shift starting " + shift.StartTime + " and has a length of " + shift.Hours + " hours for sale.";
            mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, shift.Employee.DepartmentId);

            Console.ReadKey();
        }
    }
}
