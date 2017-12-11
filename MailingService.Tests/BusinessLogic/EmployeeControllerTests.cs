using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhino.Mocks;
using Tests.DatabaseAccess;
using MockRepository = Rhino.Mocks.MockRepository;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class EmployeeControllerTests
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
        public void GetEmployeeByUsernameTest()
        {
            _mockEmployeeRepository.Setup(x => x.GetEmployeeByUsername(It.IsAny<string>()));

            _employeeController.GetEmployeeByUsername("test");

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void GetAllEmployeesTest()
        {
            _mockEmployeeRepository.Setup(x => x.GetAllEmployees());

            _employeeController.GetAllEmployees();

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void ValidPasswordTest()
        {
            EmployeeController employeeController = new EmployeeController(new EmployeeRepository());
            Employee employee = employeeController.ValidatePassword("TobiAs", "CanYouGuessMyPass");

            Assert.IsNotNull(employee);
            Assert.AreEqual("TobiAs", employee.Username);

            string salt = employee.Salt;
            string password = "CanYouGuessMyPass";
            string HashedPassword = PasswordHashing.HashPassword(salt + password);

            Employee afterHashingEmployee = employeeController.GetEmployeeByUsername("TobiAs");
            string hashedPasswordFromDb = employee.Password;

            Assert.AreEqual(HashedPassword, hashedPasswordFromDb);
        }

        [TestMethod]
        public void InsertEmployeeTest()
        {
            DbSetUp.SetUpDb();

            _employeeController = new EmployeeController(new EmployeeRepository());
            Employee emp = new Employee()
            {
                Name = "Anders Andersen",
                IsAdmin = false,
                Email = "andersen@bos.dk",
                Phone = "98901349",
                NoOfHours = 37,
                IsEmployed = true,
                Username = "AAndersen",
                DepartmentId = 3,
                Password = "GotMilk"
            };

            EmployeeController empCtr = new EmployeeController(new EmployeeRepository());
            empCtr.InsertEmployee(emp);
            Assert.IsNotNull(new EmployeeRepository().GetEmployeeByUsername(emp.Username));

            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            DbSetUp.SetUpDb();

            EmployeeController empCtr = new EmployeeController(new EmployeeRepository());
            Employee employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP");
            employee.Name = "Fisk To";
            empCtr.UpdateEmployee(employee);
            Assert.AreEqual(new EmployeeRepository().GetEmployeeByUsername("MikkelP").Name, "Fisk To");

            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void PasswordHashingTest()
        {
            string input = "Password";
            string output = PasswordHashing.HashPassword(input);
            Assert.AreNotEqual(input, output);
        }
    }
}
