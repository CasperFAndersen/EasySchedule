using System;
using System.Collections.Generic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLibrary.Departments;
using DatabaseAccess.Departments;
using BusinessLogic;

namespace ServiceLibrary.Tests
{
    [TestClass]
    public class DepartmentServiceTests
    {
        [TestMethod]
        public void GetAllDepartmentsTest()
        {
            Mock<IDepartmentService> mockDepartmentService = new Mock<IDepartmentService>();
            mockDepartmentService.Setup(m => m.GetAllDepartments()).Returns(() => new List<Department>());
            var resultList = mockDepartmentService.Object.GetAllDepartments();
            CollectionAssert.AreEquivalent(new List<Department>(), resultList);
        }

        [TestMethod]
        public void GetDepartmentsByWorkplaceIdTest()
        {
            Mock<IDepartmentService> mockDepartmentService = new Mock<IDepartmentService>();
            mockDepartmentService.Setup(m => m.GetAllDepartmentsByWorkplaceId(It.IsAny<int>())).Returns(() => new List<Department>());
            var resultList = mockDepartmentService.Object.GetAllDepartmentsByWorkplaceId(1);
            CollectionAssert.AreEquivalent(new List<Department>(), resultList);
        }

        [TestMethod]
        public void GetDepartmentsByWorkplaceIdParameterTest()
        {
            Mock<IDepartmentService> mockDepartmentService = new Mock<IDepartmentService>();
            mockDepartmentService.Setup(m => m.GetAllDepartmentsByWorkplaceId(It.IsAny<int>()))
                .Callback(() => Console.WriteLine("Numbers passed"));
        }


    }
}
