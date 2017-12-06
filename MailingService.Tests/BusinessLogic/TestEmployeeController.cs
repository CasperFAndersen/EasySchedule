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
            Employee employee = employeeController.ValidatePassword("TobiAs", "CanYouGuessMyPass");
            

            Assert.IsNotNull(employee);
            Assert.AreEqual("TobiAs", employee.Username);
        }

        [TestMethod]
        public void TestInsertEmployee()
        {
            _employeeController = new EmployeeController(new EmployeeRepository());
            Employee emp = new Employee()
            {
                Name = "Anders Andersen",
                IsAdmin = false,
                Mail = "andersen@bos.dk",
                Phone = "98901349",
                NumbOfHours = 37,
                IsEmployed = true,
                Username = "AAndersen",
                DepartmentId = 3,
                Password = "GotMilk"
            };

            EmployeeController empCtr = new EmployeeController(new EmployeeRepository());
            empCtr.InsertEmployee(emp);
            Assert.IsNotNull(new EmployeeRepository().GetEmployeeByUsername(emp.Username));

            //TODO: Assert employee is added to the database
            //_mockEmployeeRepository.Setup(x => x.InsertEmployee(It.IsAny<Employee>()));

            //_employeeController.InsertEmployee(emp);

            //_mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void TestUpdateEmployee()
        {
            EmployeeController empCtr = new EmployeeController(new EmployeeRepository());
            Employee employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP");
            employee.Name = "Fisk To";
            empCtr.UpdateEmployee(employee);
            Assert.AreEqual(new EmployeeRepository().GetEmployeeByUsername("MikkelP").Name, "Fisk To");
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
