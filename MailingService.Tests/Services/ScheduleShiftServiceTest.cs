using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Tests.ScheduleShiftService;
using System.Collections.Generic;
using DatabaseAccess.Tests;

namespace Tests.Services
{
    [TestClass]
    public class ScheduleShiftServiceTest
    {
        ScheduleShiftServiceClient client;
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            client = new ScheduleShiftServiceClient();
        }

        [TestMethod]
        public void GetAllAvailableShiftsByDepartmentIdTest()
        {
            DbSetUp.SetUpDb();
            List<ScheduleShift> availableScheduleShifts = client.GetAllAvailableShiftsByDepartmentId(1);
            Assert.IsNotNull(availableScheduleShifts);
            Assert.AreEqual(2, availableScheduleShifts.Count);
            DbSetUp.SetUpDb();
        }
    }
}
