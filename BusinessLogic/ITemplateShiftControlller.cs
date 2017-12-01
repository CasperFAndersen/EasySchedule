using Core;

namespace BusinessLogic
{
    public interface ITemplateShiftControlller
    {
        TemplateShift FindTemplateShiftById(int templateShiftId);
    }
}