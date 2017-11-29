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
        public List<ScheduleShift> GetShiftsByScheduleID(int scheduleId)
        {
            List<ScheduleShift> shiftList = new List<ScheduleShift>();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT * FROM shift WHERE shift.scheduleId = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", System.Data.SqlDbType.Int);
                    p1.Value = scheduleId;

                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        shiftList.Add(BuildShiftObject(reader));
                    }


                    conn.Close();

                    return shiftList; ;
                }

            }

        }

        public List<ScheduleShift> GetShiftsByEmployeeId(int employeeId)
        {
            List<ScheduleShift> shiftList = new List<ScheduleShift>();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM shift WHERE shift.employeeId = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", System.Data.SqlDbType.Int);
                    p1.Value = employeeId;

                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        shiftList.Add(BuildShiftObject(reader));
                    }
                    conn.Close();

                    return shiftList; ;
                }
            }
        }

        public void InsertShiftsIntoDb(List<ScheduleShift> shifts, int scheduleId, SqlConnection conn)
        {
            try
            {

                using (conn)
                {
                    foreach (var shift in shifts)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {

                            cmd.CommandText = "INSERT INTO Shift (startTime, hours, scheduleId, employeeId)" +
                                              " VALUES (@param1, @param2, @param3, @param4);";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.SmallDateTime, 100);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.Int, 100);
                            SqlParameter p3 = new SqlParameter(@"param3", SqlDbType.Int, 100);
                            SqlParameter p4 = new SqlParameter(@"param4", SqlDbType.Int, 100);


                            p1.Value = shift.StartTime;
                            p2.Value = shift.Hours;
                            p3.Value = scheduleId;
                            p4.Value = shift.Employee.Id;

                            cmd.Parameters.Add(p1);
                            cmd.Parameters.Add(p2);
                            cmd.Parameters.Add(p3);
                            cmd.Parameters.Add(p4);


                            cmd.ExecuteNonQuery();

                        }

                    }

                }

            }
            catch (Exception e)
            {

                throw new Exception("" + e.Message + e.StackTrace);
            }
        }

        public void AddShiftsFromScheduleToDb(Schedule schedule)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    using (SqlConnection conn = new DbConnectionADO().GetConnection())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {

                            foreach (ScheduleShift shift in schedule.Shifts)
                            {
                                cmd.CommandText = "INSERT INTO Shift(startTime, hours, scheduleId, employeeId) VALUES (@param1, @param2, @param3, @param4)";
                                if (shift.Id == 0)
                                {
                                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.DateTime, 100);
                                    SqlParameter p2 = new SqlParameter(@"param1", SqlDbType.Int, 100);
                                    SqlParameter p3 = new SqlParameter(@"param1", SqlDbType.Int, 100);
                                    SqlParameter p4 = new SqlParameter(@"param1", SqlDbType.Int, 100);

                                    p1.Value = shift.StartTime;
                                    p2.Value = shift.Hours;
                                    p3.Value = schedule.Id;
                                    p4.Value = shift.Employee.Id;

                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    UpdateScheduleShift(shift, schedule.Id, conn);
                                }


                            }


                            scope.Complete();
                        }

                    }

                }


            }
            catch (Exception e)
            {

                throw new Exception("Something went wrong!" + e.Message);
            }

        }

        public void UpdateScheduleShift(ScheduleShift shift, int scheduleId, SqlConnection conn)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    using (conn)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "UPDATE shift SET startTime = @param1, hours = @param2, scheduleId = @param3, employeeId = param4";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.DateTime, 100);
                            SqlParameter p2 = new SqlParameter(@"param1", SqlDbType.Int, 100);
                            SqlParameter p3 = new SqlParameter(@"param1", SqlDbType.Int, 100);
                            SqlParameter p4 = new SqlParameter(@"param1", SqlDbType.Int, 100);

                            p1.Value = shift.StartTime;
                            p2.Value = shift.Hours;
                            p3.Value = scheduleId;
                            p4.Value = shift.Employee.Id;

                            cmd.ExecuteNonQuery();
                        }
                    }

                    scope.Complete();
                }

            }
            catch (Exception e)
            {

                throw new Exception("Something went wrong!" + e.Message);
            }
        }

        public ScheduleShift BuildShiftObject(SqlDataReader reader)
        {
            ScheduleShift s1 = new ScheduleShift();

            s1.Id = Convert.ToInt32(reader["Id"].ToString());
            s1.Employee = new EmployeeRepository().FindEmployeeById(Convert.ToInt32(reader["EmployeeId"].ToString()));
            s1.StartTime = Convert.ToDateTime(reader["Starttime"].ToString());
            s1.Hours = Convert.ToDouble(reader["Hours"].ToString());

            return s1;
        }
    }
}
