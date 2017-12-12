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
            Assert.AreEqual("Mikkel Paulsen", _employeeRepository.GetEmployeeByUsername("MikkelP").Name);
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
                Password = "GotMilk?",
                Salt = "example"
            };

            _employeeRepository.InsertEmployee(emp);

            emp = _employeeRepository.GetEmployeeByUsername("AAndersen");
            List<Employee> emps = _employeeRepository.GetAllEmployees();

            Assert.IsNotNull(emp);
            Assert.AreEqual("Anders Andersen", emp.Name);
            Assert.AreEqual(6, emp.Id);
            Assert.AreEqual(emps.Count, 6);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            Employee emp = _employeeRepository.GetEmployeeByUsername("MikkelP");

            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Paulsen", emp.Name);

            emp.Name = "Mikkel Hansen";

            _employeeRepository.UpdateEmployee(emp);

            emp = _employeeRepository.GetEmployeeByUsername("MikkelP");
            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Hansen", emp.Name);
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
