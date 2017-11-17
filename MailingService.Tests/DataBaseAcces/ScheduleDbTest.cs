using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Schedules;
using Core;

namespace Tests.DataBaseAcces
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
    }
}
