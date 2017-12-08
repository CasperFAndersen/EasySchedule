using System;
using BusinessLogic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Schedules;
using System.Collections.Generic;
using Moq;
using Rhino.Mocks;
using MockRepository = Rhino.Mocks.MockRepository;
using DatabaseAccess.Employees;
using DatabaseAccess.ScheduleShifts;
using Tests.DatabaseAccess;

//using Moq;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestScheduleController
    {
        Schedule schedule;
        Mock<IScheduleRepository> scheduleRepository;
        private IScheduleShiftRepository _scheduleShiftRepository;
        ScheduleController scheduleController;
        private IScheduleRepository mockScheduleRepository;
        TemplateScheduleController templateScheduleController = new TemplateScheduleController();
        TemplateShiftController templateShiftController = new TemplateShiftController();

        [TestInitialize]
        public void InitializeTest()
        {
            _scheduleShiftRepository = MockRepository.GenerateMock<IScheduleShiftRepository>();
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
        [ExpectedException(typeof(Exception))]
        public void TestTryToInsertOverlappingSchedule()
        {
            scheduleController = new ScheduleController(new ScheduleRepository());

            Schedule schedule1 = new Schedule()
            {
                Department = new Department() { Id = 1 },
                StartDate = new DateTime(2018, 12, 4),
                EndDate = new DateTime(2018, 12, 11),
                Shifts = new List<ScheduleShift>(),
            };

            ScheduleShift shift1 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2018, 12, 5, 8, 0, 0) };
            schedule1.Shifts.Add(shift1);
            scheduleController.InsertScheduleToDb(schedule1);

            Schedule schedule2 = new Schedule()
            {
                Department = new Department() { Id = 1 },
                StartDate = new DateTime(2018, 11, 27),
                EndDate = new DateTime(2018, 12, 5),
                Shifts = new List<ScheduleShift>(),
            };

            ScheduleShift shift2 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2018, 11, 28, 8, 0, 0) };
            schedule1.Shifts.Add(shift2);

            scheduleController.InsertScheduleToDb(schedule2);
        }

        [TestMethod]
        public void TestGetAllAvailbleShiftsByDepartmentId()
        {
            scheduleController.ScheduleShiftRepository = _scheduleShiftRepository;
            scheduleController.GetAllAvailableShiftsByDepartmentId(1);
            scheduleController.ScheduleShiftRepository.AssertWasCalled(x => x.GetAllAvailableShiftsByDepartmentId(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Failure to accept shift. One or more arguments are illegal!")]
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

            scheduleController.ScheduleShiftRepository = MockRepository.GenerateMock<IScheduleShiftRepository>();

            ScheduleShift shift = new ScheduleShift()
            {
                StartTime = DateTime.Now.AddDays(-1),
                Hours = 4,
                Employee = new Employee(),
                IsForSale = true,
            };
            Employee employee = new Employee();

            scheduleController.AcceptAvailableShift(shift, employee);
            scheduleController.ScheduleShiftRepository.AssertWasCalled(x => x.AcceptAvailableShift(shift, employee));
        }

        [TestMethod()]
        public void TestGetScheduleByDepartmentIdAndDate()
        {
            scheduleController = new ScheduleController(new ScheduleRepository());
            Schedule schedule = scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));
            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017, 10, 30), schedule.StartDate);
            Assert.AreEqual(new DateTime(2017, 12, 10), schedule.EndDate);
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
                NoOfHours = 10,
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
                Mail = "test@test.dk",
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
            // scheduleRepository = new Mock<IScheduleRepository>();
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
        public void TestUpdateScheduleWithShiftSetForSale()
        {
            DbSetUp.SetUpDb();
            scheduleController = new ScheduleController(new ScheduleRepository());
            Schedule schedule = scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 12));

            Assert.IsFalse(schedule.Shifts[1].IsForSale);

            scheduleController.SetScheduleShiftForSale(schedule.Shifts[1]);
            schedule = scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 12));
            Assert.IsTrue(schedule.Shifts[1].IsForSale);
            DbSetUp.SetUpDb();
        }
    }
}
