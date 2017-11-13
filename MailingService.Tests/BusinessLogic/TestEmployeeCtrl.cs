using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess;
using BusinessLogic;
using Core;
using System.Collections.Generic;

namespace MailingService.Tests.BusinessLogic
{
    [TestClass]
    public class TestEmployeeCtrl
    {

        [TestMethod]
        public void TestGetAllEmployees()
        {
            EmployeeController empCtrl = new EmployeeController();

            List<Employee> employees = empCtrl.GetAllEmployees();

            Assert.IsNotNull(employees);
            Assert.AreEqual(3, employees.Count);
            Assert.AreEqual("Hanne", employees[2].Name);
        }
    }
}
