﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.Data.SqlClient;
using System.Data.Common;

namespace DatabaseAccess
{
    public class TemplateScheduleRepository
    {
        DbConnectionADO dbConADO = new DbConnectionADO();

        public IEnumerable<TemplateSchedule> GetAll()
        {
            List<TemplateSchedule> tempList = new List<TemplateSchedule>();
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM TemplateSchedule", dBCon);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TemplateSchedule tempSchedule = new TemplateSchedule(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        tempSchedule.ListOfTempShifts = new TemplateShiftRepository().GetTempShiftsByTempScheduleID(tempSchedule.ID);
                        tempList.Add(tempSchedule);
                    }
                }
                dBCon.Close();
            }
            return tempList;
        }

        public void AddTempScheduleToDB(TemplateSchedule tSchedule)
        {
            TemplateShiftRepository tempShiftRepository = new TemplateShiftRepository();
            int tempScheduleID;
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                using (SqlCommand insertTempSchedule = new SqlCommand("INSERT INTO TemplateSchedule (name, NoOfWeeks, departmentID)  VALUES(@param1,@param2,@param3) SELECT SCOPE_IDENTITY()", dBCon))
                {
                    insertTempSchedule.Parameters.AddWithValue("@param1", tSchedule.Name);
                    insertTempSchedule.Parameters.AddWithValue("@param2", tSchedule.NoOfWeeks);
                    insertTempSchedule.Parameters.AddWithValue("@param3", tSchedule.DepartmentID);
                    tempScheduleID = Convert.ToInt32(insertTempSchedule.ExecuteScalar());
                    dBCon.Close();
                }
                tempShiftRepository.AddTempShiftsFromTempScheduleToDB(tempScheduleID, tSchedule.ListOfTempShifts);
            }
        }

        

        public TemplateSchedule FindTempScheduleByName(string scheduleName)
        {
            TemplateSchedule tSchedule = null;
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM TemplateSchedule WHERE Name = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", scheduleName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tSchedule = new TemplateSchedule(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3));
                        tSchedule.ListOfTempShifts = new TemplateShiftRepository().GetTempShiftsByTempScheduleID(tSchedule.ID);
                    }
                }
                dBCon.Close();
            }
            return tSchedule;
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
            {
                dBCon.Open();
                SqlCommand command = new SqlCommand("UPDATE TemplateSchedule SET noOfWeeks = @param1", dBCon);
                command.Parameters.AddWithValue("@param1", templateSchedule.NoOfWeeks);
                command.ExecuteNonQuery();

                TemplateShiftRepository templateShiftRepository = new TemplateShiftRepository();
                templateShiftRepository.AddTempShiftsFromTempScheduleToDB(templateSchedule.ID, templateSchedule.ListOfTempShifts);

                dBCon.Close();
            }
        }
    }
}