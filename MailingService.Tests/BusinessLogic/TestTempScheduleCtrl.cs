using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using Core;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestTempScheduleCtrl
    {
        TempScheduleController tempSchCtrl = new TempScheduleController();
        TempShiftController tempShiftCtrl = new TempShiftController();

        [TestMethod]
        public void TestCreateTemplateSchedule()
        {
            TemplateSchedule tSchedule = tempSchCtrl.createTemplateSchedule(10, "basicSchedule");

            Assert.IsNotNull(tSchedule);
            Assert.AreEqual(tSchedule.Name, "basicSchedule");
        }

        [TestMethod]
        public void TestAddTempShiftToTempSchedule()
        {
            Employee e = new Employee();
            TemplateSchedule tSchedule = tempSchCtrl.createTemplateSchedule(10, "basicSchedule");
            TemplateShift tempShift1 = tempShiftCtrl.CreateTempShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, e);
            TemplateShift tempShift2 = tempShiftCtrl.CreateTempShift(DayOfWeek.Monday, 15.0, new TimeSpan(3, 1, 2), 2, e);
            tSchedule.AddTempShift(tempShift1);
            tSchedule.AddTempShift(tempShift2);

            Assert.IsNotNull(tSchedule.ListOfTempShifts);
            Assert.AreEqual(tSchedule.ListOfTempShifts[0].WeekDay, DayOfWeek.Friday);
            Assert.IsTrue(tSchedule.ListOfTempShifts.Count == 2);
        }
    }
}
