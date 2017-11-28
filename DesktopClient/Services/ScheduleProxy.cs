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

        public Schedule GetCurrentScheduleDepartmentId(int depId)
        {
            return proxy.GetCurrentScheduleDepartmentId(depId);
        }

        public Task<Schedule> GetCurrentScheduleDepartmentIdAsync(int depId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            return proxy.GetScheduleByCurrentDate(currentDate);
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

        public void UpdateSchedule(Schedule schedule, int id)
        {
            proxy.UpdateSchedule(schedule, id);
        }

        public Task UpdateScheduleAsync(Schedule schedule, int id)
        {
            throw new NotImplementedException();
        }
    }
}
