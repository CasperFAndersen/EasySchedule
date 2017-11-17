using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Schedules;

namespace BusinessLogic
{
    public class ScheduleController
    {
        IScheduleRepository schRep = new MockScheduleRep();
        public ScheduleController()
        {

        }

        public Schedule GetScheduleByCurrentDate(DateTime currentDate)
        {
            int day = (int)DayOfWeek.Monday;
            DateTime date = new DateTime(currentDate.Year, currentDate.Month, day);
            
            return schRep.GetScheduleByCurrentDate(date);
        }

    }
}
