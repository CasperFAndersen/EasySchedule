using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.Data;

namespace DatabaseAccess
{
    public class DbConnectionADO : IDisposable
    {
        private SqlConnection connection;
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DbConnectionADO()
        {
            connection = new SqlConnection(KrakaConnectionString());
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

        public bool IsConnected()
        {
            return connection.State == ConnectionState.Open;
        }

        public bool IsDisconnected()
        {
            return connection.State == ConnectionState.Closed;
        }

        public string LocalConnectionString()
        {
            Server = ".\\sqlexpress";
            Database = "Semester3DB";
            return "Data Source=" + Server + ";Initial Catalog=" + Database + ";Integrated Security=True";
        }

        public string KrakaConnectionString()
        {
            Server = "kraka.ucn.dk";
            Database = "dmab0916_1062358";
            Username = "dmab0916_1062358";
            Password = "Password1!";
            return "Data Source=" + Server + "; Initial Catalog=" + Database + ";User Id=" + Username + ";Password=" + Password + ";";
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
