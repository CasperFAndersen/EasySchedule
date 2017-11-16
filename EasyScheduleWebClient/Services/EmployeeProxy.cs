using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyScheduleWebClient.EmployeeService;
using EasyScheduleWebClient.Models;

namespace EasyScheduleWebClient.Services
{
    public class EmployeeProxy : IEmployeeService
    {

        public Core.Employee GetEmployeeByUsername(string username)
        {
            EmployeeServiceClient proxy = new EmployeeServiceClient();
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<Core.Employee> GetEmployeeByUsernameAsync(string username)
        {
            EmployeeServiceClient proxy = new EmployeeServiceClient();
            return proxy.GetEmployeeByUsernameAsync(username);
        }


        public List<Employee> GetEmployeesByDepartment()
        {
            throw new NotImplementedException();
        }
    }
}