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
        List<Shift> GetShiftsByScheduleID(int scheduleId);
        List<Shift> GetShiftsByEmployeeId(int employeeId);
        Shift BuildShiftObject(SqlDataReader reader);
        
    }
}
