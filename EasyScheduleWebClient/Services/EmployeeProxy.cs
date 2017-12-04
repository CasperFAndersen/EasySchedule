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
        EmployeeServiceClient proxy = new EmployeeServiceClient();

        public Employee GetEmployeeByUsername(string username)
        {
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return proxy.GetEmployeeByUsernameAsync(username);
        }

        public Employee[] GetEmployeesByDepartmentId(int departmentId)
        {
            return proxy.GetEmployeesByDepartmentId(departmentId);
        }

        public Task<Employee[]> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            return proxy.GetEmployeesByDepartmentIdAsync(departmentId);
        }

        public void InsertEmployee(Employee employee)
        {
            proxy.InsertEmployee(employee);
        }

        public Task InsertEmployeeAsync(Employee employee)
        {
            return proxy.InsertEmployeeAsync(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            proxy.UpdateEmployee(employee);
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            return proxy.UpdateEmployeeAsync(employee);
        }

        public bool ValidatePassword(string username, string password)
        {
            return ValidatePassword(username, password);
        }

        public Task<bool> ValidatePasswordAsync(string username, string password)
        {
           return proxy.ValidatePasswordAsync(username, password);
        }

        Employee[] IEmployeeService.GetAllEmployees()
        {
           return proxy.GetAllEmployees();
        }

        Task<Employee[]> IEmployeeService.GetAllEmployeesAsync()
        {
            return proxy.GetAllEmployeesAsync();
        }

        Employee[] IEmployeeService.GetEmployeesByDepartmentId(int departmentId)
        {
            return proxy.GetEmployeesByDepartmentId(departmentId);
        }
    }
}