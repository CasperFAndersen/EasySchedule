using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Core;
using EasyScheduleWebClient.ScheduleService;

namespace EasyScheduleWebClient.Services
{
    public class ScheduleProxy : IScheduleService
    {
        IScheduleService proxy = new ScheduleServiceClient();

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
            throw new NotImplementedException();
        }

        public Task<Schedule> GenerateScheduleFromTemplateScheduleAndStartDateAsync(TemplateSchedule templateSchedule, DateTime startTime)
        {
            throw new NotImplementedException();
        }


        public Task<ScheduleShift[]> GetAllAvailableShiftsByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date)
        {
            return proxy.GetScheduleByDepartmentIdAndDate(departmentId, date);
        }

        public Task<Schedule> GetScheduleByDepartmentIdAndDateAsync(int departmentId, DateTime date)
        {
            throw new NotImplementedException();
        }



        public Task<Schedule[]> GetSchedulesByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }



        public void InsertScheduleToDb(Schedule schedule)
        {
            throw new NotImplementedException();
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

        public Task SetShiftForSaleByIdAsync(int scheduleShiftId)
        {
            throw new NotImplementedException();
        }

        List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            return proxy.GetAllAvailableShiftsByDepartmentId(departmentId);
        }

        List<ScheduleShift> IScheduleService.GetAllAvailableShiftsByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }

        Task<List<ScheduleShift>> IScheduleService.GetAllAvailableShiftsByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        List<Schedule> IScheduleService.GetSchedulesByDepartmentId(int departmentId)
        {
            return proxy.GetSchedulesByDepartmentId(departmentId);
        }

        Task<List<Schedule>> IScheduleService.GetSchedulesByDepartmentIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}