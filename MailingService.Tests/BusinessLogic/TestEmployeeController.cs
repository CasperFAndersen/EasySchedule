using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
using Rhino.Mocks;
using MockRepository = Rhino.Mocks.MockRepository;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestEmployeeController
    {
        private EmployeeController _employeeController;
        //private Mock<IEmployeeRepository> _mockEmployeeRepository;

        [TestInitialize]
        public void InitializeTest()
        {
           // _mockEmployeeRepository = new Mock<IEmployeeRepository>();
           // _employeeController = new EmployeeController(_mockEmployeeRepository.Object);
        }

        //[TestMethod]
        //public void TestGetEmployeeByUsername()
        //{
        //    _mockEmployeeRepository.Setup(x => x.GetEmployeeByUsername(It.IsAny<string>()));

        //    _employeeController.GetEmployeeByUsername("test");

        //    _mockEmployeeRepository.VerifyAll();
        //}

        //[TestMethod]
        //public void TestGetAllEmployees()
        //{
        //    _mockEmployeeRepository.Setup(x => x.GetAllEmployees());

        //    _employeeController.GetAllEmployees();

        //    _mockEmployeeRepository.VerifyAll();
        //}

        [TestMethod]
        public void TestValidPassword()
        {
            EmployeeController employeeController = new EmployeeController(new EmployeeRepository());
            bool isPasswordCorrect = employeeController.ValidatePassword("TobiAs", "CanYouGuessMyPass");
            bool isPasswordIncorrect = employeeController.ValidatePassword("TobMaster", "5678");

            Assert.IsTrue(isPasswordCorrect);
            Assert.IsFalse(isPasswordIncorrect);
        }

        //[TestMethod]
        //public void TestInsertEmployee()
        //{
        //    _mockEmployeeRepository.Setup(x => x.InsertEmployee(It.IsAny<Employee>()));

        //    _employeeController.InsertEmployee(new Employee());

        //    _mockEmployeeRepository.VerifyAll();
        //}

        [TestMethod]
        public void TestPasswordHashing()
        {
            string password1 = "Password";
            string password2 = "Second_Password";
            PasswordHashing passwordHashing = new PasswordHashing();

            Employee emp1 = new Employee() { Password = password1 };
            Employee emp2 = new Employee() { Password = password2 };

            string pHasing1 = PasswordHashing.CryptPassword(password1);
            string pHasing2 = PasswordHashing.CryptPassword(password2); ;

            //Testing crypt through set Password Property
            Assert.AreNotEqual(emp1.Password ,password1);
            Assert.AreNotEqual(emp2.Password, password2);

            //Testing hashing won PasswordHashing Class through emoployee
            Assert.AreEqual(emp1.Password, pHasing1);
            Assert.AreEqual(emp2.Password, pHasing2);

            emp1.Password = "newPassWord";
            string pHasing3 = PasswordHashing.CryptPassword("newPassWord");
            Assert.AreNotEqual(emp1.Password, password1);
            Assert.AreEqual(emp1.Password, pHasing3);
        }
    }
}
