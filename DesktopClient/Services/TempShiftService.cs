using DesktopClient.TempShiftService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Services
{
    public class TempShiftService : ITempShiftService
    {
        TempShiftServiceClient proxy = new TempShiftServiceClient();
        public TempShift CreateTempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            return proxy.CreateTempShift(weekNumber, hours, startTime, shiftEmployee);
        }

        public Task<TempShift> CreateTempShiftAsync(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee)
        {
            return proxy.CreateTempShiftAsync(weekNumber, hours, startTime, shiftEmployee);
        }

        public TempShift FindTempShiftByID(TempSchedule tSchedule, int tempShiftID)
        {
            return proxy.FindTempShiftByID(tSchedule, tempShiftID);
        }

        public Task<TempShift> FindTempShiftByIDAsync(TempSchedule tSchedule, int tempShiftID)
        {
            return proxy.FindTempShiftByIDAsync(tSchedule, tempShiftID);
        }
    }
}
