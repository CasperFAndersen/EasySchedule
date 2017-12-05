using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;

namespace ServiceLibrary.Employees
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeController employeeController = new EmployeeController(new EmployeeRepository());

        public List<Employee> GetAllEmployees()
        {
            return employeeController.GetAllEmployees();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return employeeController.GetEmployeeByUsername(username);
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            return employeeController.GetEmployeesByDepartmentId(departmentId);
        }

        public void InsertEmployee(Employee employee)
        {
            employeeController.InsertEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            employeeController.UpdateEmployee(employee);
        }

        public bool ValidatePassword(string username, string password)
        {
           return employeeController.ValidatePassword(username, password);
        }
    }
}
