using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess;
using DatabaseAccess.Schedule;

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
            DateTime res = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day);

            return schRep.GetScheduleByCurrentDate(res);
        }
    }
}
