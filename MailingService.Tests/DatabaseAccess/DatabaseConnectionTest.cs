﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.IsNotNull(dbConnection);
            dbConnection.CloseConnection();
        }
    }
}
