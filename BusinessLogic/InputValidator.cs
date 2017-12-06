using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InputValidator
    {
        private string employeePhoneCheck;
        private string employeeEmailCheck;
        private string employeeNameCheck;
        private int employeeNoOfHoursCheck;
        private string employeeUsernameCheck;
        private string employeePasswordCheck;


        public string EmployeePhoneCheck
        {
            get { return employeePhoneCheck = "^[0-9]{8,}$"; }
            // If it just needs numbers, use "[0-9]+" for international aswell. Currently only accepts danish 8 digit numbers.
        }

        public string EmployeeEmailCheck
        {
            get { return employeeEmailCheck = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,6}$"; }
        }

        public string EmployeeNameCheck
        {
            get { return employeeNameCheck = "[a-zA-Z]+( [a-zA-Z]+)+"; }
        }
            
        //public int EmployeeNoOfHoursCheck
        //{
        //    get { return employeeNoOfHoursCheck = ; }
        //}

        public string EmployeeUsernameCheck
        {
            get { return employeeUsernameCheck = "[a-zA-Z]+( [a-zA-Z]+)+"; }
        }

        public string EmployeePasswordCheck
        {
            get { return employeePasswordCheck = "[0-9a-zA-Z]{6,}"; }
        }

    }
}
