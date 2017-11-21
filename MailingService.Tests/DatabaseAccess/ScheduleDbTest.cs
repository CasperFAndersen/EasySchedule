using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Schedules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class ScheduleDbTest
    {
        ScheduleRepository schRep = new ScheduleRepository();

        [TestMethod]
        public void TestGetScheduleByCurrentDate()
        {
            DateTime currentDate = new DateTime(2017, 11, 13);

            Schedule schedule = schRep.GetScheduleByCurrentDate(currentDate);

            Assert.IsNotNull(schedule);
            //Assert.AreEqual(3, schedule.Shifts.Count);
        }

        [TestMethod]
        public void TestGetCurrentScheduleByDepartmentId()
        {
            DateTime currentDate = new DateTime(2017, 11, 20);

            Schedule schedule = schRep.GetCurrentScheduleByDepartmentId(currentDate, 1);

            List<Shift> shifts = schedule.Shifts;

            Assert.IsNotNull(schedule);
            Assert.AreEqual(schedule.StartDate, currentDate);
            Assert.AreEqual(3, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);
        }
    }
}
