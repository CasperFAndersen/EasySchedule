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
        private ITemplateScheduleRepository _templateScheduleRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            _templateScheduleRepository = new TemplateScheduleRepository();
            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void InsertTemplateScheduleTest()
        {
            List<TemplateSchedule> templateSchedules = _templateScheduleRepository.GetAllTemplateSchedules().ToList();
            int numberOfCurrentTemplateSchedules = templateSchedules.Count;
            TemplateSchedule templateSchedule = new TemplateSchedule(4, "DummySchedule", 1);
            _templateScheduleRepository.AddTemplateScheduleToDatabase(templateSchedule);
            Assert.AreNotEqual(numberOfCurrentTemplateSchedules, _templateScheduleRepository.GetAllTemplateSchedules().Count());
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
            _templateScheduleRepository = new TemplateScheduleRepository();
            List<TemplateSchedule> templateSchedules = _templateScheduleRepository.GetAllTemplateSchedules().ToList();
            Assert.IsNotNull(templateSchedules);
        }

        [TestMethod]
        public void UpdateTemplateScheduleTest()
        {
            TemplateSchedule templateSchedule = _templateScheduleRepository.GetAllTemplateSchedules().ToList()[0];
            byte[] rowVersion1 = templateSchedule.RowVersion;
            templateSchedule.NoOfWeeks = 2;

            _templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);
            templateSchedule = _templateScheduleRepository.GetAllTemplateSchedules().ToList()[0];
            byte[] rowVersion2 = templateSchedule.RowVersion;

            Assert.AreEqual(2, templateSchedule.NoOfWeeks);
            Assert.AreNotEqual(rowVersion1, rowVersion2);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            DbSetUp.SetUpDb();
        }
    }
}
