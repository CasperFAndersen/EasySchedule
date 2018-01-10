using Core;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ITemplateScheduleController
    {
        TemplateSchedule CreateTemplateSchedule(int numberOfWeeks, string name);
        List<TemplateSchedule> GetAllTemplateSchedules();
        void AddTemplateScheduleToDb(TemplateSchedule templateSchedule);
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule);
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule, List<TemplateShift> deletedTemplateShifts);
    }
}