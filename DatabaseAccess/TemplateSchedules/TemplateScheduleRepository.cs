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
        public List<TemplateSchedule> GetAllTemplateSchedules()
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

                            TemplateSchedule templateSchedule = BuildTemplateScheduleObject(reader);
                            templateSchedules.Add(templateSchedule);
                        }
                    }
                }
            }
            return templateSchedules;
        }

        public TemplateSchedule BuildTemplateScheduleObject(SqlDataReader reader)
        {
            TemplateSchedule templateSchedule = new TemplateSchedule()
            {
                Id = Convert.ToInt32(reader["id"].ToString()),
                Name = reader["name"].ToString(),
                NoOfWeeks = Convert.ToInt32(reader["noOfWeeks"].ToString()),
                DepartmentId = Convert.ToInt32(reader["departmentId"].ToString())
            };
            return templateSchedule;
        }

        public int AddTemplateScheduleToDatabase(TemplateSchedule templateSchedule)
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
            return templateScheduleId;

        }

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
                            templateSchedule = BuildTemplateScheduleObject(reader);
                        }
                    }
                }
            }
            return templateSchedule;
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection connection = new DbConnection().GetConnection())
                {

                    using (SqlCommand command = new SqlCommand("UPDATE TemplateSchedule SET name = @param1, noOfWeeks = @param2", connection))
                    {
                        command.Parameters.AddWithValue("@param1", templateSchedule.Name);
                        command.Parameters.AddWithValue("@param2", templateSchedule.NoOfWeeks);
                        command.ExecuteNonQuery();
                    }
                }
                scope.Complete();
            }

        }
    }
}
