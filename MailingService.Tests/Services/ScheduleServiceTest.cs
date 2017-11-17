using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.ScheduleService;
using Core;

namespace Tests.Services
{
    [TestClass]
    public class ScheduleServiceTest
    {
        [TestMethod]
        public void TestGetScheduleByDepartmentId()
        {
            ScheduleServiceClient client = new ScheduleServiceClient();

            Schedule schedule = client.GetCurrentScheduleDepartmentId(2);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017,11,13), schedule.StartDate);
        }
    }
}
