﻿using System.Collections.Generic;
using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseAccess.Tests
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        IEmployeeRepository employeeRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            employeeRepository = new EmployeeRepository();
        }

        [TestMethod]
        public void GetEmployeeByUsernameTest()
        {
            Employee employee = employeeRepository.GetEmployeeByUsername("MikkelP");
            Assert.AreEqual("Mikkel Paulsen", employeeRepository.GetEmployeeByUsername("MikkelP").Name);
        }

        [TestMethod()]
        public void FindEmployeeByIdTest()
        {
            Employee employee = employeeRepository.FindEmployeeById(1);
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void InsertEmployeeIntoDbTest()
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

            employeeRepository.InsertEmployee(emp);

            emp = employeeRepository.GetEmployeeByUsername("AAndersen");
            List<Employee> emps = employeeRepository.GetAllEmployees();

            Assert.IsNotNull(emp);
            Assert.AreEqual("Anders Andersen", emp.Name);
            Assert.AreEqual(6, emp.Id);
            Assert.AreEqual(emps.Count, 6);
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            Employee emp = employeeRepository.GetEmployeeByUsername("MikkelP");

            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Paulsen", emp.Name);

            emp.Name = "Mikkel Hansen";

            employeeRepository.UpdateEmployee(emp);

            emp = employeeRepository.GetEmployeeByUsername("MikkelP");
            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Hansen", emp.Name);

        }

        [TestMethod]
        public void GetEmployeesByDepartmentIdTest()
        {
            List<Employee> employees = employeeRepository.GetEmployeesByDepartmentId(1);
            Assert.AreNotEqual(0, employees.Count);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbSetUp.SetUpDb();
        }

    }
}