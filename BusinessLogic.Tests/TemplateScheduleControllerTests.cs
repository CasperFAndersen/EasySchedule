using System;
using Core;
using DatabaseAccess.TemplateShifts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class TemplateScheduleControllerTests
    {
        TemplateScheduleController templateScheduleController = new TemplateScheduleController();
        TemplateShiftController _templateShiftController = new TemplateShiftController(new TemplateShiftRepository());

        [TestMethod]
        public void CreateTemplateScheduleTest()
        {
            TemplateSchedule tSchedule = templateScheduleController.CreateTemplateSchedule(10, "basicSchedule");

            Assert.IsNotNull(tSchedule);
            Assert.AreEqual(tSchedule.Name, "basicSchedule");
        }

        [TestMethod]
        public void GetAllTemplateSchedulesTest()
        {
            List<TemplateSchedule> templateSchedules = (List<TemplateSchedule>)templateScheduleController.GetAllTemplateSchedules();
            Assert.IsNotNull(templateSchedules);
        }

        [TestMethod]
        public void FindTemplateScheduleByNameTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void AddTemplateScheduleToDbTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void UpdateTemplateScheduleTest()
        {
            //TODO: Implement this
        }
    }
}
