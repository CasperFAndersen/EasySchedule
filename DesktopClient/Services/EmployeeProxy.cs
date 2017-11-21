using DesktopClient.EmployeeService;
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
        public Employee GetEmployeeByUsername(string username)
        {
            return proxy.GetEmployeeByUsername(username);
        }

        public Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return proxy.GetEmployeeByUsernameAsync(username);
        }

        public Employee[] GetListOfEmployeesByDepartmentID(int departmentID)
        {
            return proxy.GetListOfEmployeesByDepartmentID(departmentID);
        }

        public Task<Employee[]> GetListOfEmployeesByDepartmentIDAsync(int departmentID)
        {
            return proxy.GetListOfEmployeesByDepartmentIDAsync(departmentID);
        }
    }
}
