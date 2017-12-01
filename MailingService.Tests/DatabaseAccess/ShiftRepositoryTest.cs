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
            foreach(ScheduleShift s in shifts)
            {
                s.IsForSale = false
            }
        }
    }
}
