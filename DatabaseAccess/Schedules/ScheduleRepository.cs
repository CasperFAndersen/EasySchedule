using System;
using System.Data;
using System.Data.SqlClient;
using Core;
using DatabaseAccess.Departments;
using DatabaseAccess.Shifts;

namespace DatabaseAccess.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
       
        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();

            schedule.Shifts = new ShiftRepository().GetShiftsByScheduleID(reader.GetInt32(0));
            schedule.StartDate = reader.GetDateTime(1);
            schedule.Department = new DepartmentRepository().GetDepartmentById(reader.GetInt32(3));

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

        public Schedule GetCurrentScheduleByDepartmentId(DateTime currentDate, int id)
        {
            Schedule scheRes = new Schedule();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "select * from Schedule WHERE Schedule.departmentId = @param1 AND Schedule.startDate = @param2";

                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.Int);
                    SqlParameter p2 = new SqlParameter(@"param2", System.Data.SqlDbType.DateTime, 100);
                    p1.Value = id;
                    p2.Value = currentDate;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);

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
