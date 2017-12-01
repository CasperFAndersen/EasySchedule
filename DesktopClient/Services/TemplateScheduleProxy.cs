﻿using DesktopClient.TemplateScheduleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DesktopClient
{
    public class TemplateScheduleProxy : ITemplateScheduleService
    {
        TemplateScheduleServiceClient proxy = new TemplateScheduleServiceClient();

        public void AddTemplateScheduleToDb(TemplateSchedule tSchedule)
        {
            proxy.AddTemplateScheduleToDb(tSchedule);
        }

        public Task AddTemplateScheduleToDbAsync(TemplateSchedule tSchedule)
        {
            return proxy.AddTemplateScheduleToDbAsync(tSchedule);
        }

        public void AddTemplateShift(TemplateShift templateShift)
        {
            proxy.AddTemplateShift(templateShift);
        }

        public Task AddTemplateShiftAsync(TemplateShift templateShift)
        {
            return proxy.AddTemplateShiftAsync(templateShift);
        }

        public TemplateSchedule FindTemplateScheduleByName(string name)
        {
            return proxy.FindTemplateScheduleByName(name);
        }

        public Task<TemplateSchedule> FindTemplateScheduleByNameAsync(string name)
        {
            return proxy.FindTemplateScheduleByNameAsync(name);
        }


        public List<TemplateSchedule> GetAllTemplateSchedules()
        {
            return proxy.GetAllTemplateSchedules();
        }

        public Task<List<TemplateSchedule>> GetAllTemplateSchedulesAsync()
        {
            return proxy.GetAllTemplateSchedulesAsync();
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            proxy.UpdateTemplateSchedule(templateSchedule);
        }

        public Task UpdateTemplateScheduleAsync(TemplateSchedule templateSchedule)
        {
            throw new NotImplementedException();
        }
    }
}