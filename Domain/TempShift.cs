using System;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class TempShift
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

        public TempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            WeekNumber = weekNumber;
            Hours = hours;
            StartTime = startTime;
            ShiftEmployee = shiftEmployee;
        }

        public TempShift(int id, DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            ID = id;
            WeekNumber = weekNumber;
            Hours = hours;
            StartTime = startTime;
            ShiftEmployee = shiftEmployee;
        }
    }
}