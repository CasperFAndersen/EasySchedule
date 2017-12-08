using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Core
{

    [DataContract]
    public class Employee
    {
        private string _name;
        private string _mail;

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name
        {
            get { return this._name; }
            set { if (value != null) { this._name = value; } }
        }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public int NoOfHours { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Mail
        {
            get { return _mail; }
            set
            {
                //TODO: Use RegEx
                //Ikke brug regex -> 
                _mail = value;
            }
        }

        [DataMember]
        public int DepartmentId { get; set; }

        [DataMember]
        public bool IsEmployed { get; set; }

        [DataMember]
        public string Salt { get; set; }

    }
}
