using System;
using BusinessLogic;
using Core;
using DatabaseAccess.TemplateShifts;

namespace ServiceLibrary.TemplateShifts
{
    public class TemplateShiftService : ITemplateShiftService
    {
        readonly TemplateShiftController _templateShiftController = new TemplateShiftController();

        public TemplateShift CreateTemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return _templateShiftController.CreateTemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            return _templateShiftController.FindTemplateShiftById(templateShiftId);
        }
    }
}
