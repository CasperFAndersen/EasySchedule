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
                    insertTempShift.Parameters.AddWithValue("@param5", ts.EmployeeID);

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
                            // TimeSpan myTimeSpan = ((SqlDataReader)reader).GetTimeSpan(3);
                            TimeSpan S = new TimeSpan(1, 2, 3);

                            TemplateShift tempShift = new TemplateShift(Convert.ToInt32(reader["Id"].ToString()),
                                                                        GetDayOfweekBasedOnString(reader["weekday"].ToString()),
                                                                        Convert.ToDouble(reader["hours"].ToString()),
                                                                        S,
                                                                        Convert.ToInt32(reader["templateScheduleId"].ToString()),
                                                                        Convert.ToInt32(reader["employeeId"].ToString()));
                                                                        
                            tempList.Add(tempShift);
                        }
                    }
                }
                dBCon.Close();
            }
            return tempList;
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
                        tShift = new TemplateShift(reader.GetInt32(0), GetDayOfweekBasedOnString(reader.GetString(1)), reader.GetFloat(2), new TimeSpan(reader.GetDateTime(3).Hour, reader.GetDateTime(3).Minute, reader.GetDateTime(3).Second), reader.GetInt32(4),  reader.GetInt32(5));
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
