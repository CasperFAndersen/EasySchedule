using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseAccess.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.TemplateSchedules;
using DatabaseAccess.TemplateShifts;
using Core;

namespace DatabaseAccess.Tests
{
    
    [TestClass]
    public class TemplateScheduleRepositoryTests
    {
        ITemplateScheduleRepository templateScheduleRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            templateScheduleRepository = new TemplateScheduleRepository();
            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void InsertTemplateScheduleTest()
        {

            List<TemplateSchedule> templateSchedules = templateScheduleRepository.GetAllTemplateSchedules().ToList();
            int numberOfCurrentTemplateSchedules = templateSchedules.Count;

            TemplateSchedule templateSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            templateScheduleRepository.AddTemplateScheduleToDatabase(templateSchedule);

            Assert.AreNotEqual(numberOfCurrentTemplateSchedules, templateScheduleRepository.GetAllTemplateSchedules().Count());
            Assert.AreEqual(templateScheduleRepository.GetTemplateScheduleByName("DummySchedule").Name, templateSchedule.Name);
        }

        [TestMethod]
        public void AddTemplateScheduleToDatabaseTest()
        {

            TemplateScheduleRepository templateScheduleRepository = new TemplateScheduleRepository();
            TemplateSchedule templateSchedule = new TemplateSchedule(4, "DummySchedule", 1);

            int beforeInsert = templateScheduleRepository.GetAllTemplateSchedules().Count();
           
            templateScheduleRepository.AddTemplateScheduleToDatabase(templateSchedule);

            int afterInsert = templateScheduleRepository.GetAllTemplateSchedules().Count();
            Assert.AreEqual(beforeInsert, (afterInsert - 1));
        }

        [TestMethod]
        public void GetTemplateScheduleByNameTest()
        {
            //TODO: Implement this
        }


        [TestMethod]
        public void GetAllTemplateSchedulesTest()
        {
            TemplateScheduleRepository templateScheduleRepository = new TemplateScheduleRepository();
            List<TemplateSchedule> templateSchedules = templateScheduleRepository.GetAllTemplateSchedules().ToList();
            Assert.IsNotNull(templateSchedules);
        }

        [TestMethod]
        public void UpdateTemplateScheduleTest()
        {
            TemplateSchedule templateSchedule = new TemplateSchedule() { Id = 1, NoOfWeeks = 2 };
            templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);
            templateSchedule = templateScheduleRepository.GetTemplateScheduleByName("KolonialBasis");


            Assert.AreEqual(2, templateSchedule.NoOfWeeks);

            //TemplateScheduleRepository templateScheduleRepository = new TemplateScheduleRepository();
            //TemplateSchedule templateSchedule = templateScheduleRepository.GetTemplateScheduleByName("KolonialBasis");
            //TemplateShift templateShift = templateSchedule.TemplateShifts[0];
            //templateShift.StartTime = new TimeSpan(8, 0, 0);
            //templateShift.Hours = 8;

            //TemplateShift templateShift2 = new TemplateShift() { StartTime = new TimeSpan(12, 0, 0), WeekNumber = 1, Hours = 6, Employee = new EmployeeRepository().GetEmployeeById(5), TemplateScheduleId = templateSchedule.Id };
            //templateSchedule.TemplateShifts.Add(templateShift2);

            //templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);

            //templateSchedule = templateScheduleRepository.GetTemplateScheduleByName("KolonialBasis");

            //Assert.IsNotNull(templateSchedule);
            //Assert.AreEqual(2, templateSchedule.TemplateShifts.Count);
            //Assert.AreEqual(new TimeSpan(8, 0, 0), templateSchedule.TemplateShifts[0].StartTime);
            //Assert.AreEqual(new TimeSpan(12, 0, 0), templateSchedule.TemplateShifts[1].StartTime);
            //Assert.AreEqual(8, templateSchedule.TemplateShifts[0].Hours);
            //Assert.AreEqual(6, templateSchedule.TemplateShifts[1].Hours);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            DbSetUp.SetUpDb();
        }
    }
}
