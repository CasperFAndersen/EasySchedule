using System;
using System.Linq;
using Core;
using DatabaseAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DatabaseAccess.Employees;
using DatabaseAccess.TemplateSchedules;
using DatabaseAccess.TemplateShifts;

namespace Tests.DatabaseAccess
{
    /// <summary>
    /// Summary description for TemplateScheduleDBTest
    /// </summary>
    [TestClass]
    public class TemplateScheduleRepositoryTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void TestCreateTemplateSchedule()
        {
            //TemplateScheduleController tSC = new TemplateScheduleController();
            //int numberOfCurrentTemplateSchedules = tSC.GetAllTemplateSchedules().Count();
            TemplateScheduleRepository templateScheduleRepository = new TemplateScheduleRepository();
            int numberOfCurrentTemplateSchedules = templateScheduleRepository.GetAllTemplateSchedules().Count();

            TemplateSchedule templateSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            templateScheduleRepository.AddTemplateScheduleToDatabase(templateSchedule);

            Assert.AreNotEqual(numberOfCurrentTemplateSchedules, templateScheduleRepository.GetAllTemplateSchedules().Count());
            Assert.AreEqual(templateScheduleRepository.FindTemplateScheduleByName("DummySchedule").Name, templateSchedule.Name);
        }

        [TestMethod]
        public void TestAddTemplateShiftToTemplateScheldule()
        {
            TemplateShiftRepository templateShiftRepository = new TemplateShiftRepository();
            TemplateScheduleRepository templateScheduleRepository = new TemplateScheduleRepository();
            TemplateSchedule templateSchedule = new TemplateSchedule(4, "DummySchedule", 1);
            TemplateShift templateShift = new TemplateShift(DayOfWeek.Monday, 5, new TimeSpan(10, 0, 0), 1, new Employee() { Id = 3 });
            int beforeInsert = templateShiftRepository.GetAllTemplateShifts().Count();
            templateSchedule.TemplateShifts.Add(templateShift);

            templateScheduleRepository.AddTemplateScheduleToDatabase(templateSchedule);
            Assert.AreEqual(beforeInsert, templateShiftRepository.GetAllTemplateShifts().Count() - 1);

        }

        [TestMethod]
        public void TestGetAllTemplateSchedules()
        {
            TemplateScheduleRepository templateScheduleRepository = new TemplateScheduleRepository();
            List<TemplateSchedule> templateSchedules = templateScheduleRepository.GetAllTemplateSchedules().ToList();
            Assert.IsNotNull(templateScheduleRepository);

        }

        [TestMethod]
        public void TestUpdateTemplateSchedule()
        {
            TemplateScheduleRepository templateScheduleRepository = new TemplateScheduleRepository();
            TemplateSchedule templateSchedule = templateScheduleRepository.FindTemplateScheduleByName("KolonialBasis");
            TemplateShift templateShift = templateSchedule.TemplateShifts[0];
            templateShift.StartTime = new TimeSpan(8, 0, 0);
            templateShift.Hours = 8;

            TemplateShift templateShift2 = new TemplateShift() { StartTime = new TimeSpan(12, 0, 0), WeekNumber = 1, Hours = 6, Employee = new EmployeeRepository().FindEmployeeById(5), TemplateScheduleId = templateSchedule.Id };
            templateSchedule.TemplateShifts.Add(templateShift2);

            templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);

            templateSchedule = templateScheduleRepository.FindTemplateScheduleByName("KolonialBasis");

            Assert.IsNotNull(templateSchedule);
            Assert.AreEqual(2, templateSchedule.TemplateShifts.Count);
            Assert.AreEqual(new TimeSpan(8, 0, 0), templateSchedule.TemplateShifts[0].StartTime);
            Assert.AreEqual(new TimeSpan(12, 0, 0), templateSchedule.TemplateShifts[1].StartTime);
            Assert.AreEqual(8, templateSchedule.TemplateShifts[0].Hours);
            Assert.AreEqual(6, templateSchedule.TemplateShifts[1].Hours);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbSetUp.SetUpDb();
        }
    }
}
