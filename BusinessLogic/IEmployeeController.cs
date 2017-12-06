using System.Collections.Generic;
using Core;

namespace BusinessLogic
{
    public interface IEmployeeController
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUsername(string username);
        List<Employee> GetEmployeesByDepartmentId(int departmentId);
        Employee ValidatePassword(string username, string password);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}