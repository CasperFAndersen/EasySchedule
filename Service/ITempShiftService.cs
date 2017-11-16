using System;
using System.ServiceModel;
using Core;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface ITempShiftService
    {
        [OperationContract]
        TemplateShift CreateTempShift(DayOfWeek weekDay, int hours, TimeSpan startTime, int templateScheduleID, int employeeID);

        [OperationContract]
        TemplateShift FindTempShiftByID(int tempShiftID);
    }
}
