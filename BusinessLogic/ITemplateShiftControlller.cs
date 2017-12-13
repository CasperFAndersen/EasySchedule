using Core;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ITemplateShiftControlller
    {
        TemplateShift FindTemplateShiftById(int templateShiftId);
        List<TemplateShift> GetTemplateShiftsByTemplateScheduleId(int templateScheduleId);
        void AddTemplateShiftsFromTemplateSchedule(int templateScheduleId, List<TemplateShift> shifts);
    }
}