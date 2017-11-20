using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Employees;
using Core;

namespace Tests.DataBaseAcces
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
