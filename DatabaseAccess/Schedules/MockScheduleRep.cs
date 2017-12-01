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
            Employee employee = new Employee() {Name = "Arne" };
            ScheduleShift scheduleShift1 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 13, 9, 0, 0), Hours = 5, Employee = employee};
            ScheduleShift scheduleShift2 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 14, 11, 0, 0), Hours = 7, Employee = employee };
            ScheduleShift scheduleShift3 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 17, 10, 0, 0), Hours = 3, Employee = employee };

            Schedule schedule = new Schedule() {Shifts = new List<ScheduleShift>() };

            schedule.Shifts.Add(scheduleShift1);
            schedule.Shifts.Add(scheduleShift2);
            schedule.Shifts.Add(scheduleShift3);

            return schedule;
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public void InsertSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(Schedule schedule, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
