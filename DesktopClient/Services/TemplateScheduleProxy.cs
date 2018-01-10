using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using DesktopClient.TemplateScheduleService;

namespace DesktopClient.Services
{
    public class TemplateScheduleProxy : ITemplateScheduleService
    {
        private readonly TemplateScheduleServiceClient _templateScheduleServiceClient = new TemplateScheduleServiceClient();

        public void AddTemplateScheduleToDb(TemplateSchedule templateSchedule)
        {
            _templateScheduleServiceClient.AddTemplateScheduleToDb(templateSchedule);
        }

        public Task AddTemplateScheduleToDbAsync(TemplateSchedule templateSchedule)
        {
            return _templateScheduleServiceClient.AddTemplateScheduleToDbAsync(templateSchedule);
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
