using System;
using System.ServiceModel;

namespace ServiceLibrary.Schedule
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        Core.Schedule GetScheduleByCurrentDate(DateTime currentDate);

        [OperationContract]
        Core.Schedule GetCurrentScheduleDepartmentId(int depId);

        [OperationContract]
        void InsertScheduleIntoDb(Core.Schedule schedule);

        [OperationContract]
        void UpdateSchedule(Core.Schedule schedule, int id);


    }
}