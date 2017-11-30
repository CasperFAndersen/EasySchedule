using System;
using System.Linq;
using Core;
using DatabaseAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DatabaseAccess.Employees;
using DatabaseAccess.TemplateSchedule;

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
            TemplateScheduleRepository tScheduleRepository = new TemplateScheduleRepository();
            int numberOfCurrentTempSchedules = tScheduleRepository.GetAll().Count();

            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            tScheduleRepository.AddTempScheduleToDb(tSchedule);

            Assert.AreNotEqual(numberOfCurrentTempSchedules, tScheduleRepository.GetAll().Count());
            Assert.AreEqual(tScheduleRepository.FindTempScheduleByName("DummySchedule").Name, tSchedule.Name);
        }

        [TestMethod]
        public void TestAddTempShiftToTempScheldule()
        {
            TemplateShiftRepository tempShiftRepository = new TemplateShiftRepository();
            TemplateScheduleRepository tempScheduleRepository = new TemplateScheduleRepository();
            TemplateSchedule tSchedule = new TemplateSchedule(4, "DummySchedule", 1);
            TemplateShift TShift = new TemplateShift(DayOfWeek.Monday, 5, new TimeSpan(10,0,0), 1, new Employee() { Id=3});
            int beforeInsert = tempShiftRepository.GetAllShifts().Count();
            tSchedule.ListOfTempShifts.Add(TShift);

            tempScheduleRepository.AddTempScheduleToDb(tSchedule);
            Assert.AreEqual(beforeInsert, tempShiftRepository.GetAllShifts().Count() - 1);

        }

        [TestMethod]
        public void TestGetAllSchedules()
        {
            TemplateScheduleRepository tempScheduleRepository = new TemplateScheduleRepository();
            List<TemplateSchedule> tempSchedules = tempScheduleRepository.GetAll().ToList();
            Assert.IsNotNull(tempScheduleRepository);

        }

        [TestMethod]
        public void TestUpdateTempSchedule()
        {
            DBSetUp.SetUpDB();
            TemplateScheduleRepository tScheduleRepository = new TemplateScheduleRepository();
            TemplateSchedule templateSchedule = tScheduleRepository.FindTempScheduleByName("KolonialBasis");
            TemplateShift tempShift1 = templateSchedule.ListOfTempShifts[0];
            tempShift1.StartTime = new TimeSpan(8, 0, 0);
            tempShift1.Hours = 8;

            TemplateShift tempShift2 = new TemplateShift() { StartTime = new TimeSpan(12, 0, 0), WeekNumber = 1 ,Hours = 6, Employee = new EmployeeRepository().FindEmployeeById(5), TemplateScheduleId = templateSchedule.Id };
            templateSchedule.ListOfTempShifts.Add(tempShift2);

            tScheduleRepository.UpdateTemplateSchedule(templateSchedule);

            templateSchedule = tScheduleRepository.FindTempScheduleByName("KolonialBasis");

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
