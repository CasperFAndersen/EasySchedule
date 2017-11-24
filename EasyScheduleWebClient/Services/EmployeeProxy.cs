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

        public List<Core.Employee> GetAllEmployees()
        {
           return proxy.GetAllEmployees();
        }

        public Task<List<Core.Employee>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Core.Employee GetEmployeeByUsername(string username)
        {        
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<Core.Employee> GetEmployeeByUsernameAsync(string username)
        {
            return proxy.GetEmployeeByUsernameAsync(username);
        }


        public List<Core.Employee> GetEmployeesByDepartmentId(int id)
        {
           // return proxy.GetEmployeesByDepartmentId(id);
            return null;
        }

        public List<Core.Employee> GetListOfEmployeeByDepartmentId(int depId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Core.Employee>> GetListOfEmployeeByDepartmentIdAsync(int depId)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployee(Core.Employee employee)
        {
            proxy.InsertEmployee(employee);
        }

        public Task InsertEmployeeAsync(Core.Employee employee)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Core.Employee employee)
        {
            
            proxy.UpdateEmployee(employee);
        }

        public Task UpdateEmployeeAsync(Core.Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}