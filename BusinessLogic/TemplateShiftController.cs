using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Employees;
using DatabaseAccess.TemplateShifts;

namespace BusinessLogic
{
    public class TemplateShiftController : ITemplateShiftControlller
    {
        private readonly ITemplateShiftRepository _templateShiftRepository;
        public TemplateShiftController(ITemplateShiftRepository templateShiftRepository)
        {
            _templateShiftRepository = templateShiftRepository;
        }

        public TemplateShift CreateTemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return new TemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            TemplateShift templateShift = _templateShiftRepository.FindTemplateShiftById(templateShiftId);
            templateShift.Employee = new EmployeeController(new EmployeeRepository()).GetEmployeeById(templateShift.Employee.Id);
            return templateShift;
        }
    }
}
