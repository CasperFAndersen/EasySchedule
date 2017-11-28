using System;
using BusinessLogic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Schedules;
using Rhino.Mocks;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class TestScheduleCtrl
    {
        
        ScheduleController schCtrl = new ScheduleController(new ScheduleRepository());
        private IScheduleRepository mockScheduleRepository;

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
        public void TestGetCurrentScheduleByDepartmentId()
        {
            ScheduleController sCtrl = new ScheduleController(new ScheduleRepository());
            Schedule schedule = sCtrl.GetCurrentScheduleByDepartmentId(1);

            Assert.AreEqual(3, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);
            Assert.IsNotNull(schedule);
        }

        [TestMethod]
        public void TestInsertScheduleIntoDb()
        {
            Schedule s = new Schedule();
            mockScheduleRepository.InsertScheduleIntoDb(s);
            mockScheduleRepository.AssertWasCalled(x => x.InsertScheduleIntoDb(s));
        }
    }
}
