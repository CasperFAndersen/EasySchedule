using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using BusinessLogic;

namespace ServiceLibrary.ScheduleShifts
{
    public class ScheduleShiftService : IScheduleShiftService
    {
        private readonly IScheduleShiftController _scheduleShiftController = new ScheduleShiftController();

        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            _scheduleShiftController.AcceptAvailableShift(shift, employee);
        }

        public IEnumerable<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            return _scheduleShiftController.GetAllAvailableShiftsByDepartmentId(departmentId);
        }

        public void SetScheduleShiftForSale(ScheduleShift scheduleShift)
        {
            _scheduleShiftController.SetScheduleShiftForSale(scheduleShift);
        }
    }
}
