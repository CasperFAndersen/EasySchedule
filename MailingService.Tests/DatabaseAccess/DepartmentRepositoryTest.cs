using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Departments;
using Core;
using System.Collections.Generic;

namespace Tests.DatabaseAccess
{

    [TestClass]
    public class DepartmentRepositoryTest
    {
        DepartmentRepository depDb;
        [TestInitialize]
        public void TestInitialize()
        {
            depDb = new DepartmentRepository();
            DBSetUp.SetUpDB();
        }

        [TestMethod]
        public void TestGetDepartmentById()
        {
            Department dep = depDb.GetDepartmentById(1);

            Assert.IsNotNull(dep);
            Assert.AreEqual(3, dep.Employees.Count);
            Assert.AreEqual("Mikkel Paulsen", dep.Employees[0].Name);
        }

        [TestMethod]
        public void TestGetAllDepartments()
        {
            List<Department> deps = depDb.GetAllDepartments();

            Assert.AreEqual(3, deps.Count);
        }
    }
}
