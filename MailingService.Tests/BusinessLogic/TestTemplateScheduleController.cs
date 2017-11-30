using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using Core;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestTemplateScheduleController
    {
        TemplateScheduleController tempSchCtrl = new TemplateScheduleController();
        TemplateShiftController tempShiftCtrl = new TemplateShiftController();

        [TestMethod]
        public void TestCreateTemplateSchedule()
        {
            TemplateSchedule tSchedule = tempSchCtrl.CreateTemplateSchedule(10, "basicSchedule");

            Assert.IsNotNull(tSchedule);
            Assert.AreEqual(tSchedule.Name, "basicSchedule");
        }

        [TestMethod]
        public void TestAddTempShiftToTempSchedule()
        {
            Employee e = new Employee();
            TemplateSchedule tSchedule = tempSchCtrl.CreateTemplateSchedule(10, "basicSchedule");
            TemplateShift tempShift1 = tempShiftCtrl.CreateTempShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, e);
            TemplateShift tempShift2 = tempShiftCtrl.CreateTempShift(DayOfWeek.Monday, 15.0, new TimeSpan(3, 1, 2), 2, e);
            tSchedule.ListOfTempShifts.Add(tempShift1);
            tSchedule.ListOfTempShifts.Add(tempShift2);

            Assert.IsNotNull(tSchedule.ListOfTempShifts);
            Assert.AreEqual(tSchedule.ListOfTempShifts[0].WeekDay, DayOfWeek.Friday);
            Assert.IsTrue(tSchedule.ListOfTempShifts.Count == 2);
        }
    }
}
