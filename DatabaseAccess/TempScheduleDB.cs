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
    public class TempScheduleDB
    {
        DbConnectionADO dbConADO = new DbConnectionADO();

        public IEnumerable<TempSchedule> GetAll()
        {
            List<TempSchedule> tempList = new List<TempSchedule>();
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM TempSchedule", dBCon);
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TempSchedule tempSchedule = new TempSchedule(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                        tempList.Add(tempSchedule);
                    }
                }
                dBCon.Close();
            }
            return tempList;
        }

        public void AddTempScheduleToDB(TempSchedule tSchedule)
        {
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand insertTempSchedule = new SqlCommand("INSERT INTO TempSchedule (noOfWeeks, name)  VALUES(@param1,@param2)", dBCon);
                
                insertTempSchedule.Parameters.AddWithValue("@param1", tSchedule.NoOfWeeks);
                insertTempSchedule.Parameters.AddWithValue("@param2", tSchedule.Name);
                insertTempSchedule.ExecuteNonQuery();

                dBCon.Close();
            }
        }

        public TempSchedule FindTempScheduleByName(string scheduleName)
        {
            TempSchedule tSchedule = new TempSchedule();
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("SELECT TempSchedule FROM TempSchedule WHERE Name = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", scheduleName);

                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tSchedule = new TempSchedule(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2));
                    }
                }
                dBCon.Close();
            }
            return tSchedule;
        }
    }
}
