using MailingService.ScheduleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MailingService.EmployeeService;

namespace MailingService.Services
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