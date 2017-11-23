using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DBConnectionControllercs
    {
        public bool DBConnectionStatus()
        {
            DbConnectionADO dbConADO = new DbConnectionADO();
            bool status = false;
            var thread = new Thread(() =>
            {
                using (SqlConnection dBCon = new SqlConnection(dbConADO.KrakaConnectionString()))
                {
                   try
                   {
                        dBCon.Open();
                        status = true;
                   }
                   catch (SqlException)
                   {
                     status = false;
                   } 
                }
            });
            thread.Start();
            Thread.Sleep(5000);
            return status;
        }
    }
}
