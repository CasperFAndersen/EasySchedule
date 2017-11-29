using System.Collections.Generic;
using Core;
using DatabaseAccess.Shifts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class ShiftDbTest
    {
        IShiftRepository shiftRep = new ShiftRepository(); 

        
        
        [TestMethod]
        public void TestGetAllShiftsByScheduleId()
        {
            DBSetUp.SetUpDB();

            List<ScheduleShift> shifts = shiftRep.GetShiftsByScheduleID(1);

            Assert.IsNotNull(shifts);
            Assert.AreEqual(3, shifts.Count);
        }
    }
}
