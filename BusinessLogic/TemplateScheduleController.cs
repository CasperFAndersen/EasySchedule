using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.TemplateSchedule;

namespace BusinessLogic
{
    public class TemplateScheduleController : ITemplateScheduleController
    {
        TemplateScheduleRepository _templateScheduleRepository;
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

        public IEnumerable<TemplateSchedule> GetAllTempSchedules()
        {
            return _templateScheduleRepository.GetAll();
        }

        public TemplateSchedule FindTempScheduleByName(string name)
        {
            return _templateScheduleRepository.FindTempScheduleByName(name);
        }

        public void AddTempScheduleToDb(TemplateSchedule templateSchedule)
        {
            _templateScheduleRepository.AddTempScheduleToDb(templateSchedule);
        }

        public void AddTempShift(TemplateShift templateShift)
        {
            _templateSchedule.ListOfTempShifts.Add(templateShift);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            _templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
