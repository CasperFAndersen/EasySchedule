using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract]
    public interface ITempShiftService
    {
        [OperationContract]
        TempShift CreateTempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee);

        [OperationContract]
        TempShift FindTempShiftByID(TempSchedule tSchedule, int tempShiftID);
    }
}
