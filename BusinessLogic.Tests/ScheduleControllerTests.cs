using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Employees;
using DatabaseAccess.Schedules;
using DatabaseAccess.TemplateShifts;
using DatabaseAccess.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using MockRepository = Rhino.Mocks.MockRepository;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class ScheduleControllerTests
    {
        private ScheduleController _scheduleController;
        private IScheduleRepository _mockScheduleRepository;
        private TemplateScheduleController _templateScheduleController;
        private TemplateShiftController _templateShiftController;

        [TestInitialize]
        public void InitializeTest()
        {
            _mockScheduleRepository = MockRepository.GenerateMock<IScheduleRepository>();
            _scheduleController = new ScheduleController(_mockScheduleRepository);
            _templateScheduleController = new TemplateScheduleController();
            _templateShiftController = new TemplateShiftController(new TemplateShiftRepository());
        }

        [TestMethod]
        public void GetScheduleByCurrentDateTest()
        {
            MockScheduleRep mockScheduleRep = new MockScheduleRep();
            DateTime currentDate = new DateTime(2017, 11, 13);
            Schedule schedule = mockScheduleRep.GetScheduleByCurrentDate(currentDate);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(3, schedule.Shifts.Count);
        }

        [TestMethod]
        public void InsertScheduleToDbTest()
        {
            Schedule s = new Schedule();
            _mockScheduleRepository.InsertSchedule(s);
            _mockScheduleRepository.AssertWasCalled(x => x.InsertSchedule(s));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertOverlappingScheduleTest()
        {
            DbSetUp.SetUpDb();

            _scheduleController = new ScheduleController(new ScheduleRepository());

            Schedule schedule1 = new Schedule()
            {
                Department = new Department() { Id = 1 },
                StartDate = new DateTime(2018, 12, 4),
                EndDate = new DateTime(2018, 12, 11),
                Shifts = new List<ScheduleShift>(),
            };

            ScheduleShift shift1 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2018, 12, 5, 8, 0, 0) };
            schedule1.Shifts.Add(shift1);
            _scheduleController.InsertScheduleToDb(schedule1);

            Schedule schedule2 = new Schedule()
            {
                Department = new Department() { Id = 1 },
                StartDate = new DateTime(2018, 11, 27),
                EndDate = new DateTime(2018, 12, 5),
                Shifts = new List<ScheduleShift>(),
            };

            ScheduleShift shift2 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2018, 11, 28, 8, 0, 0) };
            schedule1.Shifts.Add(shift2);

            _scheduleController.InsertScheduleToDb(schedule2);

            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void GetScheduleByDepartmentIdAndDateTest()
        {
            DbSetUp.SetUpDb();
            _scheduleController = new ScheduleController(new ScheduleRepository());
            Schedule schedule = _scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));
            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017, 11, 01), schedule.StartDate);
            Assert.AreEqual(new DateTime(2017, 11, 30), schedule.EndDate);
            Assert.AreNotEqual(0, schedule.Shifts.Count);
            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void GetShiftsFromTemplateShiftTest()
        {
            _scheduleController = new ScheduleController(new ScheduleRepository());
            Employee employee = new Employee();
            TemplateSchedule templateSchedule = _templateScheduleController.CreateTemplateSchedule(10, "basicSchedule");
            TemplateShift templateShift = _templateShiftController.CreateTemplateShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, employee);
            TemplateShift templateShift2 = _templateShiftController.CreateTemplateShift(DayOfWeek.Monday, 15.0, new TimeSpan(3, 1, 2), 2, employee);
            templateSchedule.TemplateShifts.Add(templateShift);
            templateSchedule.TemplateShifts.Add(templateShift2);

            Schedule schedule = _scheduleController.GenerateScheduleFromTemplateSchedule(templateSchedule, DateTime.Now);
            Assert.AreEqual(templateSchedule.TemplateShifts.Count, schedule.Shifts.Count);
            Assert.AreEqual(schedule.Shifts[1].Hours, templateSchedule.TemplateShifts[1].Hours);
        }

        [TestMethod]
        public void UpdateScheduleTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void GetSchedulesByDepartmentIdTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void GetAllAvailableShiftsByDepartmentIdTest()
        {
            //TODO: Implement this
        }
    }
}
