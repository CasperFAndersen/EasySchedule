using System;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            Schedule schRes = new Schedule();
            using(DbConnectionADO dbCon = new DbConnectionADO())
            {
                dbCon.OpenConnection();

                SqlCommand command = new SqlCommand("")
            }

            return schRes;
        }

        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();

            
        }
    }
}
