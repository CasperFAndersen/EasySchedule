using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;

namespace ServiceLibrary.Employee
{

    public class EmployeeService : IEmployeeService
    {
        IEmployeeController employeeController = new EmployeeController(new EmployeeRepository());

        public List<Core.Employee> GetAllEmployees()
        {
            return employeeController.GetAllEmployees();
        }

        public Core.Employee GetEmployeeByUsername(string username)
        {
            return employeeController.GetEmployeeByUsername(username);
        }

        public List<Core.Employee> GetListOfEmployeeByDepartmentId(int depId)
        {
            return employeeController.GetListOfEmployeesByDepartmentId(depId);
        }

        public List<Core.Employee> GetListOfEmployeesByDepartmentId(int departmentId)
        {
            return employeeController.GetListOfEmployeesByDepartmentId(departmentId);
        }

        public void InsertEmployee(Core.Employee employee)
        {
            employeeController.InsertEmployee(employee);
        }

        public void UpdateEmployee(Core.Employee employee)
        {
            employeeController.UpdateEmployee(employee);
        }
    }
}
