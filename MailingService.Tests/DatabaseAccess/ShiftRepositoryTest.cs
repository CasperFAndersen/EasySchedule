using System.Collections.Generic;
using Core;
using DatabaseAccess.Shifts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class ShiftRepositoryTest
    {
        IShiftRepository shiftRepository;

        [TestInitialize]
        public void TestInitializer()
        {
            DBSetUp.SetUpDB();
            shiftRepository = new ShiftRepository();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            DBSetUp.SetUpDB();
        }


        [TestMethod]
        public void TestGetAllShiftsByScheduleId()
        {
            DBSetUp.SetUpDB();

            List<ScheduleShift> shifts = shiftRepository.GetShiftsByScheduleId(1);

            Assert.IsNotNull(shifts);
            Assert.AreNotEqual(0, shifts.Count);
        }

        [TestMethod]
        public void TestIfShiftIsForSale()
        {
            List<ScheduleShift> shifts = shiftRepository.GetShiftsByScheduleId(1);
            List<ScheduleShift> shiftsForSale = new List<ScheduleShift>();
            foreach(ScheduleShift s in shifts)
            {
                if(s.IsForSale)
                {
                    shiftsForSale.Add(s);
                }
            }
            Assert.AreEqual(2, shiftsForSale.Count);
        }

        [TestMethod]
        public void TestSetShiftForSale()
        {
            List<ScheduleShift> shifts = shiftRepository.GetShiftsByScheduleId(1);
            ScheduleShift tempScheduleShift = shifts[1];
            tempScheduleShift.
        }
    }
}
