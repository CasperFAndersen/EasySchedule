using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Schedules;
using DatabaseAccess.Shifts;
using DatabaseAccess.Departments;

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

        public void UpdateSchedule(Schedule schedule)
        {
            _scheduleRepository.UpdateSchedule(schedule);
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return _scheduleRepository.GetSchedulesByDepartmentId(departmentId);
        }

        public Schedule GetShiftsFromTemplateShift(TemplateSchedule templateSchedule, DateTime startTime)
        {
            Schedule schedule = new Schedule();
            foreach (TemplateShift ts in templateSchedule.ListOfTempShifts)
            {
                ScheduleShift shift = new ScheduleShift();
                shift.Employee = ts.Employee;
                shift.Hours = ts.Hours;
                shift.StartTime = startTime.AddDays(((int)ts.WeekDay - 1) + (ts.WeekNumber - 1) * 7);
                shift.StartTime = shift.StartTime.AddHours(ts.StartTime.Hours);
                shift.StartTime = shift.StartTime.AddMinutes(ts.StartTime.Minutes);
                schedule.Shifts.Add(shift);
            }
            schedule.Department = new DepartmentRepository().GetDepartmentById(templateSchedule.DepartmentID);
            schedule.StartDate = startTime;
            schedule.EndDate = startTime.AddDays(7 * templateSchedule.NoOfWeeks);
            return schedule;
        }
    }
}
