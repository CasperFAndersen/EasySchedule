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
            List<Employee> listOfEmployees = new List<Employee>(empProxy.GetListOfEmployeeByDepartmentId(department.Id).ToList());
            return listOfEmployees;
        }

    }
}
