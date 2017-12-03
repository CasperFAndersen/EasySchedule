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
    public class ScheduleController : IScheduleController
    {
        private readonly IScheduleRepository _scheduleRepository;
        public IShiftRepository _shiftRepository;
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            _shiftRepository = new ShiftRepository();
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            Schedule schedule = null;
            List<Schedule> schedules = _scheduleRepository.GetSchedulesByDepartmentId(departmentId);
            foreach (Schedule temporarySchedule in schedules)
            {
                if (date.CompareTo(temporarySchedule.StartDate) > 0 && date.CompareTo(temporarySchedule.EndDate) < 0)
                {
                    schedule = temporarySchedule;
                }
            }
            schedule.Shifts = new ShiftRepository().GetShiftsByScheduleId(schedule.Id);

            return schedule;
        }

        public void InsertScheduleToDb(Schedule schedule)
        {
            _scheduleRepository.InsertSchedule(schedule);
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
            foreach (TemplateShift templateShift in templateSchedule.TemplateShifts)
            {
                ScheduleShift shift = new ScheduleShift();
                shift.Employee = templateShift.Employee;
                shift.Hours = templateShift.Hours;
                shift.StartTime = startTime.AddDays(((int)templateShift.WeekDay - 1) + (templateShift.WeekNumber - 1) * 7);
                shift.StartTime = shift.StartTime.AddHours(templateShift.StartTime.Hours);
                shift.StartTime = shift.StartTime.AddMinutes(templateShift.StartTime.Minutes);
                schedule.Shifts.Add(shift);
            }
            schedule.Department = new DepartmentRepository().GetDepartmentById(templateSchedule.DepartmentId);
            schedule.StartDate = startTime;
            schedule.EndDate = startTime.AddDays(7 * templateSchedule.NoOfWeeks);
            return schedule;
        }

        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            
            if(shift.StartTime < DateTime.Now && shift.IsForSale)
            {
                
                _shiftRepository.AcceptAvailableShift(shift, employee);
            }
            else
            {
                throw new ArgumentException("Failure to accept shift. One or more arguments are illigal!");
            }
        }
    }
}
