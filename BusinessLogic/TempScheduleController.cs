﻿using Core;
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
        TemplateScheduleDB tScheduleDB = new TemplateScheduleDB();
        TemplateSchedule tscheduleModel = new TemplateSchedule();

        public TemplateSchedule CreateTemplateSchedule(int numberOfWeeks, string name)
        {
            return new TemplateSchedule(numberOfWeeks, name);
        }

        public IEnumerable<TemplateSchedule> GetAllTempSchedules()
        {
            return tScheduleDB.GetAll();
        }

        public TemplateSchedule FindTempScheduleByName(string name)
        {
            return tScheduleDB.FindTempScheduleByName(name);
        }

        public void AddTempScheduleToDB(TemplateSchedule tSchedule)
        {
            tScheduleDB.AddTempScheduleToDB(tSchedule);
        }
        
        public void AddTempShift(TemplateShift tShift)
        {
            tscheduleModel.ListOfTempShifts.Add(tShift);
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            tScheduleDB.UpdateTemplateSchedule(templateSchedule);
        }
    }
}
