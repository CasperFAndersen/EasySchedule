using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.DatabaseAccess;

namespace Tests
{
    [TestClass]
    public class SetUpDb
    {
        [TestMethod]
        public void SetUpDatabase()
        {
            DBSetUp.SetUpDB();
        }
    }
}
