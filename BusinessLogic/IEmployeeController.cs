using System.Collections.Generic;
using Core;

namespace BusinessLogic
{
    public interface IEmployeeController
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUsername(string username);
        List<Employee> GetListOfEmployeesByDepartmentId(int departmentId);
        bool ValidatePassword(string username, string password);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}