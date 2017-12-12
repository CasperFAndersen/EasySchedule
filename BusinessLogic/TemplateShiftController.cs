using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using DatabaseAccess.Employees;
using DatabaseAccess.TemplateShifts;

namespace BusinessLogic
{
    public class TemplateShiftController : ITemplateShiftController
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

        public TemplateShift CreateTemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return new TemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            TemplateShift templateShift = _templateShiftRepository.FindTemplateShiftById(templateShiftId);
            templateShift.Employee = new EmployeeController().GetEmployeeById(templateShift.Employee.Id);
            return templateShift;
        }

        public List<TemplateShift> GetTemplateShiftsByTemplateScheduleId(int templateScheduleId)
        {
            List<TemplateShift> templateShifts = _templateShiftRepository.GetTemplateShiftsByTemplateScheduleId(templateScheduleId);
            foreach (TemplateShift templateShift in templateShifts)
            {
                templateShift.Employee = _employeeController.GetEmployeeById(templateShift.Employee.Id);
            }
            return templateShifts;
        }

        public void AddTemplateShiftsFromTemplateSchedule(int templateScheduleId, List<TemplateShift> templateShifts)
        {
            _templateShiftRepository.AddTemplateShiftsFromTemplateSchedule(templateScheduleId, templateShifts);
        }
    }
}
