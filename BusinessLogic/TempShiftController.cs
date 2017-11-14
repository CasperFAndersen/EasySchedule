using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TempShiftController
    {
        public TempShift CreateTempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            return new TempShift(weekNumber, hours, startTime, shiftEmployee);
        }

        public TempShift FindTempShiftByID(TempSchedule tSchedule, int tempShiftID)
        {
            TempShift tShift = tSchedule.ListOfTempShift.Where(x => x.ShiftEmployee.Id.Equals(tempShiftID)).FirstOrDefault();
            return tShift;
        }
    }
}
