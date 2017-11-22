using System.Collections.Generic;
using BusinessLogic;
using Core;

namespace ServiceLibrary.Employee
{

    public class EmployeeService : IEmployeeService
    {
        EmployeeController empCtrl = new EmployeeController();

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
            return empCtrl.GetListOfEmployeesByDepartmentID(depId);
        }

        public List<Core.Employee> GetListOfEmployeesByDepartmentID(int departmentID)
        {
            return empCtrl.GetListOfEmployeesByDepartmentID(departmentID);
        }
    }
}
