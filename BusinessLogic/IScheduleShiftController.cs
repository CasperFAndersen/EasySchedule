using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IScheduleShiftController
    {
        
        List<ScheduleShift> GetShiftsByScheduleId(int scheduleId);
        void AddShiftsFromSchedule(Schedule schedule);
        List<ScheduleShift> GenerateShiftsFromTemplateSchedule(TemplateSchedule templateSchedule, DateTime startTime);
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);
        List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId);
        void SetScheduleShiftForSale(ScheduleShift scheduleShift);
        void DeleteScheduleShift(ScheduleShift scheduleShift);
    }
}
