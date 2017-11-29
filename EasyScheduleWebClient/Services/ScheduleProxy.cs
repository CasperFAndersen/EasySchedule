using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Core;
using EasyScheduleWebClient.ScheduleService;

namespace EasyScheduleWebClient.Services
{
    public class ScheduleProxy : IScheduleService
    {
        IScheduleService proxy = new ScheduleServiceClient();

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public Task<Schedule> GetScheduleByDepartmentIdAndDateAsync(int departmentId, DateTime date)
        {
            throw new NotImplementedException();
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