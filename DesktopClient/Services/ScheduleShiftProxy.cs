using DesktopClient.ScheduleShiftService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DesktopClient.Services
{
    public class ScheduleShiftProxy : IScheduleShiftService
    {
        readonly ScheduleShiftServiceClient _scheduleShiftServiceClient = new ScheduleShiftServiceClient();

        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            _scheduleShiftServiceClient.AcceptAvailableShift(shift, employee);
        }

        public Task AcceptAvailableShiftAsync(ScheduleShift shift, Employee employee)
        {
            return _scheduleShiftServiceClient.AcceptAvailableShiftAsync(shift, employee);
        }

        public List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            return _scheduleShiftServiceClient.GetAllAvailableShiftsByDepartmentId(departmentId);
        }

        public Task<List<ScheduleShift>> GetAllAvailableShiftsByDepartmentIdAsync(int departmentId)
        {
            return _scheduleShiftServiceClient.GetAllAvailableShiftsByDepartmentIdAsync(departmentId);
        }

        public void SetScheduleShiftForSale(ScheduleShift scheduleShift)
        {
            _scheduleShiftServiceClient.SetScheduleShiftForSale(scheduleShift);
        }

        public Task SetScheduleShiftForSaleAsync(ScheduleShift scheduleShift)
        {
            return _scheduleShiftServiceClient.SetScheduleShiftForSaleAsync(scheduleShift); ;
        }
    }
}
