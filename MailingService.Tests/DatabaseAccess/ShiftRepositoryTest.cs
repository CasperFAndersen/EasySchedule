using System.Collections.Generic;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Employees;
using DatabaseAccess;
using DatabaseAccess.ScheduleShifts;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class ShiftRepositoryTest
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
        public void TestGetAllShiftsByScheduleId()
        {
            List<ScheduleShift> shifts = _scheduleShiftRepository.GetShiftsByScheduleId(1);

            Assert.IsNotNull(shifts);
            Assert.AreNotEqual(0, shifts.Count);
        }


        [TestMethod]
        public void TestIfShiftIsForSale()
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
        public void TestSetShiftForSale()
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
        public void TestAcceptAvailableShift()
        {
            ScheduleShift shift = _scheduleShiftRepository.GetShiftById(1);
            Employee employee = new EmployeeRepository().FindEmployeeById(5);
            Assert.AreNotEqual(shift.Employee, employee);

            _scheduleShiftRepository.AcceptAvailableShift(shift, employee);

            shift = _scheduleShiftRepository.GetShiftById(1);

            Assert.AreEqual(shift.Employee.Name, employee.Name);
            Assert.AreEqual(shift.IsForSale, false);
        }

        [TestMethod]
        public void TestGetAllAvailableShiftsByDepartment()
        {
            List<ScheduleShift> availableScheduleShifts = _scheduleShiftRepository.GetAllAvailableShiftsByDepartmentId(1);
            Assert.IsNotNull(availableScheduleShifts);
            Assert.AreEqual(2, availableScheduleShifts.Count);
        }
    }
}
