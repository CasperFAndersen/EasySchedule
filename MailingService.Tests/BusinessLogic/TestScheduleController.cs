using System;
using BusinessLogic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Schedules;
using Rhino.Mocks;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestScheduleController
    {
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
            DateTime currentDate = new DateTime(2017,11,13);
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
        public void TestAcceptAvailableShift()
        {
            ScheduleShift shift = new ScheduleShift()
            {
                StartTime = DateTime.Now.AddDays(-1),
                Hours = 4,
                Employee = new Employee(),
                IsForSale = false,
            };
            try
            {
                scheduleController.AcceptAvailableShift(shift, new Employee());
                Assert.Fail();
            }
            catch (Exception)
            {
               
               
            }
            try
            {
                shift.IsForSale = true;
                scheduleController.AcceptAvailableShift(shift, new Employee());
             
            }
            catch (Exception)
            {

                throw;
            }
        

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
    }
}
