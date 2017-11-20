using System;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.TempShift
{
    [ServiceContract]
    public interface ITempShiftService
    {
        [OperationContract]
        TemplateShift CreateTempShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleID, Core.Employee employee);

        [OperationContract]
        TemplateShift FindTempShiftByID(int tempShiftID);
    }
}
