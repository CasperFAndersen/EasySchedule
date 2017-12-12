using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Employees;
using DatabaseAccess.Schedules;
using DatabaseAccess.ScheduleShifts;
using DatabaseAccess.TemplateShifts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhino.Mocks;
using MockRepository = Rhino.Mocks.MockRepository;

//using Moq;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class ScheduleControllerTests
    {
        Mock<IScheduleRepository> scheduleRepository;
        private IScheduleShiftRepository _scheduleShiftRepository;
        ScheduleController scheduleController;
        private IScheduleRepository mockScheduleRepository;
        TemplateScheduleController templateScheduleController = new TemplateScheduleController();
        readonly TemplateShiftController _templateShiftController = new TemplateShiftController(new TemplateShiftRepository());

        [TestInitialize]
        public void InitializeTest()
        {
            _scheduleShiftRepository = MockRepository.GenerateMock<IScheduleShiftRepository>();
            mockScheduleRepository = MockRepository.GenerateMock<IScheduleRepository>();
            scheduleController = new ScheduleController(mockScheduleRepository);
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
            mockScheduleRepository.InsertSchedule(s);
            mockScheduleRepository.AssertWasCalled(x => x.InsertSchedule(s));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertOverlappingScheduleTest()
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







        [TestMethod()]
        public void GetScheduleByDepartmentIdAndDateTest()
        {
            scheduleController = new ScheduleController(new ScheduleRepository());
            Schedule schedule = scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));
            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017, 11, 01), schedule.StartDate);
            Assert.AreEqual(new DateTime(2018, 01, 31), schedule.EndDate);
            Assert.AreNotEqual(0, schedule.Shifts.Count);
        }

        [TestMethod]
        public void MakeMoqWorkTest()
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
                Email = "employee@employee.dk",
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

            Schedule schedule = new Schedule
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
        public void GetShiftsFromTemplateShiftTest()
        {
            scheduleController = new ScheduleController(new ScheduleRepository());
            Employee employee = new Employee();
            TemplateSchedule templateSchedule = templateScheduleController.CreateTemplateSchedule(10, "basicSchedule");
            TemplateShift templateShift = _templateShiftController.CreateTemplateShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, employee);
            TemplateShift templateShift2 = _templateShiftController.CreateTemplateShift(DayOfWeek.Monday, 15.0, new TimeSpan(3, 1, 2), 2, employee);
            templateSchedule.TemplateShifts.Add(templateShift);
            templateSchedule.TemplateShifts.Add(templateShift2);

            Schedule schedule = scheduleController.GenerateScheduleFromTemplateSchedule(templateSchedule, DateTime.Now);
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
