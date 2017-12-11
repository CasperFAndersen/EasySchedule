using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Collections.Generic;
using System.Linq;
using Tests.TemplateScheduleService;

namespace Tests.Services
{
    [TestClass]
    public class TemplateScheduleServiceTest
    {
        [TestMethod]
        public void TestAddTemplateScheduleToDbService()
        {
            TemplateScheduleServiceClient templateScheduleService = new TemplateScheduleServiceClient();
            List<TemplateSchedule> beforeAddingTemplateScheduleList = new List<TemplateSchedule>(templateScheduleService.GetAllTemplateSchedules());
            TemplateSchedule templateSchedule = new TemplateSchedule(4, "DummySchedule", 1);
            templateScheduleService.AddTemplateScheduleToDb(templateSchedule);
            List<TemplateSchedule> afterAddingTemplateScheduleList = new List<TemplateSchedule>(templateScheduleService.GetAllTemplateSchedules());
            Assert.AreNotEqual(beforeAddingTemplateScheduleList.Count, afterAddingTemplateScheduleList.Count);
            Assert.AreEqual(templateScheduleService.FindTemplateScheduleByName("DummySchedule").Name, templateSchedule.Name);
        }

        [TestMethod]
        public void TestGetAllTemplateSchedules()
        {
            TemplateScheduleServiceClient templateScheduleService = new TemplateScheduleServiceClient();
            List<TemplateSchedule> templateSchedules = templateScheduleService.GetAllTemplateSchedules();
            Assert.IsNotNull(templateSchedules);
        }
    }
}
