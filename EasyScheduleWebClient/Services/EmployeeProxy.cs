using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EasyScheduleWebClient.EmployeeService;

namespace EasyScheduleWebClient.Services
{
    public class EmployeeProxy : IEmployeeService
    {

        public EmployeeService.Employee GetEmployeeByUsername(string username)
        {
            EmployeeServiceClient proxy = new EmployeeServiceClient();
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<EmployeeService.Employee> GetEmployeeByUsernameAsync(string username)
        {
            EmployeeServiceClient proxy = new EmployeeServiceClient();
            return proxy.GetEmployeeByUsernameAsync(username);
        }


    }
}