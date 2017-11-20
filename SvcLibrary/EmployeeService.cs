using System;
using System.Collections.Generic;
using BusinessLogic;
using Core;

namespace ServiceLibrary
{

    public class EmployeeService : IEmployeeService
    {
        EmployeeController empCtrl = new EmployeeController();

        public Employee GetEmployeeByUsername(string username)
        {
            return empCtrl.GetEmployeeByUsername(username);
        }

        public List<Employee> GetListOfEmployeesByDepartmentID(int departmentID)
        {
            return empCtrl.GetListOfEmployeesByDepartmentID(departmentID);
        }
    }
}
