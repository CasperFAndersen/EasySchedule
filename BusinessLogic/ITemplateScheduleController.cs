using Core;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ITemplateScheduleController
    {
        TemplateSchedule CreateTemplateSchedule(int numberOfWeeks, string name);
        IEnumerable<TemplateSchedule> GetAllTemplateSchedules();
        TemplateSchedule FindTemplateScheduleByName(string name);
        void AddTemplateScheduleToDb(TemplateSchedule templateSchedule);
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule);
    }
}