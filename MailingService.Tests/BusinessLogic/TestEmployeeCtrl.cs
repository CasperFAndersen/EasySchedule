using System.Collections.Generic;
using BusinessLogic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestEmployeeCtrl
    {
        private EmployeeController empCtrl = new EmployeeController();
        [TestMethod]
        public void TestGetAllEmployees()
        {
            
            List<Employee> employees = empCtrl.GetAllEmployees();

            Assert.IsNotNull(employees);
            Assert.AreEqual(3, employees.Count);
            Assert.AreEqual("Hanne", employees[2].Name);
        }

        [TestMethod]
        public void TestGetEmployeeByUsername()
        {
            
            Employee e1 = empCtrl.GetEmployeeByUsername("TobMaster");

            Assert.IsNotNull(e1);
            Assert.AreEqual("Tobias", e1.Name);
        }

        [TestMethod]
        public void TestValidPassword()
        {
            bool isPasswordCorrect = empCtrl.ValidatePassword("TobMaster", "1234");
            bool isPasswordIncorrect = empCtrl.ValidatePassword("TobMaster", "5678");


            Assert.IsTrue(isPasswordCorrect);
            Assert.IsFalse(isPasswordIncorrect);
        }
    }
}
