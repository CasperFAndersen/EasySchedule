using System;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class TemplateShift : Shift
    {
        [DataMember]
        public DayOfWeek WeekDay { get; set; }

        [DataMember]
        public TimeSpan StartTime { get; set; }

        [DataMember]
        public int TemplateScheduleId { get; set; }

        [DataMember]
        public int WeekNumber { get; set; }

        public TemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleID, Employee employee)
        {
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            Employee = employee;
        }

        public TemplateShift(int id, DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            Id = id;
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            TemplateScheduleId = templateScheduleId;
            Employee = employee;
        }


        public TemplateShift()
        {
            
        }
    }
}