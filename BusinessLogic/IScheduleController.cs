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
        Schedule GenerateScheduleFromTemplateSchedule(TemplateSchedule templateSchedule, DateTime startTime);
 
    }
}