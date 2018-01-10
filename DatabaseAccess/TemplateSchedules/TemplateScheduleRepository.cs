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

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = new SqlCommand(
                    "UPDATE TemplateSchedule SET noOfWeeks = @param1 " +
                     "WHERE RV = @param2", connection))
                {
                    command.Parameters.AddWithValue("@param1", templateSchedule.NoOfWeeks);
                    command.Parameters.AddWithValue("@param2", templateSchedule.RowVersion);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new DataInInvalidStateException();
                    }
                }
            }
        }

        public TemplateSchedule BuildTemplateScheduleObject(SqlDataReader reader)
        {
            TemplateSchedule templateSchedule = new TemplateSchedule();
            templateSchedule.Id = reader.GetInt32(0);
            templateSchedule.Name = reader.GetString(1);
            templateSchedule.NoOfWeeks = reader.GetInt32(2);
            templateSchedule.DepartmentId = reader.GetInt32(3);
            templateSchedule.RowVersion = reader.GetFieldValue<byte[]>(4);
            return templateSchedule;
        }
    }
}
