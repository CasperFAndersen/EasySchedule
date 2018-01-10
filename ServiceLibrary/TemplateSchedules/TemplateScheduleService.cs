using System.Collections.Generic;
using BusinessLogic;
using Core;

namespace ServiceLibrary.TemplateSchedules
{
    public class TemplateScheduleService : ITemplateScheduleService
    {
        private readonly TemplateScheduleController _templateScheduleController = new TemplateScheduleController();

        public void AddTemplateScheduleToDb(TemplateSchedule templateSchedule)
        {
            _templateScheduleController.AddTemplateScheduleToDb(templateSchedule);
        }

        public List<TemplateSchedule> GetAllTemplateSchedules()
        {
            return _templateScheduleController.GetAllTemplateSchedules();
        }

        public void UpdateTemplateScheduleWithDelete(TemplateSchedule templateSchedule, List<TemplateShift> deletedTemplateShifts)
        {
            _templateScheduleController.UpdateTemplateSchedule(templateSchedule, deletedTemplateShifts);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            _templateScheduleController.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
