﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.EmployeeService;
using Core;
using System.Collections.Generic;

namespace Tests.Services
{
    
    [TestClass]
    public class EmployeeServiceTests
    {
        EmployeeServiceClient client;

        [TestInitialize]
        public void TestInitialize()
        {
            client = new EmployeeServiceClient();
        }

        [TestMethod]
        public void EmployeeServiceGetEmployeeByUsernameTest()
        {
        
            string expected = "Tobias Andersen";
            string actual = client.GetEmployeeByUsername("TobiAs").Name;

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

            client.InsertEmployee(employee);

            employee = client.GetEmployeeByUsername("AAndersen");
            List<Employee> employees = client.GetAllEmployees();

            Assert.IsNotNull(employee);
            Assert.AreEqual("Anders Andersen", employee.Name);
            Assert.AreEqual(6, employee.Id);
            Assert.AreEqual(employees.Count, 6);

        }

        [TestMethod]
        public void EmployeeServiceUpdateEmployeeTest()
        {
            Employee emp = client.GetEmployeeByUsername("MikkelP");

            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Paulsen", emp.Name);

            emp.Name = "Mikkel Paulsen";

            client.UpdateEmployee(emp);

            emp = client.GetEmployeeByUsername("MikkelP");
            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Paulsen", emp.Name);
        }

    }
}