using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Moq;
using DatabaseAccess.ScheduleShifts;
using MockRepository = Rhino.Mocks.MockRepository;
using Rhino.Mocks;
using DatabaseAccess.Schedules;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class ScheduleShiftControllerTests
    {
        private IScheduleShiftRepository _mockScheduleRepository;
        private IScheduleShiftController _scheduleShiftController;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockScheduleRepository = MockRepository.GenerateMock<IScheduleShiftRepository>();
            _scheduleShiftController = new ScheduleShiftController(_mockScheduleRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Failure to accept shift. One or more arguments are illegal!")]
        public void IllegalIsForSaleAcceptAvailableShiftTest()
        {
            ScheduleShift shift = new ScheduleShift()
            {
                StartTime = DateTime.Now.AddDays(1),
                Hours = 4,
                Employee = new Employee(),
                IsForSale = false,
            };
            Employee employee = new Employee();

            _scheduleShiftController.AcceptAvailableShift(shift, employee);
        }

        [TestMethod]
        public void AcceptAvailableShiftTest()
        {
            //TODO

            ScheduleShift shift = new ScheduleShift()
            {
                StartTime = DateTime.Now.AddDays(-1),
                Hours = 4,
                Employee = new Employee(),
                IsForSale = true,
            };
            Employee employee = new Employee();

            _scheduleShiftController.AcceptAvailableShift(shift, employee);
            //_scheduleshiftcontroller.sch .assertwascalled(x => x.acceptavailableshift(shift, employee));
        }

        [TestMethod]
        public void SetScheduleShiftForSaleTest()
        {
            ScheduleController scheduleController = new ScheduleController(new ScheduleRepository());
            _scheduleShiftController = new ScheduleShiftController(new ScheduleShiftRepository());
            Schedule schedule = scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 12));

            Assert.IsFalse(schedule.Shifts[1].IsForSale);

            _scheduleShiftController.SetScheduleShiftForSale(schedule.Shifts[1]);

            schedule = scheduleController.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 12));
            Assert.IsTrue(schedule.Shifts[1].IsForSale);
        }

        [TestMethod]
        public void GetAllAvailbleShiftsByDepartmentIdTest()
        {
            //TODO
            //_scheduleShiftController.GetAllAvailableShiftsByDepartmentId(1);
            //_scheduleShiftController.AssertWasCalled(x => x.GetAllAvailableShiftsByDepartmentId(1));
        }
    }
}
