using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Schedules;
using DatabaseAccess.Departments;
using DatabaseAccess.ScheduleShifts;
using System.Transactions;

namespace BusinessLogic
{
    public class ScheduleController : IScheduleController
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IScheduleShiftController _scheduleShiftController;
        private readonly IDepartmentController _departmentController;

        public ScheduleController()
        {
            _scheduleRepository = new ScheduleRepository();
            _departmentController = new DepartmentController();
            _scheduleShiftController = new ScheduleShiftController();
        }
        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            _departmentController = new DepartmentController();
            _scheduleShiftController = new ScheduleShiftController();
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            Schedule schedule = null;
            List<Schedule> schedules = _scheduleRepository.GetSchedulesByDepartmentId(departmentId);
            if (schedules != null)
            {
                foreach (Schedule temporarySchedule in schedules)
                {
                    if (date >= (temporarySchedule.StartDate)  && date <= (temporarySchedule.EndDate))
                    {
                        schedule = temporarySchedule;
                    }
                }
                if (schedule != null)
                {
                    schedule.Department = _departmentController.GetDepartmentById(departmentId);
                    schedule.Shifts = _scheduleShiftController.GetShiftsByScheduleId(schedule.Id);
                }
            }
            return schedule;
        }

        public void InsertScheduleToDb(Schedule schedule)
        {           
            if (ValidateScheduleObject(schedule))
            {
                using(TransactionScope scope = new TransactionScope())
                {
                    schedule = _scheduleRepository.InsertSchedule(schedule);
                    _scheduleShiftController.AddShiftsFromSchedule(schedule);
                    scope.Complete();
                }
            }
            else
            {
                throw new ArgumentException("Insert schedule failed. Schedule time overlaps existing schedule");
            }
        }

        public void UpdateSchedule(Schedule schedule, List<ScheduleShift> deletedScheduleShifts)
        {
            if (ValidateScheduleObject(schedule))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _scheduleShiftController.AddShiftsFromSchedule(schedule);

                    deletedScheduleShifts.ForEach(x => _scheduleShiftController.DeleteScheduleShift(x));

                    scope.Complete();
                }
            }
            else
            {
                throw new ArgumentException("Insert schedule failed. Schedule time overlaps existing schedule");
            }
        }

        public void UpdateSchedule(Schedule schedule)
        {
            if (ValidateScheduleObject(schedule))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _scheduleShiftController.AddShiftsFromSchedule(schedule);
                    scope.Complete();
                }
            }
            else
            {
                throw new ArgumentException("Insert schedule failed. Schedule time overlaps existing schedule");
            }
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            Department department = _departmentController.GetDepartmentById(departmentId);
            List<Schedule> schedules = _scheduleRepository.GetSchedulesByDepartmentId(departmentId);
            foreach (Schedule schedule in schedules)
            {
                schedule.Department = department;
                schedule.Shifts = _scheduleShiftController.GetShiftsByScheduleId(schedule.Id);
            }

            return schedules;
        }

        /// <summary>
        /// This method takes a templateSchedule and returns a Schedule for the user to use.
        /// The returned Schedule can after the call be used without interfering with the template, and used as a base plan for your team.
        /// </summary>
        /// <param name="templateSchedule"></param>
        /// <param name="startTime"></param>
        /// <returns>
        /// Returns a schedule object with shifts added.
        /// </returns>
        public Schedule GenerateScheduleFromTemplateSchedule(TemplateSchedule templateSchedule, DateTime startTime)
        {
            Schedule schedule = new Schedule();
            schedule.Shifts = _scheduleShiftController.GenerateShiftsFromTemplateSchedule(templateSchedule, startTime);
            schedule.Department = _departmentController.GetDepartmentById(templateSchedule.DepartmentId);
            schedule.StartDate = startTime;
            schedule.EndDate = startTime.AddDays((7 * templateSchedule.NoOfWeeks)-1);
            return schedule;
        }

        private bool ValidateScheduleObject(Schedule schedule)
        {
            bool isOkToInput = true;

            if (GetScheduleByDepartmentIdAndDate(schedule.Department.Id, schedule.StartDate) != null
            || GetScheduleByDepartmentIdAndDate(schedule.Department.Id, schedule.EndDate) != null)
            {
                if (schedule.Id == 0)
                {
                    isOkToInput = false;
                }           
            }
            else if(schedule.StartDate > schedule.EndDate)
            {
                isOkToInput = false;
            }
            else if (schedule.Department == null)
            {
                isOkToInput = false;
            }
                return isOkToInput;
        }

    }
}
