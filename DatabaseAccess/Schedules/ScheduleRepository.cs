using System;
using System.Data.SqlClient;
using Core;
using DatabaseAccess.Shifts;

namespace DatabaseAccess.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        //public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        //{
        //    Schedule schRes = new Schedule();
        //    using(DbConnectionADO dbCon = new DbConnectionADO())
        //    {
        //        dbCon.OpenConnection();

        //        SqlCommand command = new SqlCommand("select * from Shift, Schedule WHERE shift.scheduleId = (SELECT Schedule.id from Schedule WHERE startTime = @param1)");
        //        command.Parameters.AddWithValue("@Param1", currentDate);

        //        SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

        //        while (reader.Read())
        //        {
        //            schRes = BuildScheduleObject(reader);
        //        }
        //    }

        //    return schRes;
        //}

       
        

        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();

            schedule.Shifts = new ShiftRepository().GetShiftsByScheduleID(reader.GetInt32(0));
            schedule.StartDate = reader.GetDateTime(1);

            return schedule;
        }

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            Schedule scheRes = new Schedule();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "select * from Shift, Schedule WHERE shift.scheduleId = (SELECT Schedule.id from Schedule WHERE startTime = @param1)";

                    SqlParameter p1 = new SqlParameter(@"param1", System.Data.SqlDbType.DateTime,100);
                    p1.Value = currentDate;

                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        scheRes = BuildScheduleObject(reader);
                    }

                    return scheRes;
                }

            }
        }
    }
}
