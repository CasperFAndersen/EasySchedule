using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Tests.TemplateShiftService;

namespace Tests.Services
{
    [TestClass]
    public class TemplateShiftServiceTests
    {
        [TestMethod]
        public void AddTemplaceShiftServiceTest()
        {
            TemplateShiftServiceClient templateShiftService = new TemplateShiftServiceClient();

            TemplateShift templateShift = templateShiftService.CreateTemplateShift(TemplateShiftService.DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, new Employee() { Id = 3 });

            Assert.AreEqual(TemplateShiftService.DayOfWeek.Friday.ToString(), templateShift.WeekDay.ToString());
            Assert.AreNotEqual(TimeSpan.FromHours(5), templateShift.StartTime);
        }
    }
}
