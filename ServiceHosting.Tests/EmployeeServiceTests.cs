using System.Collections.Generic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceHosting.Tests.EmployeeService;

namespace ServiceHosting.Tests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private readonly IEmployeeService _employeeServiceClient = new EmployeeServiceClient();

        [TestMethod]
        public void EmployeeServiceGetEmployeeByUsernameTest()
        {
            string expected = "Tobias Andersen";
            string actual = _employeeServiceClient.GetEmployeeByUsername("TobiAs").Name;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmployeeServiceInsertEmployeeTest()
        {
            Employee employee = new Employee()
            {
                Name = "Anders Andersen",
                IsAdmin = false,
                Email = "andersen@aa.dk",
                Phone = "98901349",
                NoOfHours = 37,
                IsEmployed = true,
                Username = "AAndersen",
                DepartmentId = 3,
                Password = "GotMilk",
                Salt = "example"
            };

            _employeeServiceClient.InsertEmployee(employee);

            employee = _employeeServiceClient.GetEmployeeByUsername("AAndersen");
            List<Employee> employees = _employeeServiceClient.GetAllEmployees();

            Assert.IsNotNull(employee);
            Assert.AreEqual("Anders Andersen", employee.Name);
            Assert.AreEqual(6, employee.Id);
            Assert.AreEqual(employees.Count, 6);
        }

        [TestMethod]
        public void EmployeeServiceUpdateEmployeeTest()
        {
            Employee employee = _employeeServiceClient.GetEmployeeByUsername("MikkelP");

            Assert.IsNotNull(employee);
            Assert.AreEqual("Mikkel Paulsen", employee.Name);

            employee.Name = "Mikkel Paulsen";

            _employeeServiceClient.UpdateEmployee(employee);

            employee = _employeeServiceClient.GetEmployeeByUsername("MikkelP");
            Assert.IsNotNull(employee);
            Assert.AreEqual("Mikkel Paulsen", employee.Name);
        }
    }
}
