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
            _departmentRepository = new DepartmentRepository();
        }

        [TestMethod]
        public void TestGetDepartmentById()
        {
            Department department = _departmentRepository.GetDepartmentById(1);

            Assert.IsNotNull(department);
            Assert.AreEqual(3, department.Employees.Count);
            Assert.AreEqual("Mikkel Paulsen", department.Employees[0].Name);
        }

        [TestMethod]
        public void TestGetAllDepartments()
        {
            List<Department> departments = _departmentRepository.GetAllDepartments();

            Assert.AreEqual(3, departments.Count);
        }
    }
}
