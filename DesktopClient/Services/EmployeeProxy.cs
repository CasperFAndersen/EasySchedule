using DesktopClient.EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DesktopClient.Services
{
    public class EmployeeProxy : IEmployeeService
    {
        readonly EmployeeServiceClient _employeeServiceClient = new EmployeeServiceClient();

        public List<Employee> GetAllEmployees()
        {
            return _employeeServiceClient.GetAllEmployees();
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return _employeeServiceClient.GetAllEmployeesAsync();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return _employeeServiceClient.GetEmployeeByUsername(username);
        }

        public Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return _employeeServiceClient.GetEmployeeByUsernameAsync(username);
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            return _employeeServiceClient.GetEmployeesByDepartmentId(departmentId);
        }

        public Task<List<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            return _employeeServiceClient.GetEmployeesByDepartmentIdAsync(departmentId);
        }

        public void InsertEmployee(Employee employee)
        {
            _employeeServiceClient.InsertEmployee(employee);
        }

        public Task InsertEmployeeAsync(Employee employee)
        {
            return _employeeServiceClient.InsertEmployeeAsync(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeServiceClient.UpdateEmployee(employee);
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            return _employeeServiceClient.UpdateEmployeeAsync(employee);
        }

        public Employee ValidatePassword(string username, string password)
        {
            return _employeeServiceClient.ValidatePassword(username, password);
        }

        public Task<Employee> ValidatePasswordAsync(string username, string password)
        {
            return _employeeServiceClient.ValidatePasswordAsync(username, password);
        }

    }
}
