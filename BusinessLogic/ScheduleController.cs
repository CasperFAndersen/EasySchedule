using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Schedules;
using DatabaseAccess.Shifts;

namespace BusinessLogic
{
    public class ScheduleController
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            Schedule scheduleRes = null;
            List<Schedule> schedules = _scheduleRepository.GetSchedulesByDepartmentId(departmentId);
            foreach (Schedule schedule in schedules)
            {
                if (date.CompareTo(schedule.StartDate) > 0 && date.CompareTo(schedule.EndDate) < 0)
                {
                    scheduleRes = schedule;
                }
            }
            scheduleRes.Shifts = new ShiftRepository().GetShiftsByScheduleID(scheduleRes.Id);

            return scheduleRes;           
        }

        public void InsertSchedule(Schedule schedule)
        {
            _scheduleRepository.InsertScheduleIntoDb(schedule);
        }

    }
}
