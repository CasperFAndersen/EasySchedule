using System;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.TemplateShifts
{
    [ServiceContract]
    public interface ITemplateShiftService
    {
        [OperationContract]
        TemplateShift CreateTemplateShift(DayOfWeek weekDay, double hours, TimeSpan startTime, int templateScheduleId, Employee employee);

        [OperationContract]
        TemplateShift FindTemplateShiftById(int templateShiftId);
    }
}
