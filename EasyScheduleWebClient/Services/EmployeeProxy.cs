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

        public List<Employee> GetAllEmployees()
        {
            return proxy.GetAllEmployees();
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return proxy.GetEmployeeByUsernameAsync(username);
        }


        public List<Employee> GetEmployeesByDepartmentId(int id)
        {
            // return proxy.GetEmployeesByDepartmentId(id);
            return null;
        }

        public List<Employee> GetListOfEmployeeByDepartmentId(int depId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetListOfEmployeeByDepartmentIdAsync(int depId)
        {
            throw new NotImplementedException();
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
    }
}