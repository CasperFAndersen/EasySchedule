using System;
using System.Linq;
using Core;
using DatabaseAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DatabaseAccess
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
            //TempScheduleController tSC = new TempScheduleController();
            //int numberOfCurrentTempSchedules = tSC.GetAllTempSchedules().Count();
            TemplateScheduleDB tScheduleDB = new TemplateScheduleDB();
            int numberOfCurrentTempSchedules = tScheduleDB.GetAll().Count();

            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            tScheduleDB.AddTempScheduleToDB(tSchedule);

            Assert.AreNotEqual(numberOfCurrentTempSchedules, tScheduleDB.GetAll().Count());
            Assert.AreEqual(tScheduleDB.FindTempScheduleByName("DummySchedule").Name, tSchedule.Name);
        }

        [TestMethod]
        public void TestAddTempShiftToTempScheldule()
        {
            TemplateShiftDB tempShiftDB = new TemplateShiftDB();
            TemplateScheduleDB tempScheduleDB = new TemplateScheduleDB();
            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 1);
            TemplateShift TShift = new TemplateShift(DayOfWeek.Monday, 5, new TimeSpan(10,0,0), 1, new Employee() { Id=3});
            int beforeInsert = tempShiftDB.GetAllShifts().Count();
            tSchedule.ListOfTempShifts.Add(TShift);

            tempScheduleDB.AddTempScheduleToDB(tSchedule);
            Assert.AreEqual(beforeInsert, tempShiftDB.GetAllShifts().Count() - 1);

        }
    }
}
