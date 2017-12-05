using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhino.Mocks;
using MockRepository = Rhino.Mocks.MockRepository;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestEmployeeController
    {
        private EmployeeController _employeeController;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _employeeController = new EmployeeController(_mockEmployeeRepository.Object);
        }

        [TestMethod]
        public void TestGetEmployeeByUsername()
        {
            _mockEmployeeRepository.Setup(x => x.GetEmployeeByUsername(It.IsAny<string>()));

            _employeeController.GetEmployeeByUsername("test");

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void TestGetAllEmployees()
        {
            _mockEmployeeRepository.Setup(x => x.GetAllEmployees());

            _employeeController.GetAllEmployees();

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void TestValidPassword()
        {
            EmployeeController employeeController = new EmployeeController(new EmployeeRepository());
            bool isPasswordCorrect = employeeController.ValidatePassword("TobiAs", "CanYouGuessMyPass");
            //bool isPasswordIncorrect = employeeController.ValidatePassword("TobMaster", "5678");

            Assert.IsTrue(isPasswordCorrect);
           // Assert.IsFalse(isPasswordIncorrect);
        }
        [TestMethod]
        public void TestInsertEmployee()
        {
            _mockEmployeeRepository.Setup(x => x.InsertEmployee(It.IsAny<Employee>()));

            _employeeController.InsertEmployee(new Employee());

            _mockEmployeeRepository.VerifyAll();
        }


        [TestMethod]
        public void TestPasswordHashing()
        {
            string input = "Password";
            string output = PasswordHashing.HashPassword(input);
            Assert.AreNotEqual(input, output);
            
        }
    }
}
