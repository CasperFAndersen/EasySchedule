using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class Mediator
    {
        private static Mediator instance;

        private Mediator()
        {

        }

        public static Mediator GetInstance()
        {
            if(instance == null)
            {
                instance = new Mediator();
            }

            return instance;
        }

        public event EventHandler<ShiftDropEventArgs> ShiftDropped;

        public void OnShiftDropped(object sender, TemplateShift shift, bool isLastElement)
        {
            var shiftDroppedDelegate = ShiftDropped as EventHandler<ShiftDropEventArgs>;
            if (shiftDroppedDelegate != null)
            {
                shiftDroppedDelegate(sender, new ShiftDropEventArgs {Shift = shift, IsLastElement = isLastElement});
            }

        }

        public event EventHandler<ShiftDropEventArgs> ShiftCloseClicked;
        public void OnShiftCloseClick(object sender, TemplateShift shift)
        {
            var shiftCloseDelegate = ShiftCloseClicked as EventHandler<ShiftDropEventArgs>;
            if (shiftCloseDelegate != null)
            {
                shiftCloseDelegate(sender, new ShiftDropEventArgs { Shift = shift });
            }

        }

        public event EventHandler<ShiftDropEventArgs> EmployeeDropped;
        public void OnEmployeeDropped(object sender, TemplateShift shift)
        {
            var employeeDroppedDelegate = EmployeeDropped as EventHandler<ShiftDropEventArgs>;
            if (employeeDroppedDelegate != null)
            {
                employeeDroppedDelegate(sender, new ShiftDropEventArgs { Shift = shift });
            }

        }

        public event EventHandler<TemplateSelectedArgs> TempScheduleSelected;
        public void OnTemplateScheduleSelected(object sender, TemplateSchedule tempSchedule)
        {
            var templateScheduleSelected = TempScheduleSelected as EventHandler<TemplateSelectedArgs>;
            if (templateScheduleSelected != null)
            {
                templateScheduleSelected(sender, new TemplateSelectedArgs { TempSchedule = tempSchedule});
            }

        }



    }
}
