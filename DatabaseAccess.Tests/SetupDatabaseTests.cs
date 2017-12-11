using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseAccess.Tests
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
