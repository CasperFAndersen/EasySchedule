using System.Collections.Generic;
using Core;
using System.Data.SqlClient;

namespace DatabaseAccess.TemplateShifts
{
    public interface ITemplateShiftRepository
    {
        void AddTemplateShiftsFromTemplateSchedule(int templateScheduleId, List<TemplateShift> templateShifts);
        void UpdateTemplateScheduleShift(TemplateShift templateShift, SqlConnection connection);
        List<TemplateShift> GetTemplateShiftsByTemplateScheduleId(int templateScheduleId);
        TemplateShift FindTemplateShiftById(int templateShiftId);
    }
}