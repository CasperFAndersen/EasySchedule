using Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class TemplateShiftDB
    {

        DbConnectionADO dbConADO = new DbConnectionADO();



        public void AddTempShiftsFromTempScheduleToDB(int tempScheduleIDFromDB, List<TemplateShift> TShift)
        {
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand insertTempShift = new SqlCommand("INSERT INTO TemplateShift(weekDay, hours, startTime, templateScheduleId, employeeId)   VALUES(@param1,@param2,@param3,@param4,@param5)", dBCon);
                foreach (TemplateShift ts in TShift)
                {
                    insertTempShift.Parameters.AddWithValue("@param1", ts.WeekDay.ToString());
                    insertTempShift.Parameters.AddWithValue("@param2", ts.Hours);
                    insertTempShift.Parameters.AddWithValue("@param3", ts.StartTime);
                    insertTempShift.Parameters.AddWithValue("@param4", tempScheduleIDFromDB);
                    insertTempShift.Parameters.AddWithValue("@param5", ts.Employee.Id);

                    insertTempShift.ExecuteNonQuery();
                }
                dBCon.Close();
            }
        }

        public IEnumerable<TemplateShift> getAllShifts()
        {
            List<TemplateShift> tempList = new List<TemplateShift>();
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateSchedule", dBCon))
                {
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {

                                TemplateShift tempShift = new TemplateShift();
                                tempShift.ID = reader.GetOrdinal("Id");
                                tempShift.WeekDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), reader.GetOrdinal("weekDay").ToString());
                                tempShift.Hours = reader.GetOrdinal("Hours");
                                tempShift.StartTime = TimeSpan.Parse(reader.GetOrdinal("StartTime").ToString());
                                tempShift.TemplateScheduleID = reader.GetOrdinal("TemplateScheduleId");
                                tempShift.Employee.Id = reader.GetOrdinal("EmployeeId");

                                TemplateShift tempShift = new TemplateShift
                                {
                                    ID = reader.GetOrdinal("Id"),
                                    WeekDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), reader.GetOrdinal("weekDay").ToString()),
                                    Hours = reader.GetOrdinal("Hours"),
                                    StartTime = TimeSpan.Parse(reader.GetOrdinal("StartTime").ToString()),
                                    TemplateScheduleID = reader.GetOrdinal("TemplateScheduleId")
                                };
                                tempShift.Employee.Id = reader.GetOrdinal("EmployeeId"); 


                            tempList.Add(tempShift);
                            }
                        }
                    }
                }
                dBCon.Close();
            }
            return tempList;
        }

        public IEnumerable<TemplateShift> getAllShiftsV2()
        {
            List<TemplateShift> res = new List<TemplateShift>();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT * FROM TemplateSchedule";
                   

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        TemplateShift tempShift = new TemplateShift();
                        tempShift.ID = Convert.ToInt32(reader["id"].ToString());
                        tempShift.WeekDay = GetDayOfweekBasedOnString(reader[1].ToString());
                        tempShift.Hours = Convert.ToDouble(reader[2].ToString());
                        tempShift.StartTime = TimeSpan.Parse(reader[3].ToString());
                        //tempShift.TemplateScheduleID = reader.GetInt32(4);
                        //tempShift.Employee = new Employee() { Id = Convert.ToInt32(reader[5].ToString())};

                        res.Add(tempShift);
                    }


                    conn.Close();

                    return res;
                }

            }
        }

        public TemplateShift FindTempShiftByID(int tempShiftID)
        {
            TemplateShift tShift = null;
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM TemplateShift WHERE ID = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", tempShiftID);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tShift = new TemplateShift(reader.GetInt32(0), GetDayOfweekBasedOnString(reader.GetString(1)), reader.GetFloat(2), new TimeSpan(reader.GetDateTime(3).Hour, reader.GetDateTime(3).Minute, reader.GetDateTime(3).Second), reader.GetInt32(4), new Employee() { Id = reader.GetInt32(5) });
                    }
                }
                dBCon.Close();
            }
            return tShift;
        }
        public DayOfWeek GetDayOfweekBasedOnString(string day)
        {
            DayOfWeek currentDay = default(DayOfWeek);
            switch (day)
            {
                case "Monday":
                    currentDay = DayOfWeek.Monday;
                    break;
                case "Tuesday":
                    currentDay = DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    currentDay =  DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    currentDay = DayOfWeek.Thursday;
                    break;
                case "Friday":
                    currentDay = DayOfWeek.Friday;
                    break;
                case "Saturday":
                    currentDay = DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    currentDay = DayOfWeek.Sunday;
                    break;
            }
            return currentDay;
        }
    }
    
}
