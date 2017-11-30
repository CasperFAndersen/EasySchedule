using Core;
using DatabaseAccess.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    public class TemplateShiftRepository
    {
        DbConnection dbConnection = new DbConnection();

        public void AddTempShiftsFromTempScheduleToDB(int templateScheduleIdFromDb, List<TemplateShift> templateShifts)
        {
            using (SqlConnection dBCon = new SqlConnection(dbConnection.KrakaConnectionString()))
            {
                dBCon.Open();
                foreach (TemplateShift ts in templateShifts)
                {
                    SqlCommand insertTempShift = new SqlCommand("INSERT INTO TemplateShift(weekDay, hours, startTime, weekNumber, templateScheduleId, employeeId)   VALUES(@param1,@param2,@param3,@param4,@param5,@Param6)", dBCon);
                    if (ts.Id == 0)
                    {
                        insertTempShift.Parameters.AddWithValue("@param1", ts.WeekDay.ToString());
                        insertTempShift.Parameters.AddWithValue("@param2", ts.Hours);
                        insertTempShift.Parameters.AddWithValue("@param3", ts.StartTime);
                        insertTempShift.Parameters.AddWithValue("@param4", ts.WeekNumber);
                        insertTempShift.Parameters.AddWithValue("@param5", templateScheduleIdFromDb);
                        insertTempShift.Parameters.AddWithValue("@param6", ts.Employee.Id);

                        insertTempShift.ExecuteNonQuery();
                    }
                    else
                    {
                        UpdateTemplateScheduleShift(ts);
                    }
                }
                dBCon.Close();
            }
        }

        public void UpdateTemplateScheduleShift(TemplateShift templateShift)
        {
            using (SqlConnection dBCon = new SqlConnection(dbConnection.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand updateTemplateShift = new SqlCommand("UPDATE TemplateShift SET weekday = @param1, hours = @param2, startTime = @param3 WHERE id = @param4", dBCon);

                updateTemplateShift.Parameters.AddWithValue("@param1", templateShift.WeekDay.ToString());
                updateTemplateShift.Parameters.AddWithValue("@param2", templateShift.Hours);
                updateTemplateShift.Parameters.AddWithValue("@param3", templateShift.StartTime);
                updateTemplateShift.Parameters.AddWithValue("@param4", templateShift.Id);

                updateTemplateShift.ExecuteNonQuery();

                dBCon.Close();
            }
        }

        public IEnumerable<TemplateShift> GetAllShifts()
        {
            List<TemplateShift> templateShifts = new List<TemplateShift>();
            using (SqlConnection dBCon = new SqlConnection(dbConnection.KrakaConnectionString()))
            {
                dBCon.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateShift", dBCon))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TemplateShift templateShift = BuildTemplateShiftObject(reader);
                            templateShifts.Add(templateShift);
                        }
                    }
                }
                dBCon.Close();
            }
            return templateShifts;
        }

        public List<TemplateShift> GetTemplateShiftsByTemplateScheduleId(int templateScheduleId)
        {
            List<TemplateShift> templateShifts = new List<TemplateShift>();
            using (SqlConnection dBCon = new SqlConnection(dbConnection.KrakaConnectionString()))
            {
                dBCon.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateShift WHERE templateScheduleId = @param1", dBCon))
                {
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.Int, 100);
                    p1.Value = templateScheduleId;
                    command.Parameters.Add(p1);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TemplateShift templateShift = BuildTemplateShiftObject(reader);
                            templateShifts.Add(templateShift);
                        }
                    }
                }
                dBCon.Close();
            }
            return templateShifts;
        }

        public TemplateShift BuildTemplateShiftObject(SqlDataReader reader)
        {
            TemplateShift templateShiftObject = new TemplateShift();
            templateShiftObject.Id = reader.GetInt32(0);
            templateShiftObject.WeekDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), reader.GetString(1));
            templateShiftObject.Hours = reader.GetDouble(2);
            templateShiftObject.StartTime = reader.GetTimeSpan(3);
            templateShiftObject.WeekNumber = reader.GetInt32(4);
            templateShiftObject.TemplateScheduleId = reader.GetInt32(5);
            templateShiftObject.Employee = new EmployeeRepository().FindEmployeeById(reader.GetInt32(6));
            return templateShiftObject;
        }

        public TemplateShift FindTempShiftById(int tempShiftId)
        {
            TemplateShift templateShift = null;
            using (SqlConnection dBCon = new SqlConnection(dbConnection.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM TemplateShift WHERE ID = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", tempShiftId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        templateShift = BuildTemplateShiftObject(reader);
                    }
                }
                dBCon.Close();
            }
            return templateShift;
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
                    currentDay = DayOfWeek.Wednesday;
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
