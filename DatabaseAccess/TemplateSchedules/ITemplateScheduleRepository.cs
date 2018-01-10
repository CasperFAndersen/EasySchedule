using Core;
using System;
using System.Collections.Generic;

namespace DatabaseAccess.TemplateSchedules
{
    public interface ITemplateScheduleRepository
    {
        List<TemplateSchedule> GetAllTemplateSchedules();
        int AddTemplateScheduleToDatabase(TemplateSchedule templateSchedule);
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule);
    }
}