using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Employees;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class EmployeeController : IEmployeeController
    {
        InputValidator iV = new InputValidator();
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

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            return _employeeRepository.GetEmployeesByDepartmentId(departmentId);
        }

        public Employee ValidatePassword(string username, string password)
        {
            Employee employee = GetEmployeeByUsername(username);
            string salt = _employeeRepository.GetSaltFromEmployeePassword(employee);
            password = PasswordHashing.HashPassword(salt+password);
            bool res;
            res = employee.Password.Equals(password);
            if (res)
            {
                return employee;
            }
            return null;
        }

        public void InsertEmployee(Employee employee)
        {
            if
                (
                Regex.IsMatch(employee.Name, iV.EmployeeNameCheck)
                &&
                Regex.IsMatch(employee.Phone, iV.EmployeePhoneCheck)
                &&
                Regex.IsMatch(employee.Mail, iV.EmployeeEmailCheck)
                &&
                Regex.IsMatch(employee.Username, iV.EmployeeUsernameCheck)
                &&
                Regex.IsMatch(employee.Password, iV.EmployeePasswordCheck)
                &&
                employee.NumbOfHours > 0
                )
            {
                _employeeRepository.InsertEmployee(employee);
            }
            else
            {
                throw new ArgumentException("An error regarding input checks has arrised. Please check that the inputs are valid.");
            }

        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.UpdateEmployee(employee);
        }

    }
}
