using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLogic;
using Core;

namespace Service
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
