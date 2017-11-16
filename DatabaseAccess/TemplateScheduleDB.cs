using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Data.SqlClient;
using System.Data.Common;

namespace DatabaseAccess
{
    public class TemplateScheduleDB
    {
        DbConnectionADO dbConADO = new DbConnectionADO();

        public IEnumerable<TemplateSchedule> GetAll()
        {
            List<TemplateSchedule> tempList = new List<TemplateSchedule>();
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM TempSchedule", dBCon);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TemplateSchedule tempSchedule = new TemplateSchedule(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        tempList.Add(tempSchedule);
                    }
                }
                dBCon.Close();
            }
            return tempList;
        }

        public void AddTempScheduleToDB(TemplateSchedule tSchedule)
        {
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand insertTempSchedule = new SqlCommand("INSERT INTO TemplateSchedule (name, NoOfWeeks, departmentID)  VALUES(@param1,@param2,@param3)", dBCon);
                
                insertTempSchedule.Parameters.AddWithValue("@param1", tSchedule.Name);
                insertTempSchedule.Parameters.AddWithValue("@param2", tSchedule.NoOfWeeks);
                insertTempSchedule.Parameters.AddWithValue("@param3", tSchedule.DepartmentID);
                insertTempSchedule.ExecuteNonQuery();

                dBCon.Close();
            }
        }

        public TemplateSchedule FindTempScheduleByName(string scheduleName)
        {
            TemplateSchedule tSchedule = new TemplateSchedule();
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("SELECT TemplateSchedule FROM TemplateSchedule WHERE Name = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", scheduleName);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tSchedule = new TemplateSchedule(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                    }
                }
                dBCon.Close();
            }
            return tSchedule;
        }
    }
}
