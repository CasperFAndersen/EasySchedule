using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using BusinessLogic;

namespace Service
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
