using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Departments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestDepartmentController
    {
        private IDepartmentRepository _departmentRepository = new DepartmentRepository();

        [TestMethod]
        public void TestGetAllDepartments()
        {
            List<Department> departments = _departmentRepository.GetAllDepartments();
            Assert.IsNotNull(departments);
            Assert.AreNotEqual(departments.Count, 0);
        }

        [TestMethod]
        public void TestGetDepartmentById()
        {
            Department department = _departmentRepository.GetDepartmentById(1);
            Assert.IsNotNull(department);
        }
    }
}
