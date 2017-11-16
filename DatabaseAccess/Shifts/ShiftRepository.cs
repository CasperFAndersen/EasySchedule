using Core;
using DatabaseAccess.Employees;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseAccess.Shifts
{
    class ShiftRepository : IShiftRepository
    {
        public List<Shift> GetShiftsByScheduleID(int scheduleId)
        {
            List<Shift> shiftList = new List<Shift>();

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

        public List<Shift> GetShiftsByEmployeeId(int employeeId)
        {
            List<Shift> shiftList = new List<Shift>();

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

        public Shift BuildShiftObject(SqlDataReader reader)
        {
            Shift s1 = new Shift();

            s1.Id = Convert.ToInt32(reader["Id"].ToString());
            s1.Employee = new EmployeeRepository().FindEmployeeById(Convert.ToInt32(reader["EmployeeId"].ToString()));
            s1.StartTime = Convert.ToDateTime(reader["Starttime"].ToString());
            s1.Hours = Convert.ToDouble(reader["Hours"].ToString());

            return s1;
        }
    }
}
