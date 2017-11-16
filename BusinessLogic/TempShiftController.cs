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
        public TemplateShift CreateTempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            return new TemplateShift(weekNumber, hours, startTime, shiftEmployee);
        }

        public TemplateShift FindTempShiftByID(TemplateSchedule tSchedule, int tempShiftID)
        {
            TemplateShift tShift = tSchedule.ListOfTempShift.Where(x => x.ShiftEmployee.Id.Equals(tempShiftID)).FirstOrDefault();
            return tShift;
        }
    }
}
