using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class SetupDatabaseTests
    {
        [TestMethod]
        public void _SetupDatabaseTest()
        {
            DbSetUp.SetUpDb();
        }
    }
}
