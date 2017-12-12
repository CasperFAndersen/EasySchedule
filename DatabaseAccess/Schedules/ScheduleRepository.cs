using System;
using System.Data;
using System.Data.SqlClient;
using Core;
using DatabaseAccess.Departments;
using System.Transactions;
using System.Collections.Generic;
using DatabaseAccess.ScheduleShifts;

namespace DatabaseAccess.Schedules
{
    public class ScheduleRepository : IScheduleRepository
    {
        /// <summary>
        /// This method builds a new Schedule object with the information retrieved from the database.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Schedule BuildScheduleObject(SqlDataReader reader)
        {
            Schedule schedule = new Schedule();
            schedule.Id = reader.GetInt32(0);

            schedule.StartDate = reader.GetDateTime(1);
            schedule.EndDate = reader.GetDateTime(2);

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
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Schedule schedule = BuildScheduleObject(reader);
                            schedules.Add(schedule);
                        }
                    }
                }
            }
            return schedules;
        }

        public Schedule InsertSchedule(Schedule schedule)
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

                    schedule.Id = Convert.ToInt32(command.ExecuteScalar());

                }
            }
            return schedule;
        }

        //public void UpdateSchedule(Schedule schedule)
        //{
        //    ScheduleShiftRepository scheduleShiftRepository = new ScheduleShiftRepository();
        //    scheduleShiftRepository.AddShiftsFromSchedule(schedule);
        //}

    }
}
