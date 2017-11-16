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
        public int EmployeeID { get; set; }

        public TemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int TemplateScheduleID, int employeeID)
        {
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            EmployeeID = employeeID;
        }

        public TemplateShift(int id, DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleID, int employeeID)
        {
            ID = id;
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            TemplateScheduleID = templateScheduleID;
            EmployeeID = employeeID;
        }
    }
}