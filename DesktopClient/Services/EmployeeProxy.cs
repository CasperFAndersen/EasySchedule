﻿using DesktopClient.EmployeeService;
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
        EmployeeServiceClient proxy = new EmployeeServiceClient();

        public List<Employee> GetAllEmployees()
        {
            return proxy.GetAllEmployees();
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return proxy.GetAllEmployeesAsync();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return proxy.GetEmployeeByUsernameAsync(username);
        }

        public List<Employee> GetEmployeesByDepartmentId(int depId)
        {
            return proxy.GetEmployeesByDepartmentId(depId);
        }



        public void InsertEmployee(Employee employee)
        {
            proxy.InsertEmployee(employee);
        }

        public Task InsertEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            proxy.UpdateEmployee(employee);
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }


        Task<List<Employee>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        Task<List<Employee>> IEmployeeService.GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
