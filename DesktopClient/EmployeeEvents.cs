using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.Services;

namespace DesktopClient
{
    class EmployeeEvents
    {

        public List<Employee> GetListOfEmployees(Department department)
        {
            EmployeeProxy empProxy = new EmployeeProxy();
            List<Employee> employees = new List<Employee>(empProxy.GetEmployeesByDepartmentId(department.Id).ToList());
            return employees;
        }

    }
}
