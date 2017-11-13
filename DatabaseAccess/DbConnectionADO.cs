using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

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
            Initialize();
        }

        private void Initialize()
        {
            connection = new SqlConnection(GetConnectionString());
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

        private string GetLocalConnectionString()
        {
            string connectionString =
                "Server=localhost;Initial Catalog=Semester3DB; Integrated Security =True;";

            return connectionString;
        }

        private string GetKrakaConnectionString()
        {
            string connectionString = null;
            return connectionString;
        }

    }
}
