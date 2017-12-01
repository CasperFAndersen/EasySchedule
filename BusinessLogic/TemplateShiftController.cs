using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.TemplateShifts;

namespace BusinessLogic
{
    public class TemplateShiftController : ITemplateShiftControlller
    {
        public TemplateShift CreateTemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return new TemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            TemplateShiftRepository templateShiftRepository = new TemplateShiftRepository();
            TemplateShift templateShift = templateShiftRepository.FindTemplateShiftById(templateShiftId);
            return templateShift;
        }
    }
}
