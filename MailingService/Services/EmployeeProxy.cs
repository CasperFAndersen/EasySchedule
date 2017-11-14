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
        IEmployeeService proxy = new EmployeeService.EmployeeServiceClient();
        public EmployeeService.Employee GetEmployeeByUsername(string username)
        {
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<EmployeeService.Employee> GetEmployeeByUsernameAsync(string username)
        {
            return proxy.GetEmployeeByUsernameAsync(username);
        }
    }
}