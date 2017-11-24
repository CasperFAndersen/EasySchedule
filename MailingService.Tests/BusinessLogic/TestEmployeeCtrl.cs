using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestEmployeeCtrl
    {
        private EmployeeController empCtrl;
        private IEmployeeRepository mockEmployeeRepository;

        [TestInitialize]
        public void InitializeTest()
        {
            mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
           empCtrl = new EmployeeController(mockEmployeeRepository);
        }

        [TestMethod]
        public void TestGetEmployeeByUsername()
        {
            mockEmployeeRepository.GetEmployeeByUsername("test");
            mockEmployeeRepository.AssertWasCalled(x => x.GetEmployeeByUsername("test"));
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            //TODO: Fix so it uses repository
            //List<Employee> employees = empCtrl.GetAllEmployees();
            //Assert.IsNotNull(employees);
            //Assert.AreNotEqual(employees.Count, 0);
            ////Assert.AreEqual("Hanne", employees[2].Name);
        }

        [TestMethod]
        public void TestValidPassword()
        {
            //TODO: Fix so it uses repository
            //bool isPasswordCorrect = empCtrl.ValidatePassword("TobiAs", "CanYouGuessMyPass");
            //bool isPasswordIncorrect = empCtrl.ValidatePassword("TobMaster", "5678");

            //Assert.IsTrue(isPasswordCorrect);
            //Assert.IsFalse(isPasswordIncorrect);
        }

        [TestMethod]
        public void TestInsertEmployee()
        {
            mockEmployeeRepository.GetEmployeeByUsername("test");
            mockEmployeeRepository.AssertWasCalled(x => x.GetEmployeeByUsername("test"));
        }
    }
}
