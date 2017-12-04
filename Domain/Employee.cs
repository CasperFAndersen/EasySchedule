using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Core
{

    [DataContract]
    public class Employee
    {
        private PasswordHashing passwordHashing = new PasswordHashing();

        private string _name;
        private string _mail;
        private string _phone;
        private string _password;

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
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = CryptPassword(value);
            }
        }

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

        public string Salt { get; set; }

        public string CryptPassword(string password)
        {
            string salt = PasswordHashing.GenerateSalt(5);
            return PasswordHashing.CryptPassword(password + salt);
        }

    }
}
