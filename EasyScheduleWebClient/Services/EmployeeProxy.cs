using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using EasyScheduleWebClient.EmployeeService;
using EasyScheduleWebClient.Models;

namespace EasyScheduleWebClient.Services
{
    public class EmployeeProxy : IEmployeeService
    {
        readonly EmployeeServiceClient employeeService = new EmployeeServiceClient();

        public Employee GetEmployeeByUsername(string username)
        {
            return employeeService.GetEmployeeByUsername(username);
        }

        public Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return employeeService.GetEmployeeByUsernameAsync(username);
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            return employeeService.GetEmployeesByDepartmentId(departmentId);
        }

        public Task<List<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            return employeeService.GetEmployeesByDepartmentIdAsync(departmentId);
        }

        public void InsertEmployee(Employee employee)
        {
            employeeService.InsertEmployee(employee);
        }

        public Task InsertEmployeeAsync(Employee employee)
        {
            return employeeService.InsertEmployeeAsync(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
           employeeService.UpdateEmployee(employee);
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            return employeeService.UpdateEmployeeAsync(employee);
        }

        public Employee ValidatePassword(string username, string password)
        {
            return employeeService.ValidatePassword(username, password);
        }

        public Task<Employee> ValidatePasswordAsync(string username, string password)
        {
            return employeeService.ValidatePasswordAsync(username, password);
        }

        List<Employee> IEmployeeService.GetAllEmployees()
        {
            return employeeService.GetAllEmployees();
        }

        Task<List<Employee>> IEmployeeService.GetAllEmployeesAsync()
        {
            return employeeService.GetAllEmployeesAsync();
        }

        List<Employee> IEmployeeService.GetEmployeesByDepartmentId(int departmentId)
        {
            return employeeService.GetEmployeesByDepartmentId(departmentId);
        }
    }
}