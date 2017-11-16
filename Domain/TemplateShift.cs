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
        public DayOfWeek WeekDay { get; set; }
        [DataMember]
        public double Hours { get; set; }
        [DataMember]
        public TimeSpan StartTime { get; set; }     
        [DataMember]
        public int TemplateScheduleID { get; set; }
        [DataMember]
        public Employee Employee { get; set; }

        public TemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int TemplateScheduleID, Employee employee)
        {
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            Employee = employee;
        }

        public TemplateShift(int id, DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleID, Employee employee)
        {
            ID = id;
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            TemplateScheduleID = templateScheduleID;
            Employee = employee;
        }

        public TemplateShift()
        {}
    }
}