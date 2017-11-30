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
            Mediator.GetInstance().CBoxDepartmentChanged += (d,s) =>
            {
                List<Employee> employees = new EmployeeProxy().GetEmployeesByDepartmentId(d.Id);
                LoadEmployeeList(employees);
            };
            
        }
    }
}
