using System.Collections.Generic;
using Core;
using DatabaseAccess.Shifts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Employees;
using DatabaseAccess;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class ShiftRepositoryTest
    {
        IShiftRepository shiftRepository;

        [TestInitialize]
        public void TestInitializer()
        {
            DbSetUp.SetUpDb();
            shiftRepository = new ShiftRepository();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            DbSetUp.SetUpDb();
        }


        [TestMethod]
        public void TestGetAllShiftsByScheduleId()
        {
            List<ScheduleShift> shifts = shiftRepository.GetShiftsByScheduleId(1);

            Assert.IsNotNull(shifts);
            Assert.AreNotEqual(0, shifts.Count);
        }


        [TestMethod]
        public void TestIfShiftIsForSale()
        {
            List<ScheduleShift> shifts = shiftRepository.GetShiftsByScheduleId(1);
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
            List<ScheduleShift> shifts = shiftRepository.GetShiftsByScheduleId(scheduleId);
            ScheduleShift scheduleShift = shifts[1];
            Assert.IsFalse(scheduleShift.IsForSale);
            scheduleShift.IsForSale = true;
            shiftRepository.UpdateScheduleShift(scheduleShift, scheduleId, new DbConnection().GetConnection());
            List<ScheduleShift> shiftsAfterUpdate = shiftRepository.GetShiftsByScheduleId(scheduleId);
            Assert.IsTrue(shiftsAfterUpdate[1].IsForSale);
        }

        [TestMethod]
        public void TestAcceptAvailableShift()
        {
            ScheduleShift shift = shiftRepository.GetShiftById(1);
            Employee employee = new EmployeeRepository().FindEmployeeById(5);
            Assert.AreNotEqual(shift.Employee, employee);

            shiftRepository.AcceptAvailableShift(shift, employee);

            shift = shiftRepository.GetShiftById(1);

            Assert.AreEqual(shift.Employee.Name, employee.Name);
            Assert.AreEqual(shift.IsForSale, false);
        }

        [TestMethod]
        public void TestGetAllAvailableShiftsByDepartment()
        {
            List<ScheduleShift> availableScheduleShifts = shiftRepository.GetAllAvailableShiftsByDepartmentId(1);
            Assert.IsNotNull(availableScheduleShifts);
            Assert.AreEqual(2, availableScheduleShifts.Count);
        }
    }
}
