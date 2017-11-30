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
    public class TemplateScheduleController
    {
        TemplateScheduleRepository _templateScheduleRepository = new TemplateScheduleRepository();
        TemplateSchedule tscheduleModel = new TemplateSchedule();

        public TemplateScheduleController()
        {
            
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

        public void AddTempScheduleToDb(TemplateSchedule tSchedule)
        {
            _templateScheduleRepository.AddTempScheduleToDb(tSchedule);
        }
        
        public void AddTempShift(TemplateShift tShift)
        {
            tscheduleModel.ListOfTempShifts.Add(tShift);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            _templateScheduleRepository.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
