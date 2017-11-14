using System;
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

        public Employee GetEmployeeByUsername3(string username)
        {
            throw new NotImplementedException();
        }
    }
}
