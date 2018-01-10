using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using System.ServiceModel;

namespace ServiceLibrary.ScheduleShifts
{
    [ServiceContract]
    public interface IScheduleShiftService
    {
        [OperationContract]
        void SetScheduleShiftForSale(ScheduleShift scheduleShift);

        [OperationContract]
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);

        [OperationContract]
        IEnumerable<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId);
    }
}
