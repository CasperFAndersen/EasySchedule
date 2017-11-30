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
        ScheduleController schCtrl;
        private IScheduleRepository mockScheduleRepository;
        TemplateScheduleController tempSchCtrl = new TemplateScheduleController();
        TemplateShiftController tempShiftCtrl = new TemplateShiftController();

        [TestInitialize]
        public void InitializeTest()
        {
            mockScheduleRepository = MockRepository.GenerateMock<IScheduleRepository>();
            schCtrl = new ScheduleController(mockScheduleRepository);
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
            mockScheduleRepository.InsertScheduleIntoDb(s);
            mockScheduleRepository.AssertWasCalled(x => x.InsertScheduleIntoDb(s));
        }

        [TestMethod()]
        public void GetScheduleByDepartmentIdAndDateTest()
        {
            schCtrl = new ScheduleController(new ScheduleRepository());

            Schedule schedule = schCtrl.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));
            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017, 10, 30), schedule.StartDate);
            Assert.AreEqual(new DateTime(2017, 11, 26), schedule.EndDate);
            Assert.AreNotEqual(0, schedule.Shifts.Count);

        }

        [TestMethod]
        public void GetShiftsFromTemplateShiftTest()
        {
            schCtrl = new ScheduleController(new ScheduleRepository());
            Employee e = new Employee();
            TemplateSchedule tSchedule = tempSchCtrl.CreateTemplateSchedule(10, "basicSchedule");
            TemplateShift tempShift1 = tempShiftCtrl.CreateTempShift(DayOfWeek.Friday, 10.0, new TimeSpan(10, 0, 0), 1, e);
            TemplateShift tempShift2 = tempShiftCtrl.CreateTempShift(DayOfWeek.Monday, 15.0, new TimeSpan(3, 1, 2), 2, e);
            tSchedule.ListOfTempShifts.Add(tempShift1);
            tSchedule.ListOfTempShifts.Add(tempShift2);

            Schedule schedule = schCtrl.GetShiftsFromTemplateShift(tSchedule, DateTime.Now);
            Assert.AreEqual(tSchedule.ListOfTempShifts.Count, schedule.Shifts.Count);
            Assert.AreEqual(schedule.Shifts[1].Hours, tSchedule.ListOfTempShifts[1].Hours);
        }
    }
}
