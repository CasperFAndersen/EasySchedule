using System;
using BusinessLogic;
using Core;

namespace ServiceLibrary
{
    public class TempShiftService : ITempShiftService
    {
        TempShiftController tempShiftCtrl = new TempShiftController();
        public TemplateShift CreateTempShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleID, Employee employee)
        {
            return tempShiftCtrl.CreateTempShift(weekDay, hours, startTime, templateScheduleID, employee);
        }

        public TemplateShift FindTempShiftByID(int tempShiftID)
        {
            return tempShiftCtrl.FindTempShiftByID(tempShiftID);
        }
    }
}
