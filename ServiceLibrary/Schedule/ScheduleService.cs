using System;
using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Schedules;

namespace ServiceLibrary.Schedule
{
    public class ScheduleService : IScheduleService
    {
        ScheduleController schCtrl = new ScheduleController(new ScheduleRepository());

        public Core.Schedule GenerateScheduleFromTemplateScheduleAndStartDate(TemplateSchedule tempSchedule, DateTime startTime)
        {
            return schCtrl.GetShiftsFromTemplateShift(tempSchedule, startTime);
        }

        public Core.Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return schCtrl.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public List<Core.Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return schCtrl.GetSchedulesByDepartmentId(departmentId);
        }

        public void InsertScheduleIntoDb(Core.Schedule schedule)
        {
            schCtrl.InsertSchedule(schedule);
        }

        public void UpdateSchedule(Core.Schedule schedule)
        {
            schCtrl.UpdateSchedule(schedule);
        }
    }
}
