using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DatabaseAccess.Shifts
{
    public interface IShiftRepository
    {
        List<ScheduleShift> GetShiftsByScheduleId(int scheduleId);
        List<ScheduleShift> GetShiftsByEmployeeId(int employeeId);
        void InsertShifts(List<ScheduleShift> shifts, int scheduleId, SqlConnection connection);
        void AddShiftsFromSchedule(Schedule schedule);
        void UpdateScheduleShift(ScheduleShift shift, int scheduleId, SqlConnection connection);
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);
        ScheduleShift BuildShiftObject(SqlDataReader reader);
        List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId);
        ScheduleShift GetShiftById(int id);

    }
}
