using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using ServiceHosting.Tests.TemplateShiftService;

namespace ServiceHosting.Tests
{
    [TestClass]
    public class TemplateShiftServiceTests
    {
        private readonly ITemplateShiftService _templateShiftService = new TemplateShiftServiceClient();

        [TestMethod]
        public void AddTemplaceShiftServiceTest()
        {
            TemplateShift templateShift = _templateShiftService.CreateTemplateShift(TemplateShiftService.DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, new Employee() { Id = 3 });

            Assert.AreEqual(TemplateShiftService.DayOfWeek.Friday.ToString(), templateShift.WeekDay.ToString());
            Assert.AreNotEqual(TimeSpan.FromHours(5), templateShift.StartTime);
        }
    }
}
