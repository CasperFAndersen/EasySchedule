using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.DatabaseAccess;

namespace Tests
{
    [TestClass]
    public class SetUp
    {
        [TestMethod]
        public void SetUpDb()
        {
            DbSetUp.SetUpDb();
        }
    }
}
