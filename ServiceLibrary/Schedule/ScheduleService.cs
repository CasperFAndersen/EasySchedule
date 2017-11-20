using System;
using BusinessLogic;

namespace ServiceLibrary.Schedule
{
    public class ScheduleService : IScheduleService
    {
        ScheduleController schCtrl = new ScheduleController();

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
