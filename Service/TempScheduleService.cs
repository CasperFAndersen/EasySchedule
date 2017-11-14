using System.Collections.Generic;
using BusinessLogic;
using Core;

namespace ServiceLibrary
{
    public class TempScheduleService : ITempScheduleService
    {
        TempScheduleController tempScheduleCtrl = new TempScheduleController();
        public void AddTempScheduleToDB(TempSchedule tSchedule)
        {
            tempScheduleCtrl.AddTempScheduleToDB(tSchedule);
        }

        public TempSchedule FindTempScheduleByName(string name)
        {
            return tempScheduleCtrl.FindTempScheduleByName(name);
        }

        public IEnumerable<TempSchedule> GetAllTempSchedules()
        {
           return tempScheduleCtrl.GetAllTempSchedules();
        }
        public void AddTempShift(TempShift tShift)
        {
            tempScheduleCtrl.AddTempShift(tShift);
        }
    }
}
