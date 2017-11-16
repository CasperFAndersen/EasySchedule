using System;
using System.Linq;
using BusinessLogic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DataBaseAcces
{
    /// <summary>
    /// Summary description for TempScheduleDBTest
    /// </summary>
    [TestClass]
    public class TemplateScheduleDBTest
    {
        [TestMethod]
        public void TestCreateTempSchedule()
        {
            TempScheduleController tSC = new TempScheduleController();
            //int numberOfCurrentTempSchedules = tSC.GetAllTempSchedules().Count();

            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            tSC.AddTempScheduleToDB(tSchedule);

            Assert.AreNotEqual(0, tSC.GetAllTempSchedules().Count());
            Assert.AreEqual(tSC.FindTempScheduleByName("DummyScheldule"), tSchedule.Name);
        }

        [TestMethod]
        public void TestAddTempShiftToTempScheldule()
        {
            TempScheduleController tSC = new TempScheduleController();
            TempShiftController tShiftC = new TempShiftController();
            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 0);

            Employee employeeMichael = new Employee("Michael", "98271117", "Hej@DenEmail.dk", 10, false, "UsernameMichael", "PasswordMichael");
            TemplateShift TShift = new TemplateShift(DateTime.Now, 5, DateTime.Now, employeeMichael);

            tSchedule.AddTempShift(TShift);

            tSC.AddTempScheduleToDB(tSchedule);

            TemplateSchedule tScheduleFromDB = tSC.FindTempScheduleByName("DummySchedule");

            Assert.AreEqual(tShiftC.FindTempShiftByID(tScheduleFromDB, 1).ShiftEmployee.Name, employeeMichael.Name);
        }
    }
}
