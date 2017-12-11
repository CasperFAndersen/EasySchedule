using System;
using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Departments;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhino.Mocks;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class DepartmentControllerTests
    {
        private IDepartmentController _departmentController;

        [TestInitialize]
        public void TestInitializer()
        {
            _departmentController = new DepartmentController(new DepartmentRepository());
        }

        [TestMethod]
        public void GetAllDepartmentsTest()
        {
            List<Department> departments = _departmentController.GetAllDepartments();
            Assert.IsNotNull(departments);
            Assert.AreNotEqual(departments.Count, 0);
        }

        [TestMethod]
        public void GetDepartmentByIdTest()
        {
            Department department = _departmentController.GetDepartmentById(1);
            Assert.IsNotNull(department);
        }

        [TestMethod]
        public void GetDepartmentByIdWithNegativeInputTest()
        {
            Department department = _departmentController.GetDepartmentById(-1);
            Assert.IsNull(department.Name);
        }

    }
}
