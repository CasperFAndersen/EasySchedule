using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public void OnShiftDropped(object sender, Shift shift, bool isLastElement)
        {
            var shiftDroppedDelegate = ShiftDropped as EventHandler<ShiftDropEventArgs>;
            if (shiftDroppedDelegate != null)
            {
                shiftDroppedDelegate(sender, new ShiftDropEventArgs { Shift = shift, IsLastElement = isLastElement });
            }

        }

        public event EventHandler<ShiftDropEventArgs> ShiftCloseClicked;
        public void OnShiftCloseClick(object sender, Shift shift)
        {
            var shiftCloseDelegate = ShiftCloseClicked as EventHandler<ShiftDropEventArgs>;
            if (shiftCloseDelegate != null)
            {
                shiftCloseDelegate(sender, new ShiftDropEventArgs { Shift = shift });
            }

        }

        public delegate void EmployeeDroppedHandler(Employee employee, TimeSpan timeOfDay, DayOfWeek dayOfWeek); 
        public event EmployeeDroppedHandler EmployeeDropped;
        public void OnEmployeeDropped(Employee employee, TimeSpan timeOfDay, DayOfWeek dayOfWeek)
        {
            if (EmployeeDropped != null)
            {
                EmployeeDropped(employee, timeOfDay, dayOfWeek);
            }

        }

        public event EventHandler<TemplateSelectedArgs> TempScheduleSelected;
        public void OnTemplateScheduleSelected(object sender, TemplateSchedule templateSchedule)
        {
            var templateScheduleSelected = TempScheduleSelected as EventHandler<TemplateSelectedArgs>;
            if (templateScheduleSelected != null)
            {
                templateScheduleSelected(sender, new TemplateSelectedArgs { TempSchedule = templateSchedule });
            }

        }


        public event EventHandler<TemplateSelectedArgs> TempScheduleUpdateClicked;

        public void OnTemplateScheduleUpdateButtonClicked(object sender, TemplateSchedule templateSchedule)
        {
            var tempScheduleUpdateClicked = TempScheduleUpdateClicked as EventHandler<TemplateSelectedArgs>;
            if (tempScheduleUpdateClicked != null)
            {
                tempScheduleUpdateClicked(sender, new TemplateSelectedArgs { TempSchedule = templateSchedule });
            }
        }

        public delegate void DepartmentBoxChangedHandler(List<Employee> employees, Department department);
        public event DepartmentBoxChangedHandler DepartmentBoxChanged;

        public void OnDepartmentBoxSelected(List<Employee> employees, Department department)
        {
            if(DepartmentBoxChanged != null)
            {
                DepartmentBoxChanged(employees, department);
            }
        }

        public delegate void CBoxDepartmentChangedHandler(Department department);
        public event CBoxDepartmentChangedHandler CBoxDepartmentChanged;

        public void OnCBoxSelectionChanged(Department department)
        {
            if (DepartmentBoxChanged != null)
            {
                CBoxDepartmentChanged(department);
            }
        }

        public delegate void CreateTemplateScheduleButtonClickedHandler(TemplateSchedule templateSchedule);
        public event CreateTemplateScheduleButtonClickedHandler CreateTemplateScheduleButtonClicked;

        public void OnCreateTemplateScheduleButtonClicked(TemplateSchedule templateSchedule)
        {
            if(CreateTemplateScheduleButtonClicked != null)
            {
                CreateTemplateScheduleButtonClicked(templateSchedule);
            }
        }

        public delegate void MenuItemChangedHandler();
        public event MenuItemChangedHandler MenuItemChanged;
        public void OnMenuItemChanged()
        {
            if (MenuItemChanged != null)
            {
                MenuItemChanged();
            }
        }

        public delegate void CreateEmployeeClickedHandler();
        public event CreateEmployeeClickedHandler CreateEmployeeClicked;
        internal void OnCreateEmployeeClicked()
        {
            if (CreateEmployeeClicked != null)
            {
                CreateEmployeeClicked();
            }
        }

        public delegate void UpdateEmployeeClickedHandler();
        public event UpdateEmployeeClickedHandler UpdateEmployeeClicked;
        internal void OnUpdateEmployeeClicked()
        {
            if(UpdateEmployeeClicked != null)
            {
                UpdateEmployeeClicked();
            }
        }

        public delegate void NumOfWeekBoxChangedHandler(int numOfWeeks, ComboBox numOfWeeksBox, int prevSelection);
        public event NumOfWeekBoxChangedHandler NumOfWeekBoxChanged;
        public void OnNumOfWeekBoxChanged(int numOfWeeks, ComboBox numOfWeeksBox, int prevSelection)
        {
            if (NumOfWeekBoxChanged != null)
            {
                NumOfWeekBoxChanged(numOfWeeks, numOfWeeksBox, prevSelection);
            }
        }




    }
}
