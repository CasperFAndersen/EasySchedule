﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Collections.Generic;
using DesktopClient.TempScheduleService;

namespace Tests.Services
{
    [TestClass]
    public class TemplateScheduleServiceTest
    {
        [TestMethod]
        public void TestAddTempScheduleToDBService()
        {
            TempScheduleServiceClient tempScheduleService = new TempScheduleServiceClient();

            List<TemplateSchedule> beforeAddingTempScheduleList = new List<TemplateSchedule>(tempScheduleService.GetAllTempSchedules());
            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            tempScheduleService.AddTempScheduleToDB(tSchedule);

            List<TemplateSchedule> afterAddingTempScheduleList = new List<TemplateSchedule>(tempScheduleService.GetAllTempSchedules());

            Assert.AreNotEqual(beforeAddingTempScheduleList.Count, afterAddingTempScheduleList.Count);
            Assert.AreEqual(tempScheduleService.FindTempScheduleByName("DummySchedule").Name, tSchedule.Name);
        }
    }
}