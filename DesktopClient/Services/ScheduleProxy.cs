using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.ScheduleService;

namespace DesktopClient.Services
{
    public class ScheduleProxy : IScheduleService
    {
        ScheduleServiceClient proxy = new ScheduleServiceClient();

        public Schedule GenerateScheduleFromTemplateScheduleAndStartDate(TemplateSchedule tempSchedule, DateTime startTime)
        {
            return proxy.GenerateScheduleFromTemplateScheduleAndStartDate(tempSchedule, startTime);
        }

        public Task<Schedule> GenerateScheduleFromTemplateScheduleAndStartDateAsync(TemplateSchedule tempSchedule, DateTime startTime)
        {
            return proxy.GenerateScheduleFromTemplateScheduleAndStartDateAsync(tempSchedule, startTime);
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public Task<Schedule> GetScheduleByDepartmentIdAndDateAsync(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDateAsync(departmentId, date);
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return proxy.GetSchedulesByDepartmentId(departmentId);
        }

        public Task<List<Schedule>> GetSchedulesByDepartmentIdAsync(int departmentId)
        {
            return proxy.GetSchedulesByDepartmentIdAsync(departmentId);
        }

        public void InsertScheduleIntoDb(Schedule schedule)
        {
            proxy.InsertScheduleIntoDb(schedule);
        }

        public Task InsertScheduleIntoDbAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            proxy.UpdateSchedule(schedule);
        }

        public Task UpdateScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
