using Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess
{
    class TempShiftDB
    {
        public void AddTempScheduleToDB(List<TempShift> TShift)
        {
            using (DbConnectionADO dBCon = new DbConnectionADO())
            {
                dBCon.OpenConnection();
                SqlCommand insertTempShift = new SqlCommand("INSERT INTO TempShift(weekNumber, hours, startTime, shiftEmployee)   VALUES(@param1,@param2,@param3,@param4)");
                foreach (TempShift ts in TShift)
                {
                    insertTempShift.Parameters.AddWithValue("@param1", ts.WeekNumber);
                    insertTempShift.Parameters.AddWithValue("@param2", ts.Hours);
                    insertTempShift.Parameters.AddWithValue("@param3", ts.StartTime);
                    insertTempShift.Parameters.AddWithValue("@param4", ts.ShiftEmployee);

                    insertTempShift.ExecuteNonQuery();
                }
                dBCon.CloseConnection();
            }
        }
    }
}
