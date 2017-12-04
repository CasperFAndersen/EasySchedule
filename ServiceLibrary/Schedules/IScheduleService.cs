using System;
using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.Schedules
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        Core.Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date);
        [OperationContract]
        void InsertScheduleToDb(Core.Schedule schedule);
        [OperationContract]
        void UpdateSchedule(Core.Schedule schedule);
        [OperationContract]
        List<Core.Schedule> GetSchedulesByDepartmentId(int departmentId);
        [OperationContract]
        Core.Schedule GenerateScheduleFromTemplateScheduleAndStartDate(Core.TemplateSchedule templateSchedule, DateTime startTime);
        [OperationContract]
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);
        [OperationContract]
        List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId);
    }
}