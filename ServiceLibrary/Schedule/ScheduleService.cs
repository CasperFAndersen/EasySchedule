using System;
using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Schedules;

namespace ServiceLibrary.Schedule
{
    public class ScheduleService : IScheduleService
    {
        IScheduleController scheduleController = new ScheduleController(new ScheduleRepository());

        public Core.Schedule GenerateScheduleFromTemplateScheduleAndStartDate(Core.TemplateSchedule tempSchedule, DateTime startTime)
        {
            return scheduleController.GetShiftsFromTemplateShift(tempSchedule, startTime);
        }

        public Core.Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return scheduleController.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public List<Core.Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return scheduleController.GetSchedulesByDepartmentId(departmentId);
        }

        public void InsertScheduleIntoDb(Core.Schedule schedule)
        {
            scheduleController.InsertSchedule(schedule);
        }

        public void UpdateSchedule(Core.Schedule schedule)
        {
            scheduleController.UpdateSchedule(schedule);
        }
    }
}
