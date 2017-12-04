using System;
using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Schedules;

namespace ServiceLibrary.Schedules
{
    public class ScheduleService : IScheduleService
    {
        IScheduleController scheduleController = new ScheduleController(new ScheduleRepository());

        public Schedule GenerateScheduleFromTemplateScheduleAndStartDate(TemplateSchedule templateSchedule, DateTime startTime)
        {
            return scheduleController.GetShiftsFromTemplateShift(templateSchedule, startTime);
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return scheduleController.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return scheduleController.GetSchedulesByDepartmentId(departmentId);
        }

        public void InsertScheduleToDb(Schedule schedule)
        {
            scheduleController.InsertScheduleToDb(schedule);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            scheduleController.UpdateSchedule(schedule);
        }

        public void SetShiftForSale(Core.ScheduleShift scheduleShift)
        {
            scheduleController.SetShiftForSale(scheduleShift);
        }
    }
}
