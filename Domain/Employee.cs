using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Core
{

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get;set;}

        [DataMember]
        public string Email { get; set; }

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
        public int DepartmentId { get; set; }

        [DataMember]
        public bool IsEmployed { get; set; }

        [DataMember]
        public string Salt { get; set; }

    }
}
