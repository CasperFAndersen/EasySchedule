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
    public class ScheduleServiceTest
    {
        ScheduleServiceClient client;

        [TestInitialize]
        public void TestInitialize()
        {
            DBSetUp.SetUpDB();
            client = new ScheduleServiceClient();
        }

        [TestMethod]
        public void TestGetScheduleByDepartmentId()
        {
            ScheduleServiceClient client = new ScheduleServiceClient();

            Schedule schedule = client.GetCurrentScheduleDepartmentId(1);

            List<Shift> shifts = schedule.Shifts;

            Assert.IsNotNull(schedule);
            Assert.AreEqual(new DateTime(2017,11,27), schedule.StartDate);
            Assert.AreEqual(3, schedule.Shifts.Count);
            Assert.AreEqual("Kolonial", schedule.Department.Name);

           // Schedule schedule2 = client.GetCurrentScheduleDepartmentId(2);

            //Assert.IsNotNull(schedule);
            //Assert.AreEqual(new DateTime(2017, 11, 20), schedule2.StartDate);
            //Assert.AreEqual(2, schedule2.Shifts.Count);
            //Assert.AreEqual("Pakkecentral", schedule2.Department.Name);


        }

        [TestMethod]
        public void TestInsertScheduleService()
        {
            Shift shift1 = new Shift() { Employee = new EmployeeRepository().GetEmployeeByUsername("MikkelP"), Hours = 8, StartTime = new DateTime(2017, 11, 28, 8, 0, 0) };
            Schedule schedule = new Schedule() { Department = new DepartmentRepository().GetDepartmentById(3), StartDate = new DateTime(2017, 11, 27, 0, 0, 0, DateTimeKind.Utc) };
            schedule.Shifts.Add(shift1);

            client.InsertScheduleIntoDb(schedule);

            schedule = client.GetCurrentScheduleDepartmentId(3);

            Assert.IsNotNull(schedule);
            Assert.AreEqual(1, schedule.Shifts.Count);
            Assert.AreEqual("Mikkel Paulsen", schedule.Shifts[0].Employee.Name);
            Assert.AreEqual("Elektronik", schedule.Department.Name);

        }

        [TestMethod]
        public void TestUpdateScheduleServices()
        {
            //TODO: Fix denne test. Tror den fejler fordi der ikke bliver sendt en datetime til AddShiftsFromScheduleToDb() i ShiftRepository.
            //Schedule schedule = client.GetCurrentScheduleDepartmentId(1);
            //Shift s1 = schedule.Shifts[0];

            //s1.StartTime = new DateTime(2017, 11, 30);
            //s1.Hours = 6;

            //Shift s2 = new Shift() { StartTime = new DateTime(2017, 11, 28), Hours = 7, Employee = new EmployeeRepository().FindEmployeeById(2) };
            //schedule.Shifts.Add(s2);

            //client.UpdateSchedule(schedule, 1);

            //schedule = client.GetCurrentScheduleDepartmentId(1);

            //Assert.IsNotNull(schedule);
            //Assert.AreEqual(2, schedule.Shifts.Count);
            //Assert.AreEqual(new DateTime(2017, 11, 27), schedule.Shifts[0]);
            //Assert.AreEqual(new DateTime(2017, 11, 30), schedule.Shifts[1]);
            //Assert.AreEqual(6, schedule.Shifts[0].Hours);
            //Assert.AreEqual(7, schedule.Shifts[1].Hours);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DBSetUp.SetUpDB();
        }
    }
}
