using Core;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;

namespace Tests.DatabaseAccess
{

    [TestClass]
    public class EmployeeDbTest
    {
        IEmployeeRepository empRes; 

        [TestInitialize]
        public void TestInitialize()
        {
            empRes = new EmployeeRepository();
            DBSetUp.SetUpDB();
        }



        [TestMethod]
        public void TestGetEmployeeByUsername()
        {
         
            Employee emp = empRes.GetEmployeeByUsername("MikkelP");
            Assert.AreEqual("Mikkel Paulsen", empRes.GetEmployeeByUsername("MikkelP").Name);
        }

        [TestMethod]
        public void TestInsertEmployeeIntoDB()
        {
            Employee emp = new Employee() { Name = "Anders Andersen", IsAdmin = false, Mail = "andersen@bøgs.dk",
                Phone = "98901349", NumbOfHours = 37, IsEmployed = true, Username = "AAndersen", DepartmentId = 3, Password = "GotMilk?" };

            empRes.InsertEmployee(emp);

            emp = empRes.GetEmployeeByUsername("AAndersen");
            List<Employee> emps = empRes.GetAllEmployees();

            Assert.IsNotNull(emp);
            Assert.AreEqual("Anders Andersen", emp.Name);
            Assert.AreEqual(6, emp.Id);
            Assert.AreEqual(emps.Count, 6);
        }

        [TestMethod]
        public void TestUpdateEmployee()
        {
            Employee emp = empRes.GetEmployeeByUsername("MikkelP");

            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Paulsen", emp.Name);

            emp.Name = "Mikkel Hansen";

            empRes.UpdateEmployee(emp);

            emp = empRes.GetEmployeeByUsername("MikkelP");
            Assert.IsNotNull(emp);
            Assert.AreEqual("Mikkel Hansen", emp.Name);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            DBSetUp.SetUpDB();
        }

    }
}
