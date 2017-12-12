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
        private readonly ITemplateScheduleRepository _templateScheduleRepository;
        private readonly ITemplateShiftController _templateShiftController;

        public TemplateScheduleController()
        {
            _templateScheduleRepository = new TemplateScheduleRepository();
            _templateShiftController = new TemplateShiftController();
        }

        public TemplateSchedule CreateTemplateSchedule(int numberOfWeeks, string name)
        {
            return new TemplateSchedule(numberOfWeeks, name);
        }

        public IEnumerable<TemplateSchedule> GetAllTemplateSchedules()
        {
            List<TemplateSchedule> templateSchedules = _templateScheduleRepository.GetAllTemplateSchedules();
            foreach (TemplateSchedule templateSchedule in templateSchedules)
            {
                templateSchedule.TemplateShifts =
                    _templateShiftController.GetTemplateShiftsByTemplateScheduleId(templateSchedule.Id);
            }
            return templateSchedules;
        }

        public TemplateSchedule GetTemplateScheduleByName(string name)
        {
            TemplateSchedule templateSchedule = _templateScheduleRepository.GetTemplateScheduleByName(name);
            templateSchedule.TemplateShifts = _templateShiftController.GetTemplateShiftsByTemplateScheduleId(templateSchedule.Id);
            return templateSchedule;
        }

        public void AddTemplateScheduleToDb(TemplateSchedule templateSchedule)
        {
            int id = _templateScheduleRepository.AddTemplateScheduleToDatabase(templateSchedule);
            _templateShiftController.AddTemplateShiftsFromTemplateSchedule(id, templateSchedule.TemplateShifts);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            _templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);
            _templateShiftController.AddTemplateShiftsFromTemplateSchedule(templateSchedule.Id, templateSchedule.TemplateShifts);
        }
    }
}
