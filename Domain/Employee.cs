using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        private string name;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name
        {
            get { return this.name; }
            set { if (value != null) { this.name = value; } }
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


        public Employee()
        {

        }
    }
}
