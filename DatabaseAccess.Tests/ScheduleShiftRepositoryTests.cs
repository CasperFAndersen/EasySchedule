using System.Collections.Generic;
using Core;
using DatabaseAccess.Employees;
using DatabaseAccess.ScheduleShifts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod()]
        public void UpdateScheduleTest()
        {

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
            //Schedule schedule = new ScheduleController(_scheduleRepository).GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));

            //ScheduleShift scheduleShift = schedule.Shifts[0];
            //scheduleShift.StartTime = scheduleShift.StartTime.AddDays(1);
            //Employee emp = new Employee { Id = 1 };
            //ScheduleShift scheduleShift2 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 16, 8, 0, 0), Employee = emp, Hours = 5 };
            //int shiftsBeforeInsert = schedule.Shifts.Count;
            //int shiftsAfterInsert = 0;
            //ScheduleShift shift1BeforeInsert = schedule.Shifts[0];
            //schedule.Shifts.Add(scheduleShift2);

            //_scheduleRepository.UpdateSchedule(schedule);

            //schedule = new ScheduleController(_scheduleRepository).GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));

            //shiftsAfterInsert = schedule.Shifts.Count;

            //Assert.AreNotEqual(shiftsBeforeInsert, shiftsAfterInsert);
            //Assert.AreEqual(shiftsBeforeInsert, shiftsAfterInsert - 1);
            //Assert.AreEqual(schedule.Shifts[0].StartTime, shift1BeforeInsert.StartTime);
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
            List<ScheduleShift> shifts = _scheduleShiftRepository.GetShiftsByScheduleId(scheduleId);
            ScheduleShift scheduleShift = shifts[1];
            Assert.IsFalse(scheduleShift.IsForSale);
            scheduleShift.IsForSale = true;
            _scheduleShiftRepository.UpdateScheduleShift(scheduleShift, scheduleId, new DbConnection().GetConnection());
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
            List<ScheduleShift> availableScheduleShifts = _scheduleShiftRepository.GetAllAvailableShiftsByDepartmentId(1);
            Assert.IsNotNull(availableScheduleShifts);
            Assert.AreEqual(2, availableScheduleShifts.Count);
        }
    }
}
