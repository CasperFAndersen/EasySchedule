using System;
using System.Data.SqlClient;
using Core;
using System.Collections.Generic;

namespace DatabaseAccess.Schedules
{
    public interface IScheduleRepository
    {
        Schedule InsertSchedule(Schedule schedule);
        List<Schedule> GetSchedulesByDepartmentId(int departmentId);
    }
}
