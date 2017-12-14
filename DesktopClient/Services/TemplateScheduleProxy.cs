using DesktopClient.TemplateScheduleService;
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
        private readonly TemplateScheduleServiceClient _templateScheduleServiceClient = new TemplateScheduleServiceClient();

        public void AddTemplateScheduleToDb(TemplateSchedule tSchedule)
        {
            _templateScheduleServiceClient.AddTemplateScheduleToDb(tSchedule);
        }

        public Task AddTemplateScheduleToDbAsync(TemplateSchedule tSchedule)
        {
            return _templateScheduleServiceClient.AddTemplateScheduleToDbAsync(tSchedule);
        }

        public TemplateSchedule FindTemplateScheduleByName(string name)
        {
            return _templateScheduleServiceClient.FindTemplateScheduleByName(name);
        }

        public Task<TemplateSchedule> FindTemplateScheduleByNameAsync(string name)
        {
            return _templateScheduleServiceClient.FindTemplateScheduleByNameAsync(name);
        }

        public List<TemplateSchedule> GetAllTemplateSchedules()
        {
            return _templateScheduleServiceClient.GetAllTemplateSchedules();
        }

        public Task<List<TemplateSchedule>> GetAllTemplateSchedulesAsync()
        {
            return _templateScheduleServiceClient.GetAllTemplateSchedulesAsync();
        }

        public void UpdateTemplateSchedule(TemplateSchedule templateSchedule)
        {
            _templateScheduleServiceClient.UpdateTemplateSchedule(templateSchedule);
        }

        public Task UpdateTemplateScheduleAsync(TemplateSchedule templateSchedule)
        {
            return _templateScheduleServiceClient.UpdateTemplateScheduleAsync(templateSchedule);
        }

        public void UpdateTemplateScheduleWithDelete(TemplateSchedule templateSchedule, List<TemplateShift> deletedTemplateShifts)
        {
            _templateScheduleServiceClient.UpdateTemplateScheduleWithDelete(templateSchedule, deletedTemplateShifts);
        }

        public Task UpdateTemplateScheduleWithDeleteAsync(TemplateSchedule templateSchedule, List<TemplateShift> deletedTemplateShifts)
        {
            return _templateScheduleServiceClient.UpdateTemplateScheduleWithDeleteAsync(templateSchedule, deletedTemplateShifts);
        }
    }
}
