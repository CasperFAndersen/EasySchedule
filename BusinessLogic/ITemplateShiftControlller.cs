using Core;

namespace BusinessLogic
{
    public interface ITemplateShiftControlller
    {
        TemplateShift FindTempShiftById(int tempShiftId);
    }
}