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
        public int WeekNumber { get; set; }
        [DataMember]
        public int TemplateScheduleId { get; set; }

        /// <summary>
        /// Constructor for TemplateShift which takes 5 parameters.
        /// </summary>
        /// <param name="weekDay"></param>
        /// <param name="hours"></param>
        /// <param name="startTime"></param>
        /// <param name="templateScheduleID"></param>
        /// <param name="employee"></param>
        public TemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleID, Employee employee)
        {
            WeekDay = weekDay;
            Hours = hours;
            StartTime = startTime;
            Employee = employee;
        }

        /// <summary>
        /// Constructor for TemplateShift which takes 6 parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weekDay"></param>
        /// <param name="hours"></param>
        /// <param name="startTime"></param>
        /// <param name="templateScheduleId"></param>
        /// <param name="employee"></param>
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