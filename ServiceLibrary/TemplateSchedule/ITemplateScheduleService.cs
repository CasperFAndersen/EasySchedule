using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.TemplateSchedule
{
    [ServiceContract]
    public interface ITemplateScheduleService
    {
        [OperationContract]
        IEnumerable<Core.TemplateSchedule> GetAllTempSchedules();

        [OperationContract]
        Core.TemplateSchedule FindTempScheduleByName(string name);

        [OperationContract]
        void AddTempScheduleToDB(Core.TemplateSchedule tSchedule);

        [OperationContract]
        void AddTempShift(Core.TemplateShift tShift);

        [OperationContract]
        void UpdateTemplateSchedule(Core.TemplateSchedule templateSchedule);
    }
}
