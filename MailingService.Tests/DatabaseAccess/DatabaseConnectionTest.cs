using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class DatabaseConnectionTest
    {
        [TestMethod]
        public void TestConnectToDatabase()
        {
           DbConnection dbConnection = new DbConnection();
            dbConnection.OpenConnection();
            Assert.IsTrue(dbConnection.IsConnected());
            Assert.IsNotNull(dbConnection);
            dbConnection.CloseConnection();
        }

        [TestMethod]
        public void TestDisconnectFromDatabase()
        {
            DbConnection dbConnection = new DbConnection();
            dbConnection.OpenConnection();
            dbConnection.CloseConnection();
            Assert.IsTrue(dbConnection.IsDisconnected());
        }
    }
}
