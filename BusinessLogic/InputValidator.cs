using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// This class is for input checks regarding user inputs from the UI.
    /// </summary>
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
            //A phonenumber can have a minimum of 8 digits, and a maximum of 20.
            get { return employeePhoneCheck = "^[0-9]{8,20}$"; }
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
            get { return employeeUsernameCheck = "[0-9a-zA-Z]{3,}"; }
        }

        public string EmployeePasswordCheck
        {
            //A username can be between 6 and 30 digits.
            get { return employeePasswordCheck = "[0-9a-zA-Z]{6,30}"; }
        }

    }
}
