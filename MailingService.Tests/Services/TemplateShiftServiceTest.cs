using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Tests.TempShiftService;

namespace Tests.Services
{
    [TestClass]
    public class TemplateShiftServiceTest
    {
        [TestMethod]
        public void TestAddTemplaceShiftService()
        {
            TempShiftServiceClient tempShiftServiceClient = new TempShiftServiceClient();

            TemplateShift tempShift1 = tempShiftServiceClient.CreateTempShift(TempShiftService.DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, new Employee() { Id = 3 });

            Assert.AreEqual(TempShiftService.DayOfWeek.Friday.ToString(), tempShift1.WeekDay.ToString());
            Assert.AreNotEqual(TimeSpan.FromHours(5), tempShift1.StartTime);
        }
    }
}
