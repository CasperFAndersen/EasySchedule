using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DatabaseAccess.TemplateSchedule
{
    public class TemplateScheduleRepository
    {
        DbConnection databaseConnection = new DbConnection();

        public IEnumerable<Core.TemplateSchedule> GetAll()
        {
            List<Core.TemplateSchedule> tempList = new List<Core.TemplateSchedule>();
            using (SqlConnection dbCon = new SqlConnection(databaseConnection.KrakaConnectionString()))
            {
                dbCon.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM TemplateSchedule", dbCon);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Core.TemplateSchedule tempSchedule = new Core.TemplateSchedule(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        tempSchedule.ListOfTempShifts = new TemplateShiftRepository().GetTemplateShiftsByTemplateScheduleId(tempSchedule.Id);
                        tempList.Add(tempSchedule);
                    }
                }
                dbCon.Close();
            }
            return tempList;
        }

        public void AddTempScheduleToDb(Core.TemplateSchedule tSchedule)
        {
            TemplateShiftRepository templateShiftRepository = new TemplateShiftRepository();
            using (SqlConnection dBCon = new SqlConnection(databaseConnection.KrakaConnectionString()))
            {
                dBCon.Open();
                int templateScheduleId;
                using (SqlCommand insertTempSchedule = new SqlCommand("INSERT INTO TemplateSchedule (name, NoOfWeeks, departmentID) " +
                                                                        "VALUES (@param1,@param2,@param3) SELECT SCOPE_IDENTITY()", dBCon))
                {
                    insertTempSchedule.Parameters.AddWithValue("@param1", tSchedule.Name);
                    insertTempSchedule.Parameters.AddWithValue("@param2", tSchedule.NoOfWeeks);
                    insertTempSchedule.Parameters.AddWithValue("@param3", tSchedule.DepartmentId);
                    templateScheduleId = Convert.ToInt32(insertTempSchedule.ExecuteScalar());
                    dBCon.Close();
                }
                templateShiftRepository.AddTempShiftsFromTempScheduleToDB(templateScheduleId, tSchedule.ListOfTempShifts);
            }
        }

        public Core.TemplateSchedule FindTempScheduleByName(string scheduleName)
        {
            Core.TemplateSchedule templateSchedule = null;
            using (SqlConnection dBCon = new SqlConnection(databaseConnection.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM TemplateSchedule WHERE Name = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", scheduleName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        templateSchedule = new Core.TemplateSchedule(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        templateSchedule.ListOfTempShifts = new TemplateShiftRepository().GetTemplateShiftsByTemplateScheduleId(templateSchedule.Id);
                    }
                }
                dBCon.Close();
            }
            return templateSchedule;
        }

        public void UpdateTemplateSchedule(Core.TemplateSchedule templateSchedule)
        {
            using (SqlConnection dBCon = new SqlConnection(databaseConnection.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("UPDATE TemplateSchedule SET noOfWeeks = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", templateSchedule.NoOfWeeks);
                command.ExecuteNonQuery();

                TemplateShiftRepository templateShiftRepository = new TemplateShiftRepository();
                templateShiftRepository.AddTempShiftsFromTempScheduleToDB(templateSchedule.Id, templateSchedule.ListOfTempShifts);

                dBCon.Close();
            }
        }
    }
}
