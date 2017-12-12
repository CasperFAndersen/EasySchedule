using Core;
using System;
using System.Collections.Generic;

namespace DatabaseAccess.TemplateSchedules
{
    public interface ITemplateScheduleRepository
    {
        IEnumerable<TemplateSchedule> GetAllTemplateSchedules();
        void AddTemplateScheduleToDatabase(TemplateSchedule templateSchedule);
        TemplateSchedule GetTemplateScheduleByName(string scheduleName);
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule);
    }
}