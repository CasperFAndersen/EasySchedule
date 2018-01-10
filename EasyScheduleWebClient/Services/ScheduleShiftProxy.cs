using EasyScheduleWebClient.ScheduleShiftService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using System.Threading.Tasks;

namespace EasyScheduleWebClient.Services
{
    public class ScheduleShiftProxy : IScheduleShiftService
    {
        readonly ScheduleShiftServiceClient _scheduleShiftService = new ScheduleShiftServiceClient();
        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            _scheduleShiftService.AcceptAvailableShift(shift, employee);
        }

        public Task AcceptAvailableShiftAsync(ScheduleShift shift, Employee employee)
        {
            return _scheduleShiftService.AcceptAvailableShiftAsync(shift, employee);
        }

        public List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            return _scheduleShiftService.GetAllAvailableShiftsByDepartmentId(departmentId);
        }

        public Task<List<ScheduleShift>> GetAllAvailableShiftsByDepartmentIdAsync(int departmentId)
        {
            return _scheduleShiftService.GetAllAvailableShiftsByDepartmentIdAsync(departmentId);
        }

        public void SetScheduleShiftForSale(ScheduleShift scheduleShift)
        {
            _scheduleShiftService.SetScheduleShiftForSale(scheduleShift);
        }

        public Task SetScheduleShiftForSaleAsync(ScheduleShift scheduleShift)
        {
            return _scheduleShiftService.SetScheduleShiftForSaleAsync(scheduleShift); ;
        }
    }
}