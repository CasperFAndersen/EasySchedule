using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Employees
{
    public interface IEmployeeRepository
    {
        void InsertEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUsername(string username);
        List<Employee> GetEmployeesByDepartmentId(int departmentId);
        void UpdateEmployee(Employee employee);
        string GetSaltFromEmployeePassword(Employee employee);
    }
}
