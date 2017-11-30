using System.Collections.Generic;
using Core;

namespace DatabaseAccess.TemplateShifts
{
    public interface ITemplateShiftRepository
    {
        void AddTemplateShiftsFromTemplateSchedule(int templateScheduleId, List<TemplateShift> templateShifts);
        void UpdateTemplateScheduleShift(TemplateShift templateShift);
        List<TemplateShift> GetTemplateShiftsByTemplateScheduleId(int templateScheduleId);
        TemplateShift FindTemplateShiftById(int templateShiftId);
    }
}