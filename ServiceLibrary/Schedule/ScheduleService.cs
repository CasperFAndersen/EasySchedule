using System;
using BusinessLogic;
using Core;
using DatabaseAccess.Schedules;

namespace ServiceLibrary.Schedule
{
    public class ScheduleService : IScheduleService
    {
        ScheduleController schCtrl = new ScheduleController(new ScheduleRepository());

        public Core.Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return schCtrl.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public void InsertScheduleIntoDb(Core.Schedule schedule)
        {
            schCtrl.InsertSchedule(schedule);
        }
    }
}
