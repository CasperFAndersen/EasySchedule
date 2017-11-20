using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class EmployeeDbTest
    {
        [TestMethod]
        public void TestGetEmployeeByUsername()
        {
            EmployeeRepository empRes = new EmployeeRepository();
            Employee emp = empRes.GetEmployeeByUsername("MikkelP");
            Assert.AreEqual("Mikkel Paulsen", empRes.GetEmployeeByUsername("MikkelP").Name);

        }

    }
}
