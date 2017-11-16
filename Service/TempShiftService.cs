using System;
using BusinessLogic;
using Core;

namespace ServiceLibrary
{
    public class TempShiftService : ITempShiftService
    {
        TempShiftController tempShiftCtrl = new TempShiftController();
        public TemplateShift CreateTempShift(DayOfWeek weekDay, int hours, DateTime startTime, int templateScheduleID, int employeeID)
        {
            return tempShiftCtrl.CreateTempShift(weekDay, hours, startTime, templateScheduleID, employeeID);
        }

        public TemplateShift FindTempShiftByID(int tempShiftID)
        {
            return tempShiftCtrl.FindTempShiftByID(tempShiftID);
        }
    }
}
