using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TSchedule
    {
        [DataMember]
        public int ID { get; set; }
    }

    [DataContract]
    public class TemplateSchedule
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int NoOfWeeks { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public List<TemplateShift> ListOfTempShifts { get; set; }

        public TemplateSchedule(int numberOfWeeks, string name)
        {
            NoOfWeeks = numberOfWeeks;
            Name = name; 
        }
        public TemplateSchedule(int id, string name, int numberOfWeeks, int departmentID)
        {
            ListOfTempShifts = new List<TemplateShift>();
            ID = id;
            NoOfWeeks = numberOfWeeks;
            Name = name;
            DepartmentID = departmentID;

        }
        public TemplateSchedule(int numberOfWeeks, string name, int departmentID)
        {
            ListOfTempShifts = new List<TemplateShift>();
            NoOfWeeks = numberOfWeeks;
            Name = name;
            DepartmentID = departmentID;

        }
        public TemplateSchedule()
        {
            ListOfTempShifts = new List<TemplateShift>();
        }
    }
}
