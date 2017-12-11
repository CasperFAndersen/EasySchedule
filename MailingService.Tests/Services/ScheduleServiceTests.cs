using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.ScheduleService;
using Core;
using System.Collections.Generic;
using DatabaseAccess.Employees;
using DatabaseAccess.Departments;
using Tests.DatabaseAccess;

namespace Tests.Services
{
    [TestClass]
    public class ScheduleServiceTests
    {
        ScheduleServiceClient client;

        [TestInitialize]
        public void TestInitialize()
        {
            client = new ScheduleServiceClient();
        }

        [TestMethod]
        public void GetSchedulesByDepartmentIdAndDateTest()
        {
            ScheduleServiceClient client = new ScheduleServiceClient();

            Schedule schedule = client.GetScheduleByDepartmentIdAndDate(1, new DateTime(2017, 10, 31));

            List<ScheduleShift> shifts = schedule.Shifts;

            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017, 10, 30), schedule.StartDate);
            Assert.AreNotEqual(0, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);

            // Schedule schedule2 = client.GetCurrentScheduleDepartmentId(2);

            //Assert.IsNotNull(schedule);
            //Assert.AreEqual(new DateTime(2017, 11, 20), schedule2.StartDate);
            //Assert.AreEqual(2, schedule2.Shifts.Count);
            //Assert.AreEqual("Pakkecentral", schedule2.Department.Name);

        }

        [TestMethod]
        public void InsertScheduleServiceTest()
        {
            ScheduleShift shift1 = new ScheduleShift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2017, 11, 28, 8, 0, 0) };
            Schedule schedule = new Schedule() { Department = new DepartmentRepository().GetDepartmentById(4), StartDate = new DateTime(2017, 11, 27, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2017, 12, 15) };
            schedule.Shifts.Add(shift1);

            client.InsertScheduleToDb(schedule);

            schedule = client.GetScheduleByDepartmentIdAndDate(4, new DateTime(2017, 11, 28, 0, 0, 0));

            Assert.IsNotNull(schedule);
            Assert.AreEqual(1, schedule.Shifts.Count);
            Assert.AreEqual("Mikkel Paulsen", schedule.Shifts[0].Employee.Name);
            Assert.AreEqual("Elektronik", schedule.Department.Name);

        }

        [TestMethod]
        public void GetAllAvailableShiftsByDepartmentIdTest()
        {
            List<ScheduleShift> availableScheduleShifts = client.GetAllAvailableShiftsByDepartmentId(1);
            Assert.IsNotNull(availableScheduleShifts);
            Assert.AreEqual(2, availableScheduleShifts.Count);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbSetUp.SetUpDb();
        }
    }
}
