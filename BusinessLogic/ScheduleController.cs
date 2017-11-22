using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Schedules;

namespace BusinessLogic
{
    public class ScheduleController
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            int day = (int)DayOfWeek.Monday;
            DateTime date = new DateTime(currentDate.Year, currentDate.Month, day);

            return _scheduleRepository.GetScheduleByCurrentDate(date);
        }

        public Schedule GetCurrentScheduleByDepartmentId(int id)
        {

            DateTime currentDate = DateTime.Now;
            //int day = currentDate.Day - ((int)currentDate.DayOfWeek -1);
            int day = (currentDate.DayOfWeek == DayOfWeek.Sunday) ? (currentDate.Day - 6) : (currentDate.Day - ((int)currentDate.DayOfWeek - 1));
            DateTime date = new DateTime(currentDate.Year, currentDate.Month, day);

            return _scheduleRepository.GetCurrentScheduleByDepartmentId(date, id);
        }

    }
}
