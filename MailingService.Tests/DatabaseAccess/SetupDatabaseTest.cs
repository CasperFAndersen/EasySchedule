using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class SetupDatabaseTest
    {
        [TestMethod]
        public void TestSetupDatabase()
        {
            DbSetUp.SetUpDb();
        }
    }
}
