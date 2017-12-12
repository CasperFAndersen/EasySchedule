using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Employees
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByUsername(string username);
        List<Employee> GetEmployeesByDepartmentId(int departmentId);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        string GetSaltByEmployee(Employee employee);
    }
}
