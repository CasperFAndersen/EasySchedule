using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockRepository = Rhino.Mocks.MockRepository;
using Moq;

namespace BusinessLogic.Tests
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
        public void GetAllEmployeesTest()
        {
            _mockEmployeeRepository.Setup(x => x.GetAllEmployees());

            _employeeController.GetAllEmployees();

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void GetEmployeeByIdTest()
        {
            _mockEmployeeRepository.Setup(x => x.GetEmployeeById(It.IsAny<int>()));

            _employeeController.GetEmployeeById(1);

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void GetEmployeeByUsernameTest()
        {
            _mockEmployeeRepository.Setup(x => x.GetEmployeeByUsername(It.IsAny<string>()));

            _employeeController.GetEmployeeByUsername("test");

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void GetEmployeesByDepartmentId()
        {
            _mockEmployeeRepository.Setup(x => x.GetEmployeesByDepartmentId(It.IsAny<int>()));

            _employeeController.GetEmployeesByDepartmentId(1);

            _mockEmployeeRepository.VerifyAll();
        }

        [TestMethod]
        public void ValidPasswordTest()
        {
            EmployeeController employeeController = new EmployeeController(new EmployeeRepository());
            Employee employee = employeeController.ValidatePassword("TobiAs", "CanYouGuessMyPass");

            Assert.IsNotNull(employee);
            Assert.AreEqual("TobiAs", employee.Username);
        }

        [TestMethod]
        public void GenerateHashFromPasswordAndSaltTest()
        {
            _employeeController = new EmployeeController(new EmployeeRepository());
            Employee employee = _employeeController.GetEmployeeByUsername("TobiAs");
            string salt = employee.Salt;
            string password = "CanYouGuessMyPass";
            string HashedPassword = PasswordHashing.HashPassword(salt + password);

            string hashedPasswordFromDb = employee.Password;

            Assert.AreEqual(HashedPassword, hashedPasswordFromDb);
        }

        [TestMethod]
        public void InsertEmployeeTest()
        {
            //TODO: Implement this
            //_employeeController = new EmployeeController(new EmployeeRepository());
            //Employee emp = new Employee()
            //{
            //    Name = "Anders Andersen",
            //    IsAdmin = false,
            //    Email = "andersen@bos.dk",
            //    Phone = "98901349",
            //    NoOfHours = 37,
            //    IsEmployed = true,
            //    Username = "AAndersen",
            //    DepartmentId = 3,
            //    Password = "GotMilk",
            //};

            //_employeeController.InsertEmployee(emp);
            //Assert.IsNotNull(new EmployeeRepository().GetEmployeeByUsername(emp.Username));
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            EmployeeController empCtr = new EmployeeController(new EmployeeRepository());
            Employee employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP");
            employee.Name = "Fisk To";
            empCtr.UpdateEmployee(employee);
            Assert.AreEqual(new EmployeeRepository().GetEmployeeByUsername("MikkelP").Name, "Fisk To");
        }

        
    }
}
