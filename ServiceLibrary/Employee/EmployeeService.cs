using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;

namespace ServiceLibrary.Employee
{

    public class EmployeeService : IEmployeeService
    {
        EmployeeController empCtrl = new EmployeeController(new EmployeeRepository());

        public List<Core.Employee> GetAllEmployees()
        {
            return empCtrl.GetAllEmployees();
        }

        public Core.Employee GetEmployeeByUsername(string username)
        {
            return empCtrl.GetEmployeeByUsername(username);
        }

        public List<Core.Employee> GetListOfEmployeeByDepartmentId(int depId)
        {
            return empCtrl.GetListOfEmployeesByDepartmentId(depId);
        }

        public List<Core.Employee> GetListOfEmployeesByDepartmentID(int departmentID)
        {
            return empCtrl.GetListOfEmployeesByDepartmentId(departmentID);
        }
    }
}
