using System;
using BusinessLogic;
using Core;

namespace Service
{
    public class ScheduleService : IScheduleService
    {
        ScheduleController schCtrl = new ScheduleController();

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            return schCtrl.GetScheduleByCurrentDate(currentDate);
        }
    }
}
