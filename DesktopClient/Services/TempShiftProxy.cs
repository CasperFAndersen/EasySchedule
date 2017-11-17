using DesktopClient.TempShiftService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DesktopClient.Services
{
    public class TempShiftProxy : ITempShiftService
    {
        TempShiftServiceClient proxy = new TempShiftServiceClient();

        public TemplateShift CreateTempShift(DayOfWeek weekDay, int hours, TimeSpan startTime, int templateScheduleID, Employee employee)
        {
            return proxy.CreateTempShift(weekDay, hours, startTime, templateScheduleID, employee);
        }

        public Task<TemplateShift> CreateTempShiftAsync(DayOfWeek weekDay, int hours, TimeSpan startTime, int templateScheduleID, Employee employee)
        {
            return proxy.CreateTempShiftAsync(weekDay, hours, startTime, templateScheduleID, employee);
        }

        public TemplateShift FindTempShiftByID(int tempShiftID)
        {
            return proxy.FindTempShiftByID(tempShiftID);
        }

        public Task<TemplateShift> FindTempShiftByIDAsync(int tempShiftID)
        {
            return proxy.FindTempShiftByIDAsync(tempShiftID);
        }



    }
}
