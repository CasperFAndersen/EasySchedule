using System;
using BusinessLogic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Schedules;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestScheduleCtrl
    {
        
        ScheduleController schCtrl = new ScheduleController();

        [TestMethod]
        public void TestGetSchedueleByCurrentDate()
        {
            MockScheduleRep mockScheduleRep = new MockScheduleRep();
            DateTime currentDate = new DateTime(2017,11,13);
            Schedule schedule = mockScheduleRep.GetScheduleByCurrentDate(currentDate);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(3, schedule.Shifts.Count);

        }

        [TestMethod]
        public void TestGetCurrentScheduleByDepartmentId()
        {
            DateTime currentDate = new DateTime(2017, 11, 20);

            Schedule schedule = schCtrl.GetCurrentScheduleByDepartmentId(1);

            Assert.AreEqual(3, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);
            Assert.IsNotNull(schedule);
        }
    }
}
