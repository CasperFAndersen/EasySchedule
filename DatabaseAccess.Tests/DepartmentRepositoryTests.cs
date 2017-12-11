using System.Collections.Generic;
using Core;
using DatabaseAccess.Departments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseAccess.Tests
{

    [TestClass]
    public class DepartmentRepositoryTests
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
        public void GetDepartmentByIdTest()
        {
            Department department = _departmentRepository.GetDepartmentById(1);
            Assert.IsNotNull(department);
            Assert.AreEqual("Kolonial", department.Name);
        }

        [TestMethod]
        public void GetAllDepartmentsTest()
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
