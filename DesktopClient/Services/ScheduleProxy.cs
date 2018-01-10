using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using DesktopClient.ScheduleService;

namespace DesktopClient.Services
{
    public class ScheduleProxy : IScheduleService
    {
        private readonly ScheduleServiceClient _scheduleServiceClient = new ScheduleServiceClient();

        public Schedule GenerateScheduleFromTemplateScheduleAndStartDate(TemplateSchedule templateSchedule, DateTime startTime)
        {
            return _scheduleServiceClient.GenerateScheduleFromTemplateScheduleAndStartDate(templateSchedule, startTime);
        }

        public Task<Schedule> GenerateScheduleFromTemplateScheduleAndStartDateAsync(TemplateSchedule templateSchedule, DateTime startTime)
        {
            return _scheduleServiceClient.GenerateScheduleFromTemplateScheduleAndStartDateAsync(templateSchedule, startTime);
        }

        public IEnumerable<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScheduleShift>> GetAllAvailableShiftsByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return _scheduleServiceClient.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public Task<Schedule> GetScheduleByDepartmentIdAndDateAsync(int departmentId, DateTime date)
        {
            return _scheduleServiceClient.GetScheduleByDepartmentIdAndDateAsync(departmentId, date);
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return _scheduleServiceClient.GetSchedulesByDepartmentId(departmentId);
        }

        public Task<List<Schedule>> GetSchedulesByDepartmentIdAsync(int departmentId)
        {
            return _scheduleServiceClient.GetSchedulesByDepartmentIdAsync(departmentId);
        }

        public void InsertScheduleToDb(Schedule schedule)
        {
            _scheduleServiceClient.InsertScheduleToDb(schedule);
        }

        public Task InsertScheduleToDbAsync(Schedule schedule)
        {
            return _scheduleServiceClient.InsertScheduleToDbAsync(schedule);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _scheduleServiceClient.UpdateSchedule(schedule);
        }

        public Task UpdateScheduleAsync(Schedule schedule)
        {
            return _scheduleServiceClient.UpdateScheduleAsync(schedule);
        }

        public void UpdateScheduleWithDelete(Schedule schedule, List<ScheduleShift> deletedScheduleShifts)
        {
            _scheduleServiceClient.UpdateScheduleWithDelete(schedule, deletedScheduleShifts);
        }

        public Task UpdateScheduleWithDeleteAsync(Schedule schedule, List<ScheduleShift> deletedScheduleShifts)
        {
            return _scheduleServiceClient.UpdateScheduleWithDeleteAsync(schedule, deletedScheduleShifts);
        }
    }
}
