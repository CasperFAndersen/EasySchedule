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
        public TemplateShift CreateTempShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleID, Employee employee)
        {
            return new TemplateShift(weekDay, hours, startTime, templateScheduleID, employee);
        }

        public TemplateShift FindTempShiftByID(int tempShiftID)
        {
            TemplateShiftRepository tShiftRepository = new TemplateShiftRepository();
            //TemplateShift tShift = tSchedule.ListOfTempShifts.Where(x => x.ShiftEmployee.Id.Equals(tempShiftID)).FirstOrDefault();
            TemplateShift tShift = tShiftRepository.FindTempShiftById(tempShiftID);
            return tShift;
        }
    }
}
