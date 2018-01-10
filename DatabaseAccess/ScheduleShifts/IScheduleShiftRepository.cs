using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.ScheduleShifts
{
    public interface IScheduleShiftRepository
    {
        void AddShiftsFromSchedule(Schedule schedule);
        IEnumerable<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId);
        ScheduleShift GetShiftById(int id);
        List<ScheduleShift> GetShiftsByScheduleId(int scheduleId);
        List<ScheduleShift> GetShiftsByEmployeeId(int employeeId);
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);
        void SetScheduleShiftForSale(ScheduleShift scheduleShift);
        void DeleteScheduleShift(ScheduleShift scheduleShift);
    }
}
