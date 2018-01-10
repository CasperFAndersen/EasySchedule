using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;

namespace ServiceLibrary.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeController _employeeController = new EmployeeController();

        public List<Employee> GetAllEmployees()
        {
            return _employeeController.GetAllEmployees();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return _employeeController.GetEmployeeByUsername(username);
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            return _employeeController.GetEmployeesByDepartmentId(departmentId);
        }

        public void InsertEmployee(Employee employee)
        {
            _employeeController.InsertEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeController.UpdateEmployee(employee);
        }

        public Employee ValidatePassword(string username, string password)
        {
            return _employeeController.ValidatePassword(username, password);
        }
    }
}
