using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Departments;
using Core;

namespace BusinessLogic.Tests
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
