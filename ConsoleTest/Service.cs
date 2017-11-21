using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTest.EmployeeService;
using Core;

namespace ConsoleTest
{
    public class Service : IEmployeeService 
    {
        public Employee GetEmployeeByUsername(string username)
        {
            
            EmployeeServiceClient client = new EmployeeServiceClient();
            return client.GetEmployeeByUsername(username);
        }

        public Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
