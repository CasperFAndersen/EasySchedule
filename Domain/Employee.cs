using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Core
{
    [DataContract]
    public class Employee
    {
        private string _name;
        private string _mail;
        private string _phone;

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name
        {
            get { return this._name; }
            set { if (value != null) { this._name = value; } }
        }

        [DataMember]
        public string Phone
        {
            get { return _phone; }
            set
            {
                //TODO: Use RegEx
                _phone = value;
            }
        }

        [DataMember]
        public int NumbOfHours { get; set; }

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
                _mail = value;
            }
        }

        [DataMember]
        public int DepartmentId { get; set; }

        [DataMember]
        public bool IsEmployed { get; set; }

    }
}
