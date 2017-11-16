using System;
using System.ServiceModel;
using Core;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface ITempShiftService
    {
        [OperationContract]
        TemplateShift CreateTempShift(DateTime weekNumber, int hours, DateTime startTime, Employee shiftEmployee);

        [OperationContract]
        TemplateShift FindTempShiftByID(TemplateSchedule tSchedule, int tempShiftID);
    }
}
