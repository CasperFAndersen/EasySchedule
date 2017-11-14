using System;
using BusinessLogic;
using Core;

namespace ServiceLibrary
{
    public class TempShiftService : ITempShiftService
    {
        TempShiftController tempShiftCtrl = new TempShiftController();
        public TempShift CreateTempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            return tempShiftCtrl.CreateTempShift(weekNumber, hours, startTime, shiftEmployee);
        }

        public TempShift FindTempShiftByID(TempSchedule tSchedule, int tempShiftID)
        {
            return tempShiftCtrl.FindTempShiftByID(tSchedule, tempShiftID);
        }
    }
}
