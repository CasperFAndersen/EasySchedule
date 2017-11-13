using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;

namespace DatabaseAccess
{
    public class DbConnectionADO
    {
        private SqlConnection connection;
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DbConnectionADO()
        {
            connection = new SqlConnection(LocalConnectionString);
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string LocalConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["LocalDB"].ToString();
            }
        }

        public static string KrakaConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["KrakaDB"].ToString();
            }
        }

    }
}
