using Core;
using DatabaseAccess.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace DatabaseAccess.Shifts
{
    public class ShiftRepository : IShiftRepository
    {
        public List<ScheduleShift> GetShiftsByScheduleId(int scheduleId)
        {
            List<ScheduleShift> scheduleShifts = new List<ScheduleShift>();

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM shift WHERE shift.scheduleId = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.Int);
                    p1.Value = scheduleId;
                    command.Parameters.Add(p1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scheduleShifts.Add(BuildShiftObject(reader));
                        }
                    }
                }
            }
            return scheduleShifts;
        }

        public List<ScheduleShift> GetShiftsByEmployeeId(int employeeId)
        {
            List<ScheduleShift> scheduleShifts = new List<ScheduleShift>();

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM shift WHERE shift.employeeId = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.Int);
                    p1.Value = employeeId;
                    command.Parameters.Add(p1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scheduleShifts.Add(BuildShiftObject(reader));
                        }
                    }
                }
            }
            return scheduleShifts; ;
        }

        public void InsertShifts(List<ScheduleShift> shifts, int scheduleId, SqlConnection connection)
        {
            try
            {
                using (connection)
                {
                    foreach (var shift in shifts)
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Shift (startTime, hours, scheduleId, employeeId, isForSale)" +
                                              " VALUES (@param1, @param2, @param3, @param4, @param5)";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.SmallDateTime, 100);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.Int, 100);
                            SqlParameter p3 = new SqlParameter(@"param3", SqlDbType.Int, 100);
                            SqlParameter p4 = new SqlParameter(@"param4", SqlDbType.Int, 100);
                            SqlParameter p5 = new SqlParameter(@"param5", SqlDbType.Bit);

                            p1.Value = shift.StartTime;
                            p2.Value = shift.Hours;
                            p3.Value = scheduleId;
                            p4.Value = shift.Employee.Id;
                            p5.Value = shift.IsForSale;

                            command.Parameters.Add(p1);
                            command.Parameters.Add(p2);
                            command.Parameters.Add(p3);
                            command.Parameters.Add(p4);
                            command.Parameters.Add(p5);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("" + e.Message + e.StackTrace);
            }
        }

        public void AddShiftsFromSchedule(Schedule schedule)
        {
            try
            {
                using (SqlConnection connection = new DbConnection().GetConnection())
                {
                    foreach (ScheduleShift shift in schedule.Shifts)
                    {
                        if (shift.Id == 0)
                        {
                            using (SqlCommand command = connection.CreateCommand())
                            {
                                command.CommandText = "INSERT INTO Shift(startTime, hours, scheduleId, employeeId, isForSale) " +
                                                        "VALUES (@param1, @param2, @param3, @param4, @param5)";

                                SqlParameter p1 = new SqlParameter("@param1", SqlDbType.DateTime);
                                SqlParameter p2 = new SqlParameter("@param2", SqlDbType.Float);
                                SqlParameter p3 = new SqlParameter("@param3", SqlDbType.Int);
                                SqlParameter p4 = new SqlParameter("@param5", SqlDbType.Int);
                                SqlParameter p5 = new SqlParameter("@param4", SqlDbType.Bit);

                                p1.Value = shift.StartTime;
                                p2.Value = shift.Hours;
                                p3.Value = schedule.Id;
                                p4.Value = shift.Employee.Id;
                                p5.Value = shift.IsForSale;

                                command.Parameters.Add(p1);
                                command.Parameters.Add(p2);
                                command.Parameters.Add(p3);
                                command.Parameters.Add(p4);
                                command.Parameters.Add(p5);

                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            UpdateScheduleShift(shift, schedule.Id, connection);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong In AddShiftsFromScheduleToDB!" + e.Message);
            }
        }

        public void UpdateScheduleShift(ScheduleShift shift, int scheduleId, SqlConnection connection)
        {
            try
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE shift SET startTime = @param1, hours = @param2, scheduleId = @param3, IsForSale = @param4 WHERE shift.id = @param5";

                    SqlParameter p1 = new SqlParameter("@param1", SqlDbType.DateTime, 100);
                    SqlParameter p2 = new SqlParameter("@param2", SqlDbType.Float);
                    SqlParameter p3 = new SqlParameter("@param3", SqlDbType.Int);
                    SqlParameter p4 = new SqlParameter("@param4", SqlDbType.Bit);
                    SqlParameter p5 = new SqlParameter("@param5", SqlDbType.Int);

                    p1.Value = shift.StartTime;
                    p2.Value = shift.Hours;
                    p3.Value = scheduleId;
                    p4.Value = shift.IsForSale;
                    p5.Value = shift.Id;

                    command.Parameters.Add(p1);
                    command.Parameters.Add(p2);
                    command.Parameters.Add(p3);
                    command.Parameters.Add(p4);
                    command.Parameters.Add(p5);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong in UpdateShifts!" + e.Message);
            }
        }

        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            try
            {
                using (SqlConnection connection = new DbConnection().GetConnection())
                {

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Shift SET employeeId = @param1, isForSale = 0 WHERE id = @param2;";

                        SqlParameter p1 = new SqlParameter("@param1", SqlDbType.Int);
                        SqlParameter p2 = new SqlParameter("@param2", SqlDbType.Int);

                        p1.Value = employee.Id;
                        p2.Value = shift.Id;

                        command.Parameters.Add(p1);
                        command.Parameters.Add(p2);

                        command.ExecuteNonQuery();
                    }


                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong accepting shift" + e.Message);
            }
        }

        public ScheduleShift BuildShiftObject(SqlDataReader reader)
        {
            ScheduleShift scheduleShift = new ScheduleShift();
            scheduleShift.Id = reader.GetInt32(0);
            scheduleShift.Employee = new EmployeeRepository().FindEmployeeById(Convert.ToInt32(reader["EmployeeId"].ToString()));
            scheduleShift.StartTime = reader.GetDateTime(1);
            scheduleShift.Hours = Convert.ToDouble(reader["Hours"].ToString());
            scheduleShift.IsForSale = Convert.ToBoolean(reader["IsForSale"]);
            return scheduleShift;
        }
    }
}
