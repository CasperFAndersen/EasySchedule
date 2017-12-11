using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using Core;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TemplateScheduleControllerTests
    {
        TemplateScheduleController templateScheduleController = new TemplateScheduleController();
        TemplateShiftController templateShiftController = new TemplateShiftController();

        [TestMethod]
        public void CreateTemplateScheduleTest()
        {
            TemplateSchedule tSchedule = templateScheduleController.CreateTemplateSchedule(10, "basicSchedule");

            Assert.IsNotNull(tSchedule);
            Assert.AreEqual(tSchedule.Name, "basicSchedule");
        }

        [TestMethod]
        public void AddTemplateShiftToTemplateScheduleTest()
        {
            Employee e = new Employee();
            TemplateSchedule tSchedule = templateScheduleController.CreateTemplateSchedule(10, "basicSchedule");
            TemplateShift templateShift1 = templateShiftController.CreateTemplateShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, e);
            TemplateShift templateShift2 = templateShiftController.CreateTemplateShift(DayOfWeek.Monday, 15.0, new TimeSpan(3, 1, 2), 2, e);
            tSchedule.TemplateShifts.Add(templateShift1);
            tSchedule.TemplateShifts.Add(templateShift2);

            Assert.IsNotNull(tSchedule.TemplateShifts);
            Assert.AreEqual(tSchedule.TemplateShifts[0].WeekDay, DayOfWeek.Friday);
            Assert.IsTrue(tSchedule.TemplateShifts.Count == 2);
        }
    }
}
