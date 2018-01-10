using System;
using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Schedules;

namespace ServiceLibrary.Schedules
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleController _scheduleController = new ScheduleController();

        public Schedule GenerateScheduleFromTemplateScheduleAndStartDate(TemplateSchedule templateSchedule, DateTime startTime)
        {
            return _scheduleController.GenerateScheduleFromTemplateSchedule(templateSchedule, startTime);
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return _scheduleController.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return _scheduleController.GetSchedulesByDepartmentId(departmentId);
        }

        public void InsertScheduleToDb(Schedule schedule)
        {
            _scheduleController.InsertScheduleToDb(schedule);
        }

        public void UpdateScheduleWithDelete(Schedule schedule, List<ScheduleShift> deletedScheduleShifts)
        {
            _scheduleController.UpdateSchedule(schedule, deletedScheduleShifts);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _scheduleController.UpdateSchedule(schedule);
        }
    }
}
