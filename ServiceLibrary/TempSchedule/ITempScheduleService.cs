using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.TempSchedule
{
    [ServiceContract]
   public interface ITempScheduleService
    {
        [OperationContract]
        IEnumerable<TemplateSchedule> GetAllTempSchedules();

        [OperationContract]
        TemplateSchedule FindTempScheduleByName(string name);

        [OperationContract]
        void AddTempScheduleToDB(TemplateSchedule tSchedule);

        [OperationContract]
        void AddTempShift(TemplateShift tShift);

        [OperationContract]
        void UpdateTemplateSchedule(TemplateSchedule templateSchedule);
    }
}
