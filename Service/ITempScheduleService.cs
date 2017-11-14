using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary
{
    [ServiceContract]
   public interface ITempScheduleService
    {
        [OperationContract]
        IEnumerable<TempSchedule> GetAllTempSchedules();

        [OperationContract]
        TempSchedule FindTempScheduleByName(string name);

        [OperationContract]
        void AddTempScheduleToDB(TempSchedule tSchedule);

        [OperationContract]
        void AddTempShift(TempShift tShift);
    }
}
