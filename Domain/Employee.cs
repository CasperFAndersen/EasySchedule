using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Core
{

    [DataContract]
    public class Employee
    {
        private string _name;

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
        public int NumbOfHours { get; set; }

        [DataMember]
        public bool IsAdmin { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public int DepartmentId { get; set; }

        [DataMember]
        public bool IsEmployed { get; set; }

        [DataMember]
        public string Salt { get; set; }

    }
}
