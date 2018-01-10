using System;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class TemplateShift : Shift
    {
        #region Properties
        [DataMember]
        public DayOfWeek WeekDay { get; set; }

        [DataMember]
        public TimeSpan StartTime { get; set; }

        [DataMember]
        public int WeekNumber { get; set; }

        [DataMember]
        public int TemplateScheduleId { get; set; }
        #endregion

        public TemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
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