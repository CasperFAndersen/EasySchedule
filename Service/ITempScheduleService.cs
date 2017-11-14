using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
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
