using System;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Schedule
{
    public class ScheduleRepository : IScheduleRepository
    {
        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            using(DbConnectionADO dbCon = new DbConnectionADO())
            {
                dbCon.OpenConnection();

            }
            
        }

        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();

            
        }
    }
}
