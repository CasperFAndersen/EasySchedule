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
        ScheduleShift BuildShiftObject(SqlDataReader reader);

        ScheduleShift GetShiftById(int id);
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);
    }
}
