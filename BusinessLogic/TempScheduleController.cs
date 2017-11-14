using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TempScheduleController
    {
        TempScheduleDB tScheduleDB = new TempScheduleDB();
        TempSchedule tscheduleModel = new TempSchedule();

        public IEnumerable<TempSchedule> GetAllTempSchedules()
        {
            return tScheduleDB.GetAll();
        }

        public TempSchedule FindTempScheduleByName(string name)
        {
            return tScheduleDB.FindTempScheduleByName(name);
        }

        public void AddTempScheduleToDB(TempSchedule tSchedule)
        {
            tScheduleDB.AddTempScheduleToDB(tSchedule);
        }
        
        public void AddTempShift(TempShift tShift)
        {
            tscheduleModel.AddTempShift(tShift);
        }
    }
}
