using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.ScheduleService;

namespace DesktopClient.Services
{
    public class ScheduleProxy : IScheduleService
    {
        ScheduleServiceClient proxy = new ScheduleServiceClient();

        public void AcceptAvailableShift(ScheduleShift shift, Employee employee)
        {
            proxy.AcceptAvailableShift(shift, employee);
        }

        public Task AcceptAvailableShiftAsync(ScheduleShift shift, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Schedule GenerateScheduleFromTemplateScheduleAndStartDate(TemplateSchedule templateSchedule, DateTime startTime)
        {
            return proxy.GenerateScheduleFromTemplateScheduleAndStartDate(templateSchedule, startTime);
        }

        public Task<Schedule> GenerateScheduleFromTemplateScheduleAndStartDateAsync(TemplateSchedule templateSchedule, DateTime startTime)
        {
            return proxy.GenerateScheduleFromTemplateScheduleAndStartDateAsync(templateSchedule, startTime);
        }

        public List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScheduleShift>> GetAllAvailableShiftsByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public Task<Schedule> GetScheduleByDepartmentIdAndDateAsync(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDateAsync(departmentId, date);
        }

        public List<Schedule> GetSchedulesByDepartmentId(int departmentId)
        {
            return proxy.GetSchedulesByDepartmentId(departmentId);
        }

        public Task<List<Schedule>> GetSchedulesByDepartmentIdAsync(int departmentId)
        {
            return proxy.GetSchedulesByDepartmentIdAsync(departmentId);
        }

        public void InsertScheduleToDb(Schedule schedule)
        {
            proxy.InsertScheduleToDb(schedule);
        }

        public Task InsertScheduleToDbAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            proxy.UpdateSchedule(schedule);
        }

        public Task UpdateScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void SetShiftForSaleById(int scheduleShiftId)
        {
            proxy.SetShiftForSaleById(scheduleShiftId);
        }
    }
}
