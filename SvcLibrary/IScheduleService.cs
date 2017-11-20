using System;
using System.ServiceModel;
using Core;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        Schedule GetScheduleByCurrentDate(DateTime currentDate);

        [OperationContract]
        Schedule GetCurrentScheduleDepartmentId(int depId);
    }
}