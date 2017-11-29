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

        public Schedule GetCurrentScheduleByDepartmentId(DateTime currentDate, int id)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            Employee e1 = new Employee() {Name = "Arne" };
            ScheduleShift s1 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 13, 9, 0, 0), Hours = 5, Employee = e1};
            ScheduleShift s2 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 14, 11, 0, 0), Hours = 7, Employee = e1 };
            ScheduleShift s3 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 17, 10, 0, 0), Hours = 3, Employee = e1 };

            Schedule schedule = new Schedule() {Shifts = new List<ScheduleShift>() };

            schedule.Shifts.Add(s1);
            schedule.Shifts.Add(s2);
            schedule.Shifts.Add(s3);

            return schedule;


        }

        public void InsertScheduleIntoDb(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
