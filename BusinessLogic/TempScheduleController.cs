using Core;
using DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TempScheduleController
    {
        TemplateScheduleRepository _tScheduleRepository = new TemplateScheduleRepository();
        TemplateSchedule tscheduleModel = new TemplateSchedule();

        public TempScheduleController()
        {
            
        }

        public TemplateSchedule CreateTemplateSchedule(int numberOfWeeks, string name)
        {
            return new TemplateSchedule(numberOfWeeks, name);
        }

        public IEnumerable<TemplateSchedule> GetAllTempSchedules()
        {
            return _tScheduleRepository.GetAll();
        }

        public TemplateSchedule FindTempScheduleByName(string name)
        {
            return _tScheduleRepository.FindTempScheduleByName(name);
        }

        public void AddTempScheduleToDb(TemplateSchedule tSchedule)
        {
            _tScheduleRepository.AddTempScheduleToDB(tSchedule);
        }
        
        public void AddTempShift(TemplateShift tShift)
        {
            tscheduleModel.ListOfTempShifts.Add(tShift);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            _tScheduleRepository.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
