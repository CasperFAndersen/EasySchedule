using System.Collections.Generic;
using Core;
using DatabaseAccess.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceHosting.Tests.ScheduleShiftService;

namespace ServiceHosting.Tests
{
    [TestClass]
    public class ScheduleShiftServiceTest
    {
        private readonly IScheduleShiftService _scheduleShiftServiceClient = new ScheduleShiftServiceClient();

        [TestMethod]
        public void GetAllAvailableShiftsByDepartmentIdTest()
        {
            DbSetUp.SetUpDb();
            List<ScheduleShift> availableScheduleShifts = _scheduleShiftServiceClient.GetAllAvailableShiftsByDepartmentId(1);
            Assert.IsNotNull(availableScheduleShifts);
            Assert.AreEqual(2, availableScheduleShifts.Count);
            DbSetUp.SetUpDb();
        }
    }
}
