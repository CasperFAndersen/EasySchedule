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
<<<<<<< HEAD

=======
        
>>>>>>> EPIC-Opret_Vagtplan_MaybeTheNewest
        ScheduleController schCtrl;
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
    }
}
