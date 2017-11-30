using System;
using System.ServiceModel;

namespace ServiceLibrary.TemplateShift
{
    [ServiceContract]
    public interface ITempShiftService
    {
        [OperationContract]
        Core.TemplateShift CreateTempShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Core.Employee employee);

        [OperationContract]
        Core.TemplateShift FindTempShiftById(int tempShiftId);
    }
}
