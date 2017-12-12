using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.ScheduleViews
{
    /// <summary>
    /// Interaction logic for ScheduleCalendarView.xaml
    /// </summary>
    public partial class ScheduleCalendarView : Page
    {
        public ScheduleCalendarView()
        {
            InitializeComponent();
            SetOnCBoxSelectionChanged();
            SetOnCBoxDepartmentCreateViewChanged();
        }

        public void LoadEmployeeList(List<Employee> employees)
        {
            EmployeeList.Items.Clear();
            foreach (Employee e in employees)
            {
                EmployeeList.Items.Add(new EmployeeListItem(e));
            }
            EmployeeList.BorderThickness = new Thickness(1, 1, 1, 1);
        }

        private void SetOnCBoxSelectionChanged()
        {
            Mediator.GetInstance().CBoxDepartmentCreateScheduleChanged += (d) =>
            {
                //List<Employee> employees = new EmployeeProxy().GetEmployeesByDepartmentId(d.Id);
                LoadEmployeeList(d.Employees);
        
            };
            
        }

        private void SetOnCBoxDepartmentCreateViewChanged()
        {
            Mediator.GetInstance().CBoxDepartmentChangedVoid += (d) =>
            {
                LoadEmployeeList(d.Employees);
               
            };


        }
    }
}
