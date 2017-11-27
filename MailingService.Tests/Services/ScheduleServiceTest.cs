using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.ScheduleService;
using Core;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestClass]
    public class ScheduleServiceTest
    {
        [TestMethod]
        public void TestGetScheduleByDepartmentId()
        {
            ScheduleServiceClient client = new ScheduleServiceClient();

            Schedule schedule = client.GetCurrentScheduleDepartmentId(1);

            List<Shift> shifts = schedule.Shifts;

            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017,11,27), schedule.StartDate);
            Assert.AreEqual(3, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);

           // Schedule schedule2 = client.GetCurrentScheduleDepartmentId(2);

            //Assert.IsNotNull(schedule);
            //Assert.AreEqual(new DateTime(2017, 11, 20), schedule2.StartDate);
            //Assert.AreEqual(2, schedule2.Shifts.Count);
            //Assert.AreEqual("Pakkecentral", schedule2.Department.Name);


        }
    }
}
