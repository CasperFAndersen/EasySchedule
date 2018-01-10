using System.Collections.Generic;
using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseAccess.Tests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        private IEmployeeRepository _employeeRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _employeeRepository = new EmployeeRepository();
        }

        [TestMethod]
        public void GetAllEmployeesTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void GetEmployeeByUsernameTest()
        {
            Employee employee = _employeeRepository.GetEmployeeByUsername("MikkelP");
            Assert.AreEqual("Mikkel Paulsen", employee.Name);
        }

        [TestMethod()]
        public void GetEmployeeByIdTest()
        {
            Employee employee = _employeeRepository.GetEmployeeById(1);
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void InsertEmployeeTest()
        {
            Employee employee = new Employee()
            {
                Name = "Anders Andersen",
                IsAdmin = false,
                Email = "andersen@bos.dk",
                Phone = "98901349",
                NoOfHours = 37,
                IsEmployed = true,
                Username = "AAndersen",
                DepartmentId = 3,
                Password = "GotMilk?",
                Salt = "example"
            };

            _employeeRepository.InsertEmployee(employee);

            employee = _employeeRepository.GetEmployeeByUsername("AAndersen");
            List<Employee> employees = _employeeRepository.GetAllEmployees();

            Assert.IsNotNull(employee);
            Assert.AreEqual("Anders Andersen", employee.Name);
            Assert.AreEqual(6, employee.Id);
            Assert.AreEqual(employees.Count, 6);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            Employee employee = _employeeRepository.GetEmployeeByUsername("MikkelP");

            Assert.IsNotNull(employee);
            Assert.AreEqual("Mikkel Paulsen", employee.Name);

            byte[] rowVersion1 = employee.RowVersion;

            employee.Name = "Mikkel Hansen";

            _employeeRepository.UpdateEmployee(employee);

            employee = _employeeRepository.GetEmployeeByUsername("MikkelP");

            byte[] rowVersion2 = employee.RowVersion;

            Assert.IsNotNull(employee);
            Assert.AreEqual("Mikkel Hansen", employee.Name);
            Assert.AreNotEqual(rowVersion1, rowVersion2);
        }

        [TestMethod]
        public void GetEmployeesByDepartmentIdTest()
        {
            List<Employee> employees = _employeeRepository.GetEmployeesByDepartmentId(1);
            Assert.AreNotEqual(0, employees.Count);
        }

        [TestMethod]
        public void GetSaltByEmployeeTest()
        {
            //TODO: Implement this
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbSetUp.SetUpDb();
        }

    }
}
