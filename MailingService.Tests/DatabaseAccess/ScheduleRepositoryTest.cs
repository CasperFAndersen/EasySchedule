using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.Schedules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseAccess.Departments;
using DatabaseAccess.Employees;
using System.Transactions;
using BusinessLogic;

namespace Tests.DatabaseAccess
{
    [TestClass]
    public class ScheduleRepositoryTest
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

            schRep.InsertSchedule(schedule);
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

        [TestMethod()]
        public void TestUpdateSchedule()
        {
            Schedule schedule = new ScheduleController(schRep).GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));

            ScheduleShift scheduleShift = schedule.Shifts[0];
            scheduleShift.StartTime = scheduleShift.StartTime.AddDays(1);
            Employee emp = new Employee { Id = 1 };
            ScheduleShift scheduleShift2 = new ScheduleShift() { StartTime = new DateTime(2017, 11, 16, 8, 0, 0), Employee = emp, Hours = 5 };
            int shiftsBeforeInsert = schedule.Shifts.Count;
            int shiftsAfterInsert = 0;
            ScheduleShift shift1BeforeInsert = schedule.Shifts[0];
            schedule.Shifts.Add(scheduleShift2);
          
            schRep.UpdateSchedule(schedule);

            schedule = new ScheduleController(schRep).GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 11, 15));

            shiftsAfterInsert = schedule.Shifts.Count;

            Assert.AreNotEqual(shiftsBeforeInsert, shiftsAfterInsert);
            Assert.AreEqual(shiftsBeforeInsert, shiftsAfterInsert - 1);
            Assert.AreEqual(schedule.Shifts[0].StartTime, shift1BeforeInsert.StartTime);

            
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DBSetUp.SetUpDB();
        }
    }
}
