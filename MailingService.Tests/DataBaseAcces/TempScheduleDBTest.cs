using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using DatabaseAccess;
using BusinessLogic;
using System.Linq;

namespace MailingService.Tests.DataBaseAcces
{
    /// <summary>
    /// Summary description for TempScheduleDBTest
    /// </summary>
    [TestClass]
    public class TempScheduleDBTest
    {
        [TestMethod]
        public void TestCreateTempSchedule()
        {
            //TempScheduleDB tSDB = new TempScheduleDB();
            TempScheduleController tSC = new TempScheduleController();
            int numberOfCurrentTempSchedules = tSC.GetAllTempSchedules().Count();

            TempSchedule tSchedule = new TempSchedule(4, "DummySchedule");

            tSC.AddTempScheduleToDB(tSchedule);

            Assert.AreNotEqual(numberOfCurrentTempSchedules, tSC.GetAllTempSchedules().Count());
            Assert.AreEqual(tSC.FindTempScheduleByName("DummyScheldule"), tSchedule.Name);
        }

        [TestMethod]
        public void TestAddTempShiftToTempScheldule()
        {
            //TempScheduleDB tSDB = new TempScheduleDB();
            TempScheduleController tSC = new TempScheduleController();
            TempShiftController tShiftC = new TempShiftController();
            TempSchedule tSchedule = new TempSchedule(4, "DummySchedule");

            Employee employeeMichael = new Employee("Michael", "98271117", "Hej@DenEmail.dk", 10, false, "UsernameMichael", "PasswordMichael");
            TempShift TShift = new TempShift(DateTime.Now, 5, DateTime.Now, employeeMichael);

            tSchedule.AddTempShift(TShift);

            tSC.AddTempScheduleToDB(tSchedule);

            TempSchedule tScheduleFromDB = tSC.FindTempScheduleByName("DummySchedule");

            Assert.AreEqual(tShiftC.FindTempShiftByID(tScheduleFromDB, 1).ShiftEmployee.Name, employeeMichael.Name);
        }
    }
}
