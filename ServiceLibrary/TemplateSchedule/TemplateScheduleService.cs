using System.Collections.Generic;
using BusinessLogic;
using Core;

namespace ServiceLibrary.TemplateSchedule
{
    public class TemplateScheduleService : ITemplateScheduleService
    {
        TemplateScheduleController tempScheduleCtrl = new TemplateScheduleController();
        public void AddTempScheduleToDB(Core.TemplateSchedule tSchedule)
        {
            tempScheduleCtrl.AddTempScheduleToDb(tSchedule);
        }

        public Core.TemplateSchedule FindTempScheduleByName(string name)
        {
            return tempScheduleCtrl.FindTempScheduleByName(name);
        }

        public IEnumerable<Core.TemplateSchedule> GetAllTempSchedules()
        {
            return tempScheduleCtrl.GetAllTempSchedules();
        }
        public void AddTempShift(Core.TemplateShift tShift)
        {
            tempScheduleCtrl.AddTempShift(tShift);
        }

        public void UpdateTemplateSchedule(Core.TemplateSchedule templateSchedule)
        {
            tempScheduleCtrl.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
