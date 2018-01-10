using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace EasyScheduleWebClient.Services
{
    public class EventRepository
    {
        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();

            List<ScheduleShift> scheduleShifts = new List<ScheduleShift>();
            //TODO: Get shifts based on department and employee
            int id = 0;
            foreach (ScheduleShift shift in scheduleShifts)
            {
                events.Add(new Event()
                {
                    EventId = ++id,
                    Subject = shift.Employee.Name,
                    Description = "Work",
                    Start = shift.StartTime,
                    End = shift.StartTime.AddHours(shift.Hours),
                    ThemeColor = "Red",
                    IsFullDay = false
                });

            }

            return events;
        }
    }

    public class Event
    {
        public int EventId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}

