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
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return _employeeRepository.GetEmployeeByUsername(username);
        }

        public List<Employee> GetListOfEmployeesByDepartmentId(int departmentId)
        {
            return _employeeRepository.GetListOfEmployeesByDepartmentID(departmentId);
        }

        public bool ValidatePassword(string username, string password)
        {
            Employee e1 = GetEmployeeByUsername(username);
            return e1.Password == password;
        }

    }
}
