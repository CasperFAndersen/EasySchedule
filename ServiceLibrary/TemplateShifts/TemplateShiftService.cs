using System;
using BusinessLogic;
using Core;
using DatabaseAccess.TemplateShifts;

namespace ServiceLibrary.TemplateShifts
{
    public class TemplateShiftService : ITemplateShiftService
    {
        TemplateShiftController templateShiftController = new TemplateShiftController(new TemplateShiftRepository());
        public TemplateShift CreateTemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return templateShiftController.CreateTemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            return templateShiftController.FindTemplateShiftById(templateShiftId);
        }
    }
}
