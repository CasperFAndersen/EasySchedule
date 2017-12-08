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
        InputValidator inputValidator = new InputValidator();
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
            password = PasswordHashing.HashPassword(salt + password);
            if (employee.Password.Equals(password))
            {
                return employee;
            }
            return null;
        }

        public void InsertEmployee(Employee employee)
        {
            try
            {
                employee.Salt = PasswordHashing.GenerateSalt();
                employee.Password = PasswordHashing.HashPassword(employee.Salt + employee.Password);
                if
                (
                Regex.IsMatch(employee.Name, inputValidator.EmployeeNameCheck)
                &&
                Regex.IsMatch(employee.Phone, inputValidator.EmployeePhoneCheck)
                &&
                Regex.IsMatch(employee.Mail, inputValidator.EmployeeEmailCheck)
                &&
                Regex.IsMatch(employee.Username, inputValidator.EmployeeUsernameCheck)
                &&
                employee.NoOfHours >= 0
                )
                {
                    _employeeRepository.InsertEmployee(employee);
                }
                else
                {
                    throw new ArgumentException("An error regarding input checks has arrised. Please check that the inputs are valid.");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                if (!employee.Password.Equals(GetEmployeeByUsername(employee.Username).Password))
                {
                    employee.Salt = PasswordHashing.GenerateSalt();
                    employee.Password = PasswordHashing.HashPassword(employee.Salt + employee.Password);
                }

                if
                (
                    Regex.IsMatch(employee.Name, inputValidator.EmployeeNameCheck)
                    &&
                    Regex.IsMatch(employee.Phone, inputValidator.EmployeePhoneCheck)
                    &&
                    Regex.IsMatch(employee.Mail, inputValidator.EmployeeEmailCheck)
                    &&
                    Regex.IsMatch(employee.Username, inputValidator.EmployeeUsernameCheck)
                    &&
                    employee.NoOfHours >= 0
                )
                {
                    _employeeRepository.UpdateEmployee(employee);
                }
                else
                {
                    throw new ArgumentException("An error regarding input checks has arrised. Please check that the inputs are valid.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
