using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.TemplateSchedules;

namespace BusinessLogic
{
    public class TemplateScheduleController : ITemplateScheduleController
    {
        ITemplateScheduleRepository _templateScheduleRepository;
        TemplateSchedule _templateSchedule;

        public TemplateScheduleController()
        {
            _templateSchedule = new TemplateSchedule();
            _templateScheduleRepository = new TemplateScheduleRepository();
        }

        public TemplateSchedule CreateTemplateSchedule(int numberOfWeeks, string name)
        {
            return new TemplateSchedule(numberOfWeeks, name);
        }

        public IEnumerable<TemplateSchedule> GetAllTemplateSchedules()
        {
            return _templateScheduleRepository.GetAllTemplateSchedules();
        }

        public TemplateSchedule FindTemplateScheduleByName(string name)
        {
            return _templateScheduleRepository.GetTemplateScheduleByName(name);
        }

        public void AddTemplateScheduleToDb(TemplateSchedule templateSchedule)
        {
            _templateScheduleRepository.AddTemplateScheduleToDatabase(templateSchedule);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            _templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
