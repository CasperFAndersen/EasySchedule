using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Employees
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUsername(string username);
        Employee BuildEmployeeObject(SqlDataReader reader);
        List<Employee> GetListOfEmployeesByDepartmentID(int departmentID);
    }
}
