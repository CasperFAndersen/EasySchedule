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

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            return proxy.GetScheduleByCurrentDate(currentDate);
        }

        Task<Schedule> IScheduleService.GetScheduleByCurrentDateAsync(DateTime currentDate)
        {
            return GetScheduleByCurrentDateAsync(currentDate);
        }

        public Schedule GetCurrentScheduleDepartmentId(int depId)
        {
            return proxy.GetCurrentScheduleDepartmentId(depId);
        }

        public Task<Schedule> GetCurrentScheduleDepartmentIdAsync(int depId)
        {
            throw new NotImplementedException();
        }


        public Task<Schedule> GetScheduleByCurrentDateAsync(DateTime currentDate)
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
    }
}