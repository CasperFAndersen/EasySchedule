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

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public Task<Schedule> GetScheduleByDepartmentIdAndDateAsync(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDateAsync(departmentId, date);
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
