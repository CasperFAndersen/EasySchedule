using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Collections.Generic;

namespace Tests.Services
{
    [TestClass]
    public class TemplateScheduleServiceTest
    {
        [TestMethod]
        public void AddTempScheduleToDBServiceTest()
        {
            ServiceLibrary.TempScheduleService tempScheduleService = new ServiceLibrary.TempScheduleService();

            List<TemplateSchedule> beforeAddingTempScheduleList = new List<TemplateSchedule>(tempScheduleService.GetAllTempSchedules());
            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            tempScheduleService.AddTempScheduleToDB(tSchedule);

            List<TemplateSchedule> afterAddingTempScheduleList = new List<TemplateSchedule>(tempScheduleService.GetAllTempSchedules());

            Assert.AreNotEqual(beforeAddingTempScheduleList.Count, afterAddingTempScheduleList.Count);
            Assert.AreEqual(tempScheduleService.FindTempScheduleByName("DummySchedule").Name, tSchedule.Name);
        }
    }
}
