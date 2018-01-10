using System.Collections.Generic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceHosting.Tests.TemplateScheduleService;

namespace ServiceHosting.Tests
{
    [TestClass]
    public class TemplateScheduleServiceTests
    {
        private readonly ITemplateScheduleService _templateScheduleService = new TemplateScheduleServiceClient();

        [TestMethod]
        public void AddTemplateScheduleToDbServiceTest()
        {
            List<TemplateSchedule> beforeAddingTemplateScheduleList = _templateScheduleService.GetAllTemplateSchedules();
            TemplateSchedule templateSchedule = new TemplateSchedule(4, "DummySchedule", 1);
            _templateScheduleService.AddTemplateScheduleToDb(templateSchedule);
            List<TemplateSchedule> afterAddingTemplateScheduleList = new List<TemplateSchedule>(_templateScheduleService.GetAllTemplateSchedules());
            Assert.AreNotEqual(beforeAddingTemplateScheduleList.Count, afterAddingTemplateScheduleList.Count);
        }

        [TestMethod]
        public void GetAllTemplateSchedulesTest()
        {
            List<TemplateSchedule> templateSchedules = _templateScheduleService.GetAllTemplateSchedules();
            Assert.IsNotNull(templateSchedules);
        }
    }
}
