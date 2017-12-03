using System;
using BusinessLogic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Schedules;
using System.Collections.Generic;
using Rhino.Mocks;
using Moq;
using MockRepository = Rhino.Mocks.MockRepository;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestScheduleController
    {
        Schedule schedule;
        Mock<IScheduleRepository> scheduleRepository;
        ScheduleController scheduleController;
        private IScheduleRepository mockScheduleRepository;
        TemplateScheduleController templateScheduleController = new TemplateScheduleController();
        TemplateShiftController templateShiftController = new TemplateShiftController();

        [TestInitialize]
        public void InitializeTest()
        {



            mockScheduleRepository = MockRepository.GenerateMock<IScheduleRepository>();
            scheduleController = new ScheduleController(mockScheduleRepository);
        }

        [TestMethod]
        public void TestGetSchedueleByCurrentDate()
        {
            MockScheduleRep mockScheduleRep = new MockScheduleRep();
            DateTime currentDate = new DateTime(2017, 11, 13);
            Schedule schedule = mockScheduleRep.GetScheduleByCurrentDate(currentDate);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(3, schedule.Shifts.Count);
        }

        [TestMethod]
        public void TestInsertScheduleIntoDb()
        {
            Schedule s = new Schedule();
            mockScheduleRepository.InsertSchedule(s);
            mockScheduleRepository.AssertWasCalled(x => x.InsertSchedule(s));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Failure to accept shift. One or more arguments are illigal!")]
        public void TestIlligal_IsForSale_AcceptAvailableShift()
        {
            ScheduleShift shift = new ScheduleShift()
            {
                StartTime = DateTime.Now.AddDays(1),
                Hours = 4,
                Employee = new Employee(),
                IsForSale = false,
            };
            Employee employee = new Employee();

            scheduleController.AcceptAvailableShift(shift, employee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Failure to accept shift. One or more arguments are illigal!")]
        public void TestIlligal_AcceptTime_AcceptAvailableShift()
        {
            ScheduleShift shift = new ScheduleShift()
            {
                StartTime = DateTime.Now.AddDays(1),
                Hours = 4,
                Employee = new Employee(),
                IsForSale = true,
            };
            Employee employee = new Employee();

            scheduleController.AcceptAvailableShift(shift, employee);
        }

        [TestMethod]
        public void TestAcceptAvailableShift()
        {

            scheduleController._shiftRepository = MockRepository.GenerateMock<IShiftRepository>();

            ScheduleShift shift = new ScheduleShift()
            {
                StartTime = DateTime.Now.AddDays(-1),
                Hours = 4,
                Employee = new Employee(),
                IsForSale = true,
            };
            Employee employee = new Employee();

            scheduleController.AcceptAvailableShift(shift, employee);
            scheduleController._shiftRepository.AssertWasCalled(x => x.AcceptAvailableShift(shift, employee));
        }

        [TestMethod()]
        public void TestGetScheduleByDepartmentIdAndDate()
        {
            scheduleController = new ScheduleController(new ScheduleRepository());
            Schedule schedule = scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));
            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017, 10, 30), schedule.StartDate);
            Assert.AreEqual(new DateTime(2017, 11, 26), schedule.EndDate);
            Assert.AreNotEqual(0, schedule.Shifts.Count);
        }

        [TestMethod]
        public void TestMakeMoqWork()
        {
            List<Schedule> schedules = new List<Schedule>();
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee
            {
                Id = 1,
                Name = "Employee",
                DepartmentId = 1,
                IsAdmin = true,
                IsEmployed = true,
                Mail = "employee@employee.dk",
                NumbOfHours = 10,
                Username = "emp",
                Password = "emp",
                Phone = "12345678"
            };
            employees.Add(employee);

            Department department = new Department
            {
                Id = 1,
                Name = "Test",
                Address = "Address",
                Email = "test@test.dk",
                Employees = employees,
                Phone = "98765432"
            };

            List<ScheduleShift> shifts = new List<ScheduleShift>();
            ScheduleShift shift = new ScheduleShift
            {
                Id = 1,
                Employee = employee,
                Hours = 6,
                IsForSale = true,
                StartTime = new DateTime(2017, 12, 15, 10, 0, 0)
            };
            shifts.Add(shift);

            schedule = new Schedule
            {
                Id = 1,
                Department = department,
                StartDate = new DateTime(2017, 12, 01),
                EndDate = new DateTime(2017, 12, 31),
                Shifts = shifts
            };

            schedules.Add(schedule);
            scheduleRepository = new Mock<IScheduleRepository>();
            //scheduleRepository.Setup(x => x.GetSchedulesByDepartmentId(1).Returns(schedules));
        }

        [TestMethod]
        public void TestGetShiftsFromTemplateShift()
        {
            scheduleController = new ScheduleController(new ScheduleRepository());
            Employee employee = new Employee();
            TemplateSchedule templateSchedule = templateScheduleController.CreateTemplateSchedule(10, "basicSchedule");
            TemplateShift templateShift = templateShiftController.CreateTemplateShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, employee);
            TemplateShift templateShift2 = templateShiftController.CreateTemplateShift(DayOfWeek.Monday, 15.0, new TimeSpan(3, 1, 2), 2, employee);
            templateSchedule.TemplateShifts.Add(templateShift);
            templateSchedule.TemplateShifts.Add(templateShift2);

            Schedule schedule = scheduleController.GetShiftsFromTemplateShift(templateSchedule, DateTime.Now);
            Assert.AreEqual(templateSchedule.TemplateShifts.Count, schedule.Shifts.Count);
            Assert.AreEqual(schedule.Shifts[1].Hours, templateSchedule.TemplateShifts[1].Hours);
        }

        [TestMethod]
        public void TestShiftCanBeSetForSale()
        {
            scheduleController = new ScheduleController(new ScheduleRepository());
        }
    }
}
