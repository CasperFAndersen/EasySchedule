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
        ScheduleShiftServiceClient proxy = new ScheduleShiftServiceClient();

        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            proxy.AcceptAvailableShift(shift, employee);
        }

        public Task AcceptAvailableShiftAsync(ScheduleShift shift, Employee employee)
        {
            return proxy.AcceptAvailableShiftAsync(shift, employee);
        }

        public List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            return proxy.GetAllAvailableShiftsByDepartmentId(departmentId);
        }

        public Task<List<ScheduleShift>> GetAllAvailableShiftsByDepartmentIdAsync(int departmentId)
        {
            return proxy.GetAllAvailableShiftsByDepartmentIdAsync(departmentId);
        }

        public void SetScheduleShiftForSale(ScheduleShift scheduleShift)
        {
            proxy.SetScheduleShiftForSale(scheduleShift);
        }

        public Task SetScheduleShiftForSaleAsync(ScheduleShift scheduleShift)
        {
            return proxy.SetScheduleShiftForSaleAsync(scheduleShift); ;
        }
    }
}
