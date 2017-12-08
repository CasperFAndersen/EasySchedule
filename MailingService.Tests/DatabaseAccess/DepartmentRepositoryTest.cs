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
        IDepartmentRepository _departmentRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            DbSetUp.SetUpDb();
            _departmentRepository = new DepartmentRepository();
        }

        [TestCleanup]
        public void TearDown()
        {
            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void TestGetDepartmentById()
        {
            Department department = _departmentRepository.GetDepartmentById(1);
            Assert.IsNotNull(department);
            Assert.AreEqual("98241966", department.Phone);
            Assert.AreEqual(1, department.Id);
        }

        [TestMethod]
        public void TestGetAllDepartments()
        {
            List<Department> departments = _departmentRepository.GetAllDepartments();
            Assert.AreEqual(5, departments.Count);
        }

        [TestMethod()]
        public void GetDepartmentsByWorkplaceIdTest()
        {
            List<Department> departments = _departmentRepository.GetDepartmentsByWorkplaceId(1);
            Assert.AreEqual(2, departments.Count);
        }
    }
}
