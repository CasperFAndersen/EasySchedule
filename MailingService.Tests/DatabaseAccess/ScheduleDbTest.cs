using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Schedules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Departments;
using DatabaseAccess.Employees;
using System.Transactions;

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
        public void TestInsertSchedule()
        {
            ScheduleShift shift1 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2017, 11, 28, 8, 0, 0) };
            Schedule schedule = new Schedule() { Department = new DepartmentRepository().GetDepartmentById(3), StartDate = new DateTime(2017, 11, 27, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2017, 12, 18, 0, 0, 0, DateTimeKind.Utc) };
            schedule.Shifts.Add(shift1);

            int beforeInsert = schRep.GetSchedulesByDepartmentId(3).Count;
            int afterInsert = 0;

            schRep.InsertScheduleIntoDb(schedule);
            afterInsert = schRep.GetSchedulesByDepartmentId(3).Count;
            Assert.AreEqual(beforeInsert, afterInsert - 1);

        }

        [TestMethod()]
        public void GetSchedulesByDepartmentIdTest()
        {
            List<Schedule> schedules = schRep.GetSchedulesByDepartmentId(1);
            Assert.IsNotNull(schedules);
            Assert.AreNotEqual(0, schedules.Count);
        }

        [TestMethod]
        private void TestUpdateSchedule()
        {
            ScheduleRepository scheduleRepository = new ScheduleRepository();
            Schedule schedule = scheduleRepository.GetCurrentScheduleByDepartmentId(new DateTime(2017, 11, 27), 1);
            Shift s1 = schedule.Shifts[0];

            s1.StartTime = new DateTime(2017, 11, 30);
            s1.Hours = 6;

            Shift s2 = new Shift() { StartTime = new DateTime(2017, 11, 28), Hours = 7, Employee = new EmployeeRepository().FindEmployeeById(2) };
            schedule.Shifts.Add(s2);

            scheduleRepository.UpdateSchedule(schedule, 1);
            
            schedule = scheduleRepository.GetCurrentScheduleByDepartmentId(new DateTime(2017, 11, 27), 1);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(2, schedule.Shifts.Count);
            Assert.AreEqual(new DateTime(2017,11,27), schedule.Shifts[0] );
            Assert.AreEqual(new DateTime(2017,11,30), schedule.Shifts[1] );
            Assert.AreEqual(6, schedule.Shifts[0].Hours);
            Assert.AreEqual(7, schedule.Shifts[1].Hours);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DBSetUp.SetUpDB();
        }

    }
}

