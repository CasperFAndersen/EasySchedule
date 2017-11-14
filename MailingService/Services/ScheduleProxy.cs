using MailingService.ScheduleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace MailingService.Services
{
    public class ScheduleProxy : IScheduleService
    {
        IScheduleService proxy = new ScheduleServiceClient();

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            return proxy.GetScheduleByCurrentDate(currentDate);
        }

        public Task<Schedule> GetScheduleByCurrentDateAsync(DateTime currentDate)
        {
            throw new NotImplementedException();
        }
    }
}