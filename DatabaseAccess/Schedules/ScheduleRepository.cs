using System;
using System.Data;
using System.Data.SqlClient;
using Core;
using DatabaseAccess.Departments;
using DatabaseAccess.Shifts;
using System.Transactions;

namespace DatabaseAccess.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {

        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();

            schedule.Shifts = new ShiftRepository().GetShiftsByScheduleID(reader.GetInt32(0));
            schedule.StartDate = reader.GetDateTime(1);
            schedule.Department = new DepartmentRepository().GetDepartmentById(reader.GetInt32(2));

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

                    SqlParameter p1 = new SqlParameter(@"param1", System.Data.SqlDbType.DateTime, 100);
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

                    SqlParameter p1 = new SqlParameter("@param1", SqlDbType.Int);
                    SqlParameter p2 = new SqlParameter("@param2", System.Data.SqlDbType.DateTime2, 100);
                    p1.Value = id;
                    p2.Value = currentDate;

                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        scheRes = BuildScheduleObject(reader);
                    }

                    return scheRes;
                }

            }
        }

        public void InsertScheduleIntoDb(Schedule schedule)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    using (SqlConnection conn = new DbConnectionADO().GetConnection())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {

                            cmd.CommandText = "INSERT INTO Schedule (startDate, departmentId)" +
                                              " VALUES (@param1, @param2) SELECT SCOPE_IDENTITY();";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.DateTime, 100);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.Int, 100);

                            p1.Value = schedule.StartDate;
                            p2.Value = schedule.Department.Id;

                            cmd.Parameters.Add(p1);
                            cmd.Parameters.Add(p2);

                            int id = Convert.ToInt32(cmd.ExecuteScalar());

                            ShiftRepository shiftRep = new ShiftRepository();
                            shiftRep.InsertShiftsIntoDb(schedule.Shifts, id, conn);

                            scope.Complete();
                        }

                    }
               
                }


            }
            catch (Exception e)
            {

                throw new Exception("Something went wrong! Schedule not added to database." + e.Message);
            }
        }

        public void UpdateSchedule(Schedule schedule, int id)
        {
            ShiftRepository shiftRepository = new ShiftRepository();
            shiftRepository.AddShiftsFromScheduleToDb(id, schedule.Shifts);
        }

    }
}
