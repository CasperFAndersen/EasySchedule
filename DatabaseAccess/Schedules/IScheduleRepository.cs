using System;
using System.Data.SqlClient;
using Core;
using System.Collections.Generic;

namespace DatabaseAccess.Schedules
{
    public interface IScheduleRepository
    {
        Schedule BuildScheduleObject(SqlDataReader reader);
        void InsertScheduleIntoDb(Schedule schedule);
        List<Schedule> GetSchedulesByDepartmentId(int departmentId);
        void UpdateSchedule(Schedule schedule);
    }
}
