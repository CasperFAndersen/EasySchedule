using System;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Schedules
{
    public interface IScheduleRepository
    {
        Schedule GetScheduleByCurrentDate(DateTime currentDate);

        Schedule BuildScheduleObject(SqlDataReader reader);
        Schedule GetCurrentScheduleByDepartmentId(DateTime currentDate, int id);
        void InsertScheduleIntoDb(Schedule schedule);
    }
}
