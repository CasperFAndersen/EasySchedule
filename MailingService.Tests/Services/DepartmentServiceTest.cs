using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.DepartmentService;

namespace Tests.Services
{
    [TestClass]
    public class DepartmentServiceTest
    {
        [TestMethod]
        public void DepServiceTest()
        {
            DepartmentServiceClient departmentServiceClient = new DepartmentServiceClient();

            List<Department> departments = departmentServiceClient.GetAllDepartments().ToList();

            Assert.IsNotNull(departments);
            Assert.AreNotEqual(0, departments.Count);
        }
    }
}
