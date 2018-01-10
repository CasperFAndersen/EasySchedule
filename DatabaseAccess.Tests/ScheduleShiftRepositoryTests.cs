using System.Collections.Generic;
using Core;
using DatabaseAccess.Employees;
using DatabaseAccess.ScheduleShifts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using BusinessLogic;

namespace DatabaseAccess.Tests
{
    [TestClass]
    public class ScheduleShiftRepositoryTests
    {
        IScheduleShiftRepository _scheduleShiftRepository;

        [TestInitialize]
        public void TestInitializer()
        {
            DbSetUp.SetUpDb();
            _scheduleShiftRepository = new ScheduleShiftRepository();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            DbSetUp.SetUpDb();
        }

        [TestMethod]
        public void TestGetRowVersion()
        {
            ScheduleShift scheduleShift = _scheduleShiftRepository.GetShiftById(1);
            Assert.IsNotNull(scheduleShift);
        }

        [TestMethod()]
        public void UpdateScheduleTest()
        {
            Schedule schedule = new ScheduleController().GetSchedulesByDepartmentId(1)[0];
            ScheduleShift scheduleShift = schedule.Shifts[0];
            int shiftId = 0;
            byte[] rowVersion1 = scheduleShift.RowVersion;
            scheduleShift.Hours = 100;

            _scheduleShiftRepository.AddShiftsFromSchedule(schedule);

            scheduleShift = _scheduleShiftRepository.GetShiftById(shiftId);
            byte[] rowVersion2 = scheduleShift.RowVersion;

            Assert.IsNotNull(scheduleShift);
            Assert.AreNotEqual(rowVersion1, rowVersion2);
        }

        [TestMethod()]
        [ExpectedException(typeof(DataInInvalidStateException))]
        public void UpdateScheduleFailTest()
        {
            Schedule schedule = new ScheduleController().GetSchedulesByDepartmentId(1)[0];

            ScheduleShift scheduleShift = schedule.Shifts[0];
            byte[] rowVersion1 = scheduleShift.RowVersion;
            scheduleShift.Hours = 100;

            _scheduleShiftRepository.AddShiftsFromSchedule(schedule);

            //This is where the exception should be thrown
            _scheduleShiftRepository.AddShiftsFromSchedule(schedule);
        }

        [TestMethod]
        public void GetShiftByIdTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void GetShiftsByEmployeeIdTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void AddShiftsFromScheduleTest()
        {
            //TODO: Implement test
        }

        [TestMethod]
        public void UpdateScheduleShiftTest()
        {
            //TODO: Implement this
        }

        [TestMethod]
        public void GetShiftsByScheduleIdTest()
        {
            List<ScheduleShift> shifts = _scheduleShiftRepository.GetShiftsByScheduleId(1);

            Assert.IsNotNull(shifts);
            Assert.AreNotEqual(0, shifts.Count);
        }


        [TestMethod]
        public void ShiftIsForSaleTest()
        {
            List<ScheduleShift> shifts = _scheduleShiftRepository.GetShiftsByScheduleId(1);
            List<ScheduleShift> shiftsForSale = new List<ScheduleShift>();
            foreach (ScheduleShift s in shifts)
            {
                if (s.IsForSale)
                {
                    shiftsForSale.Add(s);
                }
            }
            Assert.AreEqual(2, shiftsForSale.Count);
        }

        [TestMethod]
        public void SetShiftForSaleTest()
        {
            int scheduleId = 1;
            Schedule schedule = new ScheduleController().GetSchedulesByDepartmentId(scheduleId)[0];
            List<ScheduleShift> shifts = schedule.Shifts;
            ScheduleShift scheduleShift = shifts[1];
            Assert.IsFalse(scheduleShift.IsForSale);
            scheduleShift.IsForSale = true;
            _scheduleShiftRepository.AddShiftsFromSchedule(schedule);
            List<ScheduleShift> shiftsAfterUpdate = _scheduleShiftRepository.GetShiftsByScheduleId(scheduleId);
            Assert.IsTrue(shiftsAfterUpdate[1].IsForSale);
        }

        [TestMethod]
        public void AcceptAvailableShiftTest()
        {
            ScheduleShift shift = _scheduleShiftRepository.GetShiftById(1);
            Employee employee = new EmployeeRepository().GetEmployeeById(5);
            Assert.AreNotEqual(shift.Employee, employee);
            _scheduleShiftRepository.AcceptAvailableShift(shift, employee);
            shift = _scheduleShiftRepository.GetShiftById(1);
            Assert.AreEqual(shift.Employee.Name, employee.Name);
            Assert.AreEqual(shift.IsForSale, false);
        }

        [TestMethod]
        public void GetAllAvailableShiftsByDepartmentTest()
        {
            List<ScheduleShift> availableScheduleShifts = _scheduleShiftRepository.GetAllAvailableShiftsByDepartmentId(1).ToList();
            Assert.IsNotNull(availableScheduleShifts);
            Assert.AreEqual(2, availableScheduleShifts.Count);
        }
    }
}
