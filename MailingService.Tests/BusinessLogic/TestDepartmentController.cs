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
    public class TestDepartmentController
    {
        private IDepartmentRepository _departmentRepository;

        [TestInitialize]
        public void TestInitializer()
        {
            _departmentRepository = new DepartmentRepository();
        }

        [TestMethod]
        public void TestGetAllDepartments()
        {
            List<Department> departments = _departmentRepository.GetAllDepartments();
            Assert.IsNotNull(departments);
            Assert.AreNotEqual(departments.Count, 0);
        }

        [TestMethod]
        public void TestGetAllDepartmentsWithMoq()
        {
            //Arrange
            var mockDepartmentRepository = new Mock<IDepartmentRepository>();
            mockDepartmentRepository.Setup(x => x.GetAllDepartments());
            var departmentController = new DepartmentController(mockDepartmentRepository.Object);

            //Act
            departmentController.GetAllDepartments();

            //Assert
            mockDepartmentRepository.VerifyAll();
        }

        [TestMethod]
        public void TestGetDepartmentById()
        {
            Department department = _departmentRepository.GetDepartmentById(1);
            Assert.IsNotNull(department);
        }

        [TestMethod]
        public void TestGetDepartmentByIdWithMoq()
        {
            //Arrange
            var mockDepartmentRepository = new Mock<IDepartmentRepository>();
            mockDepartmentRepository.Setup(x => x.GetDepartmentById(It.IsAny<int>()));
            var departmentController = new DepartmentController(mockDepartmentRepository.Object);

            //Act
            departmentController.GetDepartmentById(1);

            //Assert    
            mockDepartmentRepository.VerifyAll();
        }
    }
}
