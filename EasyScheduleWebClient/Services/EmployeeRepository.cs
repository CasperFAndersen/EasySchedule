using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyScheduleWebClient.Models;
using Core;

namespace EasyScheduleWebClient.Services
{
    public class EmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeesByDepartmentId(int id)
        {
            List<Employee> employees = new List<Employee>();
            employees = new EmployeeProxy().GetEmployeesByDepartmentId(id);
            return employees;
        }
    }
}