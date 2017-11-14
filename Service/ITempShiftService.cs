using System;
using System.ServiceModel;
using Core;

namespace ServiceLibrary
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
