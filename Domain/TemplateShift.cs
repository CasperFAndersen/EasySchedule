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
        public float Hours { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }     
        [DataMember]
        public int TemplateScheduleID { get; set; }
        [DataMember]
        public int EmployeeID { get; set; }

        public TemplateShift(DayOfWeek weekDay, float hours, DateTime startTime, int TemplateScheduleID, int employeeID)
        {
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            EmployeeID = employeeID;
        }

        public TemplateShift(int id, DayOfWeek weekDay, float hours, DateTime startTime, int templateScheduleID, int employeeID)
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