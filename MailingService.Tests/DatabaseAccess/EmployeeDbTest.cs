using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class EmployeeDbTest
    {
        [TestMethod]
        public void TestGetEmployeeByUsername()
        {
            IEmployeeRepository empRes = new EmployeeRepository();
            Employee emp = empRes.GetEmployeeByUsername("MikkelP");
            Assert.AreEqual("Mikkel Paulsen", empRes.GetEmployeeByUsername("MikkelP").Name);
        }

    }
}
