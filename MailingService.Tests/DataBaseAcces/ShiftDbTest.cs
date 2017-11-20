using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Shifts;
using Core;
using System.Collections.Generic;

namespace Tests.DataBaseAcces
{
    [TestClass]
    public class ShiftDbTest
    {
        IShiftRepository shiftRep = new ShiftRepository(); 

        
        
        [TestMethod]
        public void TestGetAllShiftsByScheduleId()
        {
            DBSetUp.SetUpDB();

            List<Shift> shifts = shiftRep.GetShiftsByScheduleID(1);

            Assert.IsNotNull(shifts);
            Assert.AreEqual(3, shifts.Count);
        }
    }
}
