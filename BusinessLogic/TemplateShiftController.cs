using Core;
using System;
using System.Collections.Generic;
using DatabaseAccess.TemplateShifts;

namespace BusinessLogic
{
    public class TemplateShiftController : ITemplateShiftControlller
    {
        private readonly ITemplateShiftRepository _templateShiftRepository;
        private readonly IEmployeeController _employeeController;

        public TemplateShiftController()
        {
            _templateShiftRepository = new TemplateShiftRepository();
            _employeeController = new EmployeeController();
        }

        public TemplateShiftController(ITemplateShiftRepository templateShiftRepository)
        {
            _templateShiftRepository = templateShiftRepository;
            _employeeController = new EmployeeController();
        }

        public void AddTemplateShiftsFromTemplateSchedule(int templateScheduleId, List<TemplateShift> templateShifts)
        {
            if (ValidateTemplateShifts(templateShifts))
            {
                _templateShiftRepository.AddTemplateShiftsFromTemplateSchedule(templateScheduleId, templateShifts);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        //Do we need this????
        public TemplateShift CreateTemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return new TemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            TemplateShift templateShift = _templateShiftRepository.FindTemplateShiftById(templateShiftId);
            templateShift.Employee = _employeeController.GetEmployeeById(templateShift.Employee.Id);
            return templateShift;
        }

        public List<TemplateShift> GetTemplateShiftsByTemplateScheduleId(int templateScheduleId)
        {
            List<TemplateShift> templateShifts = _templateShiftRepository.GetTemplateShiftsByTemplateScheduleId(templateScheduleId);
            templateShifts.ForEach((x) => { x.Employee = _employeeController.GetEmployeeById(x.Employee.Id); });
            return templateShifts;
        }

        public void DeleteTemplateShift(TemplateShift templateShift)
        {
            _templateShiftRepository.DeleteTemplateShift(templateShift);
        }

        private bool ValidateTemplateShift(TemplateShift templateShift)
        {
            bool isOkToInsert = true;
            if (templateShift.Hours < 0)
            {
                isOkToInsert = false;
            }
            else if (templateShift.Employee == null)
            {
                isOkToInsert = false;
            }
            else if (templateShift.TemplateScheduleId < 0)
            {
                isOkToInsert = false;
            }
            return isOkToInsert;
        }

        private bool ValidateTemplateShifts(List<TemplateShift> templateShifts)
        {
            bool isOkToInsert = true;
            foreach (TemplateShift templateShift in templateShifts)
            {
                if (!ValidateTemplateShift(templateShift))
                {
                    isOkToInsert = false;
                }
            }
            return isOkToInsert;
        }
    }
}
