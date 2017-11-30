using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLibrary.Schedule
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        Core.Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date);
        [OperationContract]
        void InsertScheduleIntoDb(Core.Schedule schedule);
        [OperationContract]
        void UpdateSchedule(Core.Schedule schedule);
        [OperationContract]
        List<Core.Schedule> GetSchedulesByDepartmentId(int departmentId);
        [OperationContract]
        Core.Schedule GenerateScheduleFromTemplateScheduleAndStartDate(Core.TemplateSchedule tempSchedule, DateTime startTime);
    }
}