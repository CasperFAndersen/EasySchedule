using System;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class TemplateShift
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime WeekNumber { get; set; }
        [DataMember]
        public int Hours { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public Employee ShiftEmployee { get; set; }

        public TemplateShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            WeekNumber = weekNumber;
            Hours = hours;
            StartTime = startTime;
            ShiftEmployee = shiftEmployee;
        }

        public TemplateShift(int id, DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            ID = id;
            WeekNumber = weekNumber;
            Hours = hours;
            StartTime = startTime;
            ShiftEmployee = shiftEmployee;
        }
    }
}