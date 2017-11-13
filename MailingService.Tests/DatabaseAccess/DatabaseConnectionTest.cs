using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class DatabaseConnectionTest
    {
        [TestMethod]
        public void ConnectToDatabase()
        {
           DbConnectionADO dbConnection = new DbConnectionADO();
            dbConnection.OpenConnection();
            Assert.IsTrue(dbConnection.IsConnected());
            Assert.IsNotNull(dbConnection);
            dbConnection.CloseConnection();
        }

        [TestMethod]
        public void DisconnectFromDatabase()
        {
            DbConnectionADO dbConnection = new DbConnectionADO();
            dbConnection.OpenConnection();
            dbConnection.CloseConnection();
            Assert.IsFalse(dbConnection.IsConnected());
        }
    }
}
