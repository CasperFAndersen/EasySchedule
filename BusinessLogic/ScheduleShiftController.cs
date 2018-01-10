using System;
using System.Collections.Generic;
using Core;
using DatabaseAccess.ScheduleShifts;

namespace BusinessLogic
{
    public class ScheduleShiftController : IScheduleShiftController
    {
        private readonly IScheduleShiftRepository _scheduleShiftRepository;

        public ScheduleShiftController(IScheduleShiftRepository scheduleShiftRepository)
        {
            _scheduleShiftRepository = scheduleShiftRepository;
        }
        public ScheduleShiftController()
        {
            _scheduleShiftRepository = new ScheduleShiftRepository();
        }

        /// <summary>
        /// This method is used when a user wants to accept a shift, that is available for sale.
        /// The method will also call the MailGun api method to send a mail to the employee whom accepted a shift.
        /// </summary>
        /// <param name="shift"></param>
        /// <param name="employee"></param>
        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            if (shift.IsForSale)
            {
                _scheduleShiftRepository.AcceptAvailableShift(shift, employee);
                MailSender mailSender = new MailSender();
                const string subject = "A shift has been accepted";
                string text = "The shift starting " + shift.StartTime + " and has a length of " + shift.Hours + " hours has been accepted by " + employee.Name;
                mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, employee.DepartmentId);
            }
            else
            {
                throw new ArgumentException("Failure to accept shift. One or more arguments are illegal!");
            }
        }

        public void AddShiftsFromSchedule(Schedule schedule)
        {
            if (ValidateScheduleShiftObjects(schedule.Shifts, schedule))
            {
                _scheduleShiftRepository.AddShiftsFromSchedule(schedule);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<ScheduleShift> GenerateShiftsFromTemplateSchedule(TemplateSchedule templateSchedule, DateTime startTime)
        {
            List<ScheduleShift> scheduleShifts = new List<ScheduleShift>();
            foreach (TemplateShift templateShift in templateSchedule.TemplateShifts)
            {
                ScheduleShift shift = new ScheduleShift();
                shift.Employee = templateShift.Employee;
                shift.Hours = templateShift.Hours;
                shift.StartTime = startTime.AddDays(((int)templateShift.WeekDay - 1) + (templateShift.WeekNumber - 1) * 7);
                shift.StartTime = shift.StartTime.AddHours(templateShift.StartTime.Hours);
                shift.StartTime = shift.StartTime.AddMinutes(templateShift.StartTime.Minutes);
                scheduleShifts.Add(shift);
            }
            return scheduleShifts;
        }

        public IEnumerable<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            return _scheduleShiftRepository.GetAllAvailableShiftsByDepartmentId(departmentId);
        }

        public List<ScheduleShift> GetShiftsByScheduleId(int scheduleId)
        {
            return _scheduleShiftRepository.GetShiftsByScheduleId(scheduleId);
        }

        public void SetScheduleShiftForSale(ScheduleShift scheduleShift)
        {
            _scheduleShiftRepository.SetScheduleShiftForSale(scheduleShift);
            MailSender mailSender = new MailSender();
            string subject = "A new shift has been set for sale";
            string text = scheduleShift.Employee.Name + " has set a shift starting " + scheduleShift.StartTime + " and has a length of " + scheduleShift.Hours + " hours for sale.";
            mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, scheduleShift.Employee.DepartmentId);
        }

        public bool ValidateScheduleShiftObject(ScheduleShift scheduleShift, Schedule schedule)
        {
            bool isOkToInsert = true;
            if (scheduleShift.Employee == null)
            {
                isOkToInsert = false;
            }
            else if (scheduleShift.Hours < 0)
            {
                isOkToInsert = false;
            }
            else if (scheduleShift.StartTime == null)
            {
                isOkToInsert = false;
            }
            return isOkToInsert;
        }

        public bool ValidateScheduleShiftObjects(List<ScheduleShift> scheduleShifts, Schedule schedule)
        {
            bool isOkToInsert = true;
            foreach (ScheduleShift scheduleShift in scheduleShifts)
            {
                if (!ValidateScheduleShiftObject(scheduleShift, schedule))
                {
                    isOkToInsert = false;
                }
            }
            return isOkToInsert;
        }

        public void DeleteScheduleShift(ScheduleShift scheduleShift)
        {
            _scheduleShiftRepository.DeleteScheduleShift(scheduleShift);
        }
    }
}
