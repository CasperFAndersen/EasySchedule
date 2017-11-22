using System.Collections.Generic;
using BusinessLogic;
using Core;

namespace ServiceLibrary.TempSchedule
{
    public class TempScheduleService : ITempScheduleService
    {
        TempScheduleController tempScheduleCtrl = new TempScheduleController();
        public void AddTempScheduleToDB(TemplateSchedule tSchedule)
        {
            tempScheduleCtrl.AddTempScheduleToDb(tSchedule);
        }

        public TemplateSchedule FindTempScheduleByName(string name)
        {
            return tempScheduleCtrl.FindTempScheduleByName(name);
        }

        public IEnumerable<TemplateSchedule> GetAllTempSchedules()
        {
           return tempScheduleCtrl.GetAllTempSchedules();
        }
        public void AddTempShift(TemplateShift tShift)
        {
            tempScheduleCtrl.AddTempShift(tShift);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            tempScheduleCtrl.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
