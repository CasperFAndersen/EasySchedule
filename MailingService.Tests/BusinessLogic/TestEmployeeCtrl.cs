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
            Assert.AreNotEqual(employees.Count, 0);
            //Assert.AreEqual("Hanne", employees[2].Name);
        }

        [TestMethod]
        public void TestGetEmployeeByUsername()
        {

            Employee e1 = empCtrl.GetEmployeeByUsername("TobiAs");

            Assert.IsNotNull(e1);
            Assert.AreEqual("Tobias Andersen", e1.Name);
        }

        [TestMethod]
        public void TestValidPassword()
        {
            bool isPasswordCorrect = empCtrl.ValidatePassword("TobiAs", "CanYouGuessMyPass");
            bool isPasswordIncorrect = empCtrl.ValidatePassword("TobMaster", "5678");


            Assert.IsTrue(isPasswordCorrect);
            Assert.IsFalse(isPasswordIncorrect);
        }
    }
}
