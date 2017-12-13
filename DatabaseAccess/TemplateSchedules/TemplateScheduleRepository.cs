using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Core;
using DatabaseAccess.TemplateShifts;
using System.Transactions;

namespace DatabaseAccess.TemplateSchedules
{
    public class TemplateScheduleRepository : ITemplateScheduleRepository
    {
        public IEnumerable<TemplateSchedule> GetAllTemplateSchedules()
        {
            List<TemplateSchedule> templateSchedules = new List<TemplateSchedule>();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateSchedule", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TemplateSchedule templateSchedule = new TemplateSchedule(reader.GetInt32(0), reader.GetString(1),
                                                                                 reader.GetInt32(2), reader.GetInt32(3));
                        }
                    }
                }
            }
            return templateSchedules;
        }

        public void AddTemplateScheduleToDatabase(TemplateSchedule templateSchedule)
        {
            int templateScheduleId;

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = new SqlCommand(
                    "INSERT INTO TemplateSchedule (name, NoOfWeeks, departmentID) " +
                    "VALUES (@param1,@param2,@param3) SELECT SCOPE_IDENTITY()", connection))
                {
                    command.Parameters.AddWithValue("@param1", templateSchedule.Name);
                    command.Parameters.AddWithValue("@param2", templateSchedule.NoOfWeeks);
                    command.Parameters.AddWithValue("@param3", templateSchedule.DepartmentId);
                    templateScheduleId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        //Do we need this???
        public TemplateSchedule GetTemplateScheduleByName(string scheduleName)
        {
            TemplateSchedule templateSchedule = null;
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM TemplateSchedule WHERE Name = @param1", connection))
                {
                    command.Parameters.AddWithValue("@param1", scheduleName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            templateSchedule = new TemplateSchedule(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));

                        }
                    }
                }
            }
            return templateSchedule;
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = new SqlCommand("UPDATE TemplateSchedule SET noOfWeeks = @param1", connection))
                {
                    command.Parameters.AddWithValue("@param1", templateSchedule.NoOfWeeks);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
