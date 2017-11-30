using System;
using BusinessLogic;

namespace ServiceLibrary.TemplateShift
{
    public class TemplateShiftService : ITempShiftService
    {
        TemplateShiftController tempShiftCtrl = new TemplateShiftController();
        public Core.TemplateShift CreateTempShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Core.Employee employee)
        {
            return tempShiftCtrl.CreateTempShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public Core.TemplateShift FindTempShiftById(int tempShiftID)
        {
            return tempShiftCtrl.FindTempShiftById(tempShiftID);
        }
    }
}
