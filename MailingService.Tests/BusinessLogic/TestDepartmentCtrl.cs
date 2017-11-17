using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Departments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestDepartmentCtrl
    {
        private IDepartmentRepository DepartmentRepository = new DepartmentRepository();

        [TestMethod]
        public void GetAllDepartmentsTest()
        {
            List<Department> departments = DepartmentRepository.GetAllDepartments();

            Assert.IsNotNull(departments);
            Assert.AreNotEqual(departments.Count, 0);
        }

        [TestMethod]
        public void GetDepartmentById()
        {
            Department department = DepartmentRepository.GetDepartmentById(1);

            Assert.IsNotNull();
        }
    }
}
