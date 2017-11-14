using System.Collections.Generic;
using Core;

namespace DatabaseAccess.Employees
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUsername(string username);
        
    }
}
