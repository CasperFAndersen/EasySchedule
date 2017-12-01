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
        TemplateShiftServiceClient proxy = new TemplateShiftServiceClient();

        public TemplateShift CreateTemplateShift(TemplateShiftService.DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return proxy.CreateTemplateShift(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public Task<TemplateShift> CreateTemplateShiftAsync(TemplateShiftService.DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee)
        {
            return proxy.CreateTemplateShiftAsync(weekDay, hours, startTime, templateScheduleId, employee);
        }

        public TemplateShift FindTemplateShiftById(int templateShiftId)
        {
            return proxy.FindTemplateShiftById(templateShiftId);
        }

        public Task<TemplateShift> FindTemplateShiftByIdAsync(int templateShiftId)
        {
            return proxy.FindTemplateShiftByIdAsync(templateShiftId);
        }



    }
}
