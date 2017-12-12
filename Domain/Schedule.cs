using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [DataContract]
    public class Schedule
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public Department Department { get; set; }

        [DataMember]
        public List<ScheduleShift> Shifts { get; set; }

        public Schedule()
        {
            Department = new Department();
            Shifts = new List<ScheduleShift>();
        }
    }
}
