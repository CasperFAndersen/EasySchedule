using System;
using System.ServiceModel;
using Core;

namespace Service
{
    [ServiceContract]
    public interface IScheduleService
    {
        [OperationContract]
        Schedule GetScheduleByCurrentDate(DateTime currentDate);
    }
}