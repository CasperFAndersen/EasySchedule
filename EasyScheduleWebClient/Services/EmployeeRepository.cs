using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyScheduleWebClient.Models;

namespace EasyScheduleWebClient.Services
{
    public class EmployeeRepository
    {
        
        public IEnumerable<Employee> GetEmployess()
        {
            Employee e1 = new Employee()
            {
                EmployeeID = 1,
                Name = "Casper"
            };
            Employee e2 = new Employee()
            {
                EmployeeID = 2,
                Name = "Stefan"
            };
            Employee e3 = new Employee()
            {
                EmployeeID = 3,
                Name = "Mikkel"
            };
            Employee e4 = new Employee()
            {
                EmployeeID = 4,
                Name = "Tobias"
            };
            Employee e5 = new Employee()
            {
                EmployeeID = 5,
                Name = "Arne"
            };


            List<Employee> emps = new List<Employee>();
            emps.Add(e1);
            emps.Add(e2);
            emps.Add(e3);
            emps.Add(e4);
            emps.Add(e5);

            return emps;
        }
    
        

    }


}