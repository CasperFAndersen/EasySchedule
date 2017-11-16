using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyScheduleWebClient.Models;

namespace EasyScheduleWebClient.Services
{
    public class EmployeeRepository
    {
        
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees = new EmployeeProxy().GetEmployeesByDepartment();
            return employees;
        }
    
        

    }


}