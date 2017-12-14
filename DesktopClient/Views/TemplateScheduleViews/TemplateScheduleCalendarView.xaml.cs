using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.TemplateScheduleViews
{
    /// <summary>
    /// Interaction logic for TemplateScheduleCalendar.xaml
    /// </summary>
    public partial class TemplateScheduleCalendarView : Page
    {
        public TemplateScheduleCalendarView()
        {
            InitializeComponent();
            SetOnTemplateScheduleSelected();
            SetOnTemplateScheduleUpdateClicked();
            SetOnDepartmentBoxSelected();
        }

        public void LoadEmployeeList(List<Employee> employees)
        {
            EmployeeList.Items.Clear();
            foreach (Employee e in employees)
            {
                EmployeeList.Items.Add(new Views.EmployeeListItem(e));
            }
            EmployeeList.BorderThickness = new Thickness(1, 1, 1, 1);
        }

        private void SetOnTemplateScheduleUpdateClicked()
        {
            Mediator.GetInstance().TemplateScheduleUpdateClicked += (s, e) =>
            {
                ControlPanel.Content = new ViewEditTemplateSchedule();
                EmployeeList.Items.Clear();
            };
        }
        public void SetOnTemplateScheduleSelected()
        {
            Mediator.GetInstance().TemplateScheduleSelected += (s, e) =>
            {
                try
                {
                    EmployeeProxy employeeProxy = new EmployeeProxy();
                    List<Employee> employees = employeeProxy.GetEmployeesByDepartmentId(e.TemplateSchedule.DepartmentId);
                    LoadEmployeeList(employees);
                }
                catch (Exception)
                {

                    MessageBox.Show("Something went wrong! Could not fetch employees");
                }
            };
        }

        private void SetOnDepartmentBoxSelected()
        {
            Mediator.GetInstance().DepartmentBoxChanged += (d) =>
            {
                LoadEmployeeList(d.Employees);
                DepartmentName.Content = d.Name;
            };
        }
    }
}
