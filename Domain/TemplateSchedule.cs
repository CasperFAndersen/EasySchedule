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
        public int Id { get; set; }

        [DataMember]
        public int NoOfWeeks { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int DepartmentId { get; set; }

        [DataMember]
        public List<TemplateShift> TemplateShifts { get; set; }

        public TemplateSchedule(int numberOfWeeks, string name)
        {
            NoOfWeeks = numberOfWeeks;
            Name = name;
            TemplateShifts = new List<TemplateShift>();
        }
        public TemplateSchedule(int id, string name, int numberOfWeeks, int departmentId)
        {
            TemplateShifts = new List<TemplateShift>();
            Id = id;
            NoOfWeeks = numberOfWeeks;
            Name = name;
            DepartmentId = departmentId;
            TemplateShifts = new List<TemplateShift>();
        }

        public TemplateSchedule(int numberOfWeeks, string name, int departmentId)
        {
            TemplateShifts = new List<TemplateShift>();
            NoOfWeeks = numberOfWeeks;
            Name = name;
            DepartmentId = departmentId;
            TemplateShifts = new List<TemplateShift>();
        }

        public TemplateSchedule()
        {
            TemplateShifts = new List<TemplateShift>();
        }
    }
}
