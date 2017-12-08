using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InputValidator
    {
        private string _employeePhoneCheck;
        private string _employeeEmailCheck;
        private string _employeeNameCheck;
        private string _employeeUsernameCheck;
        private string _employeePasswordCheck;


        public string EmployeePhoneCheck
        {
            get { return _employeePhoneCheck = "^[0-9]{8,20}$"; }
        }

        public string EmployeeEmailCheck
        {
            get { return _employeeEmailCheck = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,6}$"; }
        }

        public string EmployeeNameCheck
        {
            get { return _employeeNameCheck = "[a-zA-Z]+( [a-zA-Z]+)+"; }
        }
            
        public string EmployeeUsernameCheck
        {
            get { return _employeeUsernameCheck = "[0-9a-zA-Z]{3,}"; }
        }

        public string EmployeePasswordCheck
        {
            get { return _employeePasswordCheck = "[0-9a-zA-Z._-]{6,30}"; }
        }

    }
}
