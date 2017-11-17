using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary;
using Core;

namespace Tests.Services
{
    [TestClass]
    public class TemplateShiftServiceTest
    {
        [TestMethod]
        public void TestAddTemplaceShiftService()
        {
            TempShiftService templaceShiftService = new TempShiftService();

            TemplateShift tempShift1 = templaceShiftService.CreateTempShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, new Employee() { Id = 3 });

            Assert.AreEqual(DayOfWeek.Friday, tempShift1.WeekDay);
            Assert.AreNotEqual(TimeSpan.FromHours(5), tempShift1.StartTime);
        }
    }
}
