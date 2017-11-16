using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
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

        public List<TemplateShift> ListOfTempShifts { get { return listOfTempShifts; } }

        private List<TemplateShift> listOfTempShifts  = new List<TemplateShift>();

        public TemplateSchedule(int numberOfWeeks, string name)
        {
            NoOfWeeks = numberOfWeeks;
            Name = name; 
        }
        public TemplateSchedule(int id, string name, int numberOfWeeks, int departmentID)
        {
            ID = id;
            NoOfWeeks = numberOfWeeks;
            Name = name;
            DepartmentID = departmentID;

        }
        public TemplateSchedule(int numberOfWeeks, string name, int departmentID)
        {
            NoOfWeeks = numberOfWeeks;
            Name = name;
            DepartmentID = departmentID;

        }
        public TemplateSchedule()
        {
        }
        public void AddTempShift(TemplateShift tShift)
        {
            listOfTempShifts.Add(tShift);
        }
    }
}
