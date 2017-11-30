using Core;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ITemplateScheduleController
    {
        TemplateSchedule CreateTemplateSchedule(int numberOfWeeks, string name);
        IEnumerable<TemplateSchedule> GetAllTempSchedules();
        TemplateSchedule FindTempScheduleByName(string name);
        void AddTempScheduleToDb(TemplateSchedule templateSchedule);
        void AddTempShift(TemplateShift templateShift);
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule);
    }
}