using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class Schedule
    {
        #region Properties
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
        #endregion

        public Schedule()
        {
            Department = new Department();
            Shifts = new List<ScheduleShift>();
        }
    }
}
