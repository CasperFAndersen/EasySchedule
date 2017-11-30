using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TemplateShiftController : ITemplateShiftControlller
    {
        public TemplateShift CreateTempShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return new TemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTempShiftById(int tempShiftId)
        {
            TemplateShiftRepository templateShiftRepository = new TemplateShiftRepository();
            TemplateShift templateShift = templateShiftRepository.FindTempShiftById(tempShiftId);
            return templateShift;
        }
    }
}
