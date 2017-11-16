using DesktopClient.TempScheduleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class TempScheduleProxy : ITempScheduleService
    {
        TempScheduleServiceClient proxy = new TempScheduleServiceClient();
        public void AddTempScheduleToDB(TempSchedule tSchedule)
        {
            proxy.AddTempScheduleToDB(tSchedule);
        }

        public Task AddTempScheduleToDBAsync(TempSchedule tSchedule)
        {
           return proxy.AddTempScheduleToDBAsync(tSchedule);
        }

        public void AddTempShift(TempShift tShift)
        {
            proxy.AddTempShift(tShift);
        }

        public Task AddTempShiftAsync(TempShift tShift)
        {
            return proxy.AddTempShiftAsync(tShift);
        }

        public TempSchedule FindTempScheduleByName(string name)
        {
            return proxy.FindTempScheduleByName(name);
        }

        public Task<TempSchedule> FindTempScheduleByNameAsync(string name)
        {
            return proxy.FindTempScheduleByNameAsync(name);
        }

        public TempSchedule[] GetAllTempSchedules()
        {
            return proxy.GetAllTempSchedules();
        }

        public Task<TempSchedule[]> GetAllTempSchedulesAsync()
        {
            return proxy.GetAllTempSchedulesAsync();
        }
    }
}
