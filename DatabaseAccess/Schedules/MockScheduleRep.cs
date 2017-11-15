using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Schedules
{
    public class MockScheduleRep : IScheduleRepository
    {
        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public Core.Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            Employee e1 = new Employee() {Name = "Arne" };
            Shift s1 = new Shift() { StartTime = new DateTime(2017, 11, 13, 9, 0, 0), Hours = 5, Employee = e1};
            Shift s2 = new Shift() { StartTime = new DateTime(2017, 11, 14, 11, 0, 0), Hours = 7, Employee = e1 };
            Shift s3 = new Shift() { StartTime = new DateTime(2017, 11, 17, 10, 0, 0), Hours = 3, Employee = e1 };

            Core.Schedule schedule = new Core.Schedule() {Shifts = new List<Shift>() };

            schedule.Shifts.Add(s1);
            schedule.Shifts.Add(s2);
            schedule.Shifts.Add(s3);

            return schedule;


        }

   
    }
}
