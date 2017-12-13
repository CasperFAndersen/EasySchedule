using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Core;
using DatabaseAccess.Employees;

namespace DatabaseAccess.TemplateShifts
{
    public class TemplateShiftRepository : ITemplateShiftRepository
    {
        public void AddTemplateShiftsFromTemplateSchedule(int templateScheduleId, List<TemplateShift> templateShifts)
        {
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                foreach (TemplateShift templateShift in templateShifts)
                {
                    using (SqlCommand insertTemplateShift = new SqlCommand(
                            "INSERT INTO TemplateShift " +
                            "(weekDay, hours, startTime, weekNumber, templateScheduleId, employeeId) " +
                            "VALUES (@param1,@param2,@param3,@param4,@param5,@Param6)", connection))
                    {
                        if (templateShift.Id == 0)
                        {
                            insertTemplateShift.Parameters.AddWithValue("@param1", templateShift.WeekDay.ToString());
                            insertTemplateShift.Parameters.AddWithValue("@param2", templateShift.Hours);
                            insertTemplateShift.Parameters.AddWithValue("@param3", templateShift.StartTime);
                            insertTemplateShift.Parameters.AddWithValue("@param4", templateShift.WeekNumber);
                            insertTemplateShift.Parameters.AddWithValue("@param5", templateScheduleId);
                            insertTemplateShift.Parameters.AddWithValue("@param6", templateShift.Employee.Id);

                            insertTemplateShift.ExecuteNonQuery();
                        }
                        else
                        {
                            UpdateTemplateScheduleShift(templateShift, connection);
                        }
                    }
                }
            }

        }

        public void UpdateTemplateScheduleShift(TemplateShift templateShift, SqlConnection connection)
        {
            using (SqlCommand updateTemplateShift = new SqlCommand(
                 "UPDATE TemplateShift SET " +
                 "weekday = @param1, hours = @param2, " +
                 "startTime = @param3 WHERE id = @param4",
                connection))
            {
                updateTemplateShift.Parameters.AddWithValue("@param1", templateShift.WeekDay.ToString());
                updateTemplateShift.Parameters.AddWithValue("@param2", templateShift.Hours);
                updateTemplateShift.Parameters.AddWithValue("@param3", templateShift.StartTime);
                updateTemplateShift.Parameters.AddWithValue("@param4", templateShift.Id);

                updateTemplateShift.ExecuteNonQuery();
            }
        }

        public List<TemplateShift> GetAllTemplateShifts()
        {
            List<TemplateShift> templateShifts = new List<TemplateShift>();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateShift", connection))
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
            }
            return templateShifts;
        }

        public List<TemplateShift> GetTemplateShiftsByTemplateScheduleId(int templateScheduleId)
        {
            List<TemplateShift> templateShifts = new List<TemplateShift>();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateShift WHERE templateScheduleId = @param1", connection))
                {
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.Int);
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
            }
            return templateShifts;
        }

        /// <summary>
        /// This method builds a TemplateShift object based on information retrieved from the database.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Returns a TemplateShift object.
        /// </returns>
        public TemplateShift BuildTemplateShiftObject(SqlDataReader reader)
        {
            TemplateShift templateShiftObject = new TemplateShift();
            templateShiftObject.Id = reader.GetInt32(0);
            templateShiftObject.WeekDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), reader.GetString(1));
            templateShiftObject.Hours = reader.GetDouble(2);
            templateShiftObject.StartTime = reader.GetTimeSpan(3);
            templateShiftObject.WeekNumber = reader.GetInt32(4);
            templateShiftObject.TemplateScheduleId = reader.GetInt32(5);
            templateShiftObject.Employee = new Employee() { Id = reader.GetInt32(6) }; //Creates dumme-employee-object
            return templateShiftObject;
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            TemplateShift templateShift = null;
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                //connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateShift WHERE ID = @param1", connection))
                {
                    command.Parameters.AddWithValue("@param1", templateShiftId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            templateShift = BuildTemplateShiftObject(reader);
                        }
                    }
                }
            }
            return templateShift;
        }

        /// <summary>
        /// This method returns the current day of the week.
        /// </summary>
        /// <param name="day"></param>
        /// <returns>
        /// The current day of the week.
        /// </returns>
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
