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
        Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date);

        [OperationContract]
        void InsertScheduleToDb(Schedule schedule);

        [OperationContract]
        void UpdateScheduleWithDelete(Schedule schedule, List<ScheduleShift> deletedScheduleShifts);

        [OperationContract]
        void UpdateSchedule(Schedule schedule);

        [OperationContract]
        List<Schedule> GetSchedulesByDepartmentId(int departmentId);

        [OperationContract]
        Schedule GenerateScheduleFromTemplateScheduleAndStartDate(TemplateSchedule templateSchedule, DateTime startTime);


    }
}