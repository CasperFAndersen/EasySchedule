﻿using Core;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IScheduleController
    {
        Schedule GetScheduleByDepartmentIdAndDate(int departmentId, DateTime date);
        void InsertScheduleToDb(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        List<Schedule> GetSchedulesByDepartmentId(int departmentId);
        Schedule GetShiftsFromTemplateShift(TemplateSchedule templateSchedule, DateTime startTime);
        void SetShiftForSale(ScheduleShift shift);
        void AcceptAvailableShift(ScheduleShift shift, Employee employee);
        List<ScheduleShift> GetAllAvailableShiftsByDepartmentId(int departmentId);
    }
}