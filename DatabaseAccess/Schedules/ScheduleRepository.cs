using System;
using System.Data;
using System.Data.SqlClient;
using Core;
using DatabaseAccess.Departments;
using DatabaseAccess.Shifts;
using System.Transactions;
using System.Collections.Generic;

namespace DatabaseAccess.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();
            schedule.Id = reader.GetInt32(0);
            schedule.Shifts = new ShiftRepository().GetShiftsByScheduleID(schedule.Id);
            schedule.StartDate = reader.GetDateTime(1);
            schedule.EndDate = reader.GetDateTime(2);
            schedule.Department = new DepartmentRepository().GetDepartmentById(reader.GetInt32(3));
            return schedule;
        }

        private Schedule BuildScheduleWithoutShifts(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();
            schedule.Id = reader.GetInt32(0);
            schedule.StartDate = reader.GetDateTime(1);
            schedule.EndDate = reader.GetDateTime(2);
            schedule.Department = new DepartmentRepository().GetDepartmentById(Convert.ToInt32(reader["departmentId"].ToString()));
            return schedule;
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            List<Schedule> schedules = new List<Schedule>();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select * from Schedule WHERE departmentId = @param1";
                    command.Parameters.AddWithValue("@param1", departmentId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Schedule schedule = BuildScheduleWithoutShifts(reader);
                        schedules.Add(schedule);
                    }
                    return schedules;
                }
            }
        }


        public void InsertScheduleIntoDb(Schedule schedule)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new DbConnection().GetConnection())
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Schedule (startDate, endDate, departmentId)" +
                                              " VALUES (@param1, @param2, @param3) SELECT SCOPE_IDENTITY();";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.DateTime, 100);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.DateTime, 100);
                            SqlParameter p3 = new SqlParameter(@"param3", SqlDbType.Int, 100);

                            p1.Value = schedule.StartDate;
                            p2.Value = schedule.EndDate;
                            p3.Value = schedule.Department.Id;

                            command.Parameters.Add(p1);
                            command.Parameters.Add(p2);
                            command.Parameters.Add(p3);

                            int id = Convert.ToInt32(command.ExecuteScalar());

                            ShiftRepository shiftRep = new ShiftRepository();
                            shiftRep.InsertShiftsIntoDb(schedule.Shifts, id, connection);

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

        public void UpdateSchedule(Schedule schedule)
        {
            ShiftRepository shiftRepository = new ShiftRepository();
            shiftRepository.AddShiftsFromScheduleToDb(schedule);
        }
    }
}
