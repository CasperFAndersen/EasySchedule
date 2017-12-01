using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.ScheduleViews
{
    /// <summary>
    /// Interaction logic for ViewScheduleView.xaml
    /// </summary>
    public partial class ViewScheduleView : Page
    {
        ScheduleProxy scheduleProxy = new ScheduleProxy();
        public ViewScheduleView()
        {
            InitializeComponent();
            BindComboBoxData();
            SetOnNextOrPrevClicked();
            EventChangesListener();
        }

        private async void BindComboBoxData()
        {
            List<Department> departments = await new DepartmentProxy().GetAllDepartmentsAsync();
            cBoxDepartment.ItemsSource = departments;
            cBoxDepartment.DisplayMemberPath = "Name";
            
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Core.Schedule schedule = null;
            Department department = (Department)cBoxDepartment.SelectedItem;
            try
            {
                schedule = scheduleProxy.GetScheduleByDepartmentIdAndDate(department.Id, DateTime.Now);
               
                txtNoSchedule.Text = "";
            }
            catch (Exception)
            {
                txtNoSchedule.Text = "There is no schedelue for the selected time period";
            }

            Mediator.GetInstance().OnCBoxSelectionChanged(department, schedule);
        }

        private void SetOnNextOrPrevClicked()
        {
            Mediator.GetInstance().NextOrPrevClicked += (s) =>
            {
                if (s != null)
                {
                    txtNoSchedule.Text = "";
                }
                else
                {
                    txtNoSchedule.Text = "There is no schedelue for the selected time period";
                }
            };
        }

        private void EventChangesListener()
        {
            Mediator.GetInstance().EmployeeDropped += (e, tod, dow) =>
            {
                btnSave.IsEnabled = true;
            };

            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                btnSave.IsEnabled = true;
            };

            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
            {
                btnSave.IsEnabled = true;
            };

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnEditScheduleClicked();
        }
    }
}
