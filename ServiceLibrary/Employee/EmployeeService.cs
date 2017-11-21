using System.Collections.Generic;
using BusinessLogic;

namespace ServiceLibrary.Employee
{

    public class EmployeeService : IEmployeeService
    {
        EmployeeController empCtrl = new EmployeeController();

        public Core.Employee GetEmployeeByUsername(string username)
        {
            return empCtrl.GetEmployeeByUsername(username);
        }

        public List<Core.Employee> GetListOfEmployeesByDepartmentID(int departmentID)
        {
            return empCtrl.GetListOfEmployeesByDepartmentID(departmentID);
        }
    }
}
