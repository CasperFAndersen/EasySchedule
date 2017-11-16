using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TempShiftController
    {
        public TemplateShift CreateTempShift(DayOfWeek weekDay, int hours, DateTime startTime, int templateScheduleID, int employeeID)
        {
            return new TemplateShift(weekDay, hours, startTime, templateScheduleID, employeeID);
        }

        public TemplateShift FindTempShiftByID(int tempShiftID)
        {
            TemplateShiftDB tShiftDB = new TemplateShiftDB();
            //TemplateShift tShift = tSchedule.ListOfTempShifts.Where(x => x.ShiftEmployee.Id.Equals(tempShiftID)).FirstOrDefault();
            TemplateShift tShift = tShiftDB.FindTempShiftByID(tempShiftID);
            return tShift;
        }
    }
}
