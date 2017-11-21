using DesktopClient.TempScheduleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DesktopClient
{
    public class TempScheduleProxy : ITempScheduleService
    {
        TempScheduleServiceClient proxy = new TempScheduleServiceClient();

        public void AddTempScheduleToDB(TemplateSchedule tSchedule)
        {
            proxy.AddTempScheduleToDB(tSchedule);
        }

        public Task AddTempScheduleToDBAsync(TemplateSchedule tSchedule)
        {
            return proxy.AddTempScheduleToDBAsync(tSchedule);
        }

        public void AddTempShift(TemplateShift tShift)
        {
            proxy.AddTempShift(tShift);
        }

        public Task AddTempShiftAsync(TemplateShift tShift)
        {
            return proxy.AddTempShiftAsync(tShift);
        }

        public TemplateSchedule FindTempScheduleByName(string name)
        {
            return proxy.FindTempScheduleByName(name);
        }

        public Task<TemplateSchedule> FindTempScheduleByNameAsync(string name)
        {
            return proxy.FindTempScheduleByNameAsync(name);
        }


        public List<TemplateSchedule> GetAllTempSchedules()
        {
            return proxy.GetAllTempSchedules();
        }

        public Task<List<TemplateSchedule>> GetAllTempSchedulesAsync()
        {
            return proxy.GetAllTempSchedulesAsync();
        }
    }
}
