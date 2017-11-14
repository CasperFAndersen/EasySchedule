using System;

namespace DatabaseAccess.Schedule
{
    public interface IScheduleRepository
    {
        Core.Schedule GetScheduleByCurrentDate(DateTime currentDate);
    }
}
