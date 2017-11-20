using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Employees;

namespace BusinessLogic
{
    public class EmployeeController
    {
        IEmployeeRepository empRep = new EmployeeRepository();
        public List<Employee> GetAllEmployees()
        {
            return empRep.GetAllEmployees();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return empRep.GetEmployeeByUsername(username);
        }

        public List<Employee> GetListOfEmployeesByDepartmentID(int departmentID)
        {
            return empRep.GetListOfEmployeesByDepartmentID(departmentID);
        }

        public bool ValidatePassword(string username, string password)
        {
            Employee e1 = GetEmployeeByUsername(username);
            return e1.Password == password;
        }

    }
}
