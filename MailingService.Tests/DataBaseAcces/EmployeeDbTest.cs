using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Employees;

namespace Tests.DataBaseAcces
{
    [TestClass]
    public class EmployeeDbTest
    {
        [TestMethod]
        public void TestGetEmployeeByUsername()
        {
            EmployeeRepository empRes = new EmployeeRepository();

            Assert.AreEqual("Mikkel Paulsen", empRes.GetEmployeeByUsername("MikkelP").Name);

        }

    }
}
