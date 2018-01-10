using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseAccess.Tests
{
    [TestClass]
    public class DatabaseConnectionTests
    {
        [TestMethod]
        public void ConnectToDatabaseTest()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.OpenConnection();
            Assert.IsTrue(dbConnection.IsConnected());
            Assert.IsNotNull(dbConnection);
            dbConnection.CloseConnection();
        }

        [TestMethod]
        public void DisconnectFromDatabaseTest()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.OpenConnection();
            dbConnection.CloseConnection();
            Assert.IsTrue(dbConnection.IsDisconnected());
        }
    }
}
