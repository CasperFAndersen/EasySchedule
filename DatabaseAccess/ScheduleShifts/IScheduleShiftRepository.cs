using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.ScheduleShifts
{
    public interface IScheduleShiftRepository
    {
        List<ScheduleShift> GetShiftsByScheduleId(int scheduleId);
        List<ScheduleShift> GetShiftsByEmployeeId(int employeeId);
        void AddShiftsFromSchedule(Schedule schedule);
        void UpdateScheduleShift(ScheduleShift shift, int scheduleId, SqlConnection connection);
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);
        ScheduleShift BuildShiftObject(SqlDataReader reader);
        List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId);
        ScheduleShift GetShiftById(int id);
        void SetScheduleShiftForSale(ScheduleShift scheduleShift);
        void DeleteScheduleShift(ScheduleShift scheduleShift);
    }
}
