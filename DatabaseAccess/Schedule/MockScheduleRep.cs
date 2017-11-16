using System;
using System.Collections.Generic;
using Core;

namespace DatabaseAccess.Schedule
{
    public class MockScheduleRep : IScheduleRepository
    {
        public Core.Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            Employee e1 = new Employee() {Name = "Arne" };
            TemplateShift s1 = new TemplateShift() { StartTime = new DateTime(2017, 11, 13, 9, 0, 0), Hours = 5, Employee = e1};
            TemplateShift s2 = new TemplateShift() { StartTime = new DateTime(2017, 11, 14, 11, 0, 0), Hours = 7, Employee = e1 };
            TemplateShift s3 = new TemplateShift() { StartTime = new DateTime(2017, 11, 17, 10, 0, 0), Hours = 3, Employee = e1 };

            Core.Schedule schedule = new Core.Schedule() {Shifts = new List<TemplateShift>() };

            schedule.Shifts.Add(s1);
            schedule.Shifts.Add(s2);
            schedule.Shifts.Add(s3);

            return schedule;


        }

   
    }
}
