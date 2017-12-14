using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.TemplateShiftService;

namespace DesktopClient.Services
{
    public class TemplateShiftProxy : ITemplateShiftService
    {
        private readonly TemplateShiftServiceClient _templateShiftServiceClient = new TemplateShiftServiceClient();

        public TemplateShift CreateTemplateShift(TemplateShiftService.DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return _templateShiftServiceClient.CreateTemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public Task<TemplateShift> CreateTemplateShiftAsync(TemplateShiftService.DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return _templateShiftServiceClient.CreateTemplateShiftAsync(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            return _templateShiftServiceClient.FindTemplateShiftById(templateShiftId);
        }

        public Task<TemplateShift> FindTemplateShiftByIdAsync(int templateShiftId)
        {
            return _templateShiftServiceClient.FindTemplateShiftByIdAsync(templateShiftId);
        }

    }
}
