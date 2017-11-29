using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Schedules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Departments;
using DatabaseAccess.Employees;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class ScheduleDbTest
    {
        ScheduleRepository schRep;

        [TestInitialize]
        public void TestInitialize()
        {
            DBSetUp.SetUpDB();
            schRep = new ScheduleRepository();
        }
        

        [TestMethod]
        public void TestGetScheduleByCurrentDate()
        {
            DateTime currentDate = new DateTime(2017, 11, 13);

            Schedule schedule = schRep.GetScheduleByCurrentDate(currentDate);

            Assert.IsNotNull(schedule);
            //Assert.AreEqual(3, schedule.Shifts.Count);
        }

        [TestMethod]
        public void TestGetCurrentScheduleByDepartmentId()
        {
            DateTime currentDate = new DateTime(2017,11,27);

            Schedule schedule = schRep.GetCurrentScheduleByDepartmentId(currentDate, 1);

            List<ScheduleShift> shifts = schedule.Shifts;

            Assert.IsNotNull(schedule);
            Assert.AreEqual(schedule.StartDate, currentDate);
            Assert.AreEqual(3, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);
        }

        [TestMethod]
        public void TestInsertSchedule()
        {
            ScheduleShift shift1 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2017, 11, 28, 8, 0, 0) };
            Schedule schedule = new Schedule() { Department = new DepartmentRepository().GetDepartmentById(3), StartDate = new DateTime(2017,11,27, 0, 0, 0, DateTimeKind.Utc)};
            schedule.Shifts.Add(shift1);

            schRep.InsertScheduleIntoDb(schedule);

            schedule = schRep.GetCurrentScheduleByDepartmentId(new DateTime(2017,11,27), 3);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(1, schedule.Shifts.Count);
            Assert.AreEqual("Mikkel Paulsen", schedule.Shifts[0].Employee.Name);
            Assert.AreEqual("Elektronik", schedule.Department.Name);

        }

        [TestCleanup]
        public void TestCleanup()
        {
           DBSetUp.SetUpDB();
        }
    }
}
