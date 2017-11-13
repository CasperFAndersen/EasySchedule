using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Employee
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set { if (value != null) { this.name = value; } }
        }
        public string Phone { get; set; }
        public int NumbOfHours { get; set; }
        public bool IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public string Mail { get; set; }

        public Employee()
        {

        }


    }
}
