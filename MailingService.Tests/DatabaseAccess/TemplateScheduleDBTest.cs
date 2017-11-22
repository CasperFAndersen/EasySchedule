using System;
using System.Linq;
using Core;
using DatabaseAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DatabaseAccess.Employees;

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
            int beforeInsert = tempShiftDB.getAllShifts().Count();
            tSchedule.ListOfTempShifts.Add(TShift);

            tempScheduleDB.AddTempScheduleToDB(tSchedule);
            Assert.AreEqual(beforeInsert, tempShiftDB.getAllShifts().Count() - 1);

        }

        [TestMethod]
        public void TestGetAllSchedules()
        {
            TemplateScheduleDB tempScheduleDB = new TemplateScheduleDB();
            List<TemplateSchedule> tempSchedules = tempScheduleDB.GetAll().ToList();
            Assert.IsNotNull(tempScheduleDB);

        }

        [TestMethod]
        public void TestUpdateTempSchedule()
        {
            DBSetUp.SetUpDB();
            TemplateScheduleDB tScheduleDB = new TemplateScheduleDB();
            TemplateSchedule templateSchedule = tScheduleDB.FindTempScheduleByName("KolonialBasis");
            TemplateShift tempShift1 = templateSchedule.ListOfTempShifts[0];
            tempShift1.StartTime = new TimeSpan(8, 0, 0);
            tempShift1.Hours = 8;

            TemplateShift tempShift2 = new TemplateShift() { StartTime = new TimeSpan(12, 0, 0), Hours = 6, Employee = new EmployeeRepository().FindEmployeeById(5), TemplateScheduleID = templateSchedule.ID };
            templateSchedule.ListOfTempShifts.Add(tempShift2);

            tScheduleDB.UpdateTemplateSchedule(templateSchedule);

            templateSchedule = tScheduleDB.FindTempScheduleByName("KolonialBasis");

            Assert.IsNotNull(templateSchedule);
            Assert.AreEqual(2, templateSchedule.ListOfTempShifts.Count);
            Assert.AreEqual(new TimeSpan(8, 0, 0), templateSchedule.ListOfTempShifts[0].StartTime);
            Assert.AreEqual(new TimeSpan(12, 0, 0), templateSchedule.ListOfTempShifts[1].StartTime);
            Assert.AreEqual(8, templateSchedule.ListOfTempShifts[0].Hours);
            Assert.AreEqual(6, templateSchedule.ListOfTempShifts[1].Hours);
            DBSetUp.SetUpDB();

        }
    }
}
