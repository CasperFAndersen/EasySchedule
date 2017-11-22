using System;
using BusinessLogic;
using DatabaseAccess.Schedules;

namespace ServiceLibrary.Schedule
{
    public class ScheduleService : IScheduleService
    {
        ScheduleController schCtrl = new ScheduleController(new ScheduleRepository());

        public Core.Schedule GetCurrentScheduleDepartmentId(int depId)
        {
            return schCtrl.GetCurrentScheduleByDepartmentId(depId);
        }

        public Core.Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            return schCtrl.GetScheduleByCurrentDate(currentDate);
        }
    }
}
