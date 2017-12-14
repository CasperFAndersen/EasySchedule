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
        ScheduleProxy scheduleProxy;
        DepartmentProxy departmentProxy;
        public ViewScheduleView()
        {
            scheduleProxy = new ScheduleProxy();
            departmentProxy = new DepartmentProxy();
            InitializeComponent();
            BindComboBoxData();
            SetOnNewScheduleActive();
            EventChangesListener();
            HideStartEndTxt();
        }

        private void HideStartEndTxt()
        {
            lblStart.Visibility = Visibility.Hidden;
            lblEnd.Visibility = Visibility.Hidden;
            txtStart.Visibility = Visibility.Hidden;
            txtEnd.Visibility = Visibility.Hidden;
        }

        private async void BindComboBoxData()
        {
            try
            {
                Department department = await departmentProxy.GetDepartmentByIdAsync(MainWindow.Employee.DepartmentId);
                cBoxDepartment.ItemsSource = await departmentProxy.GetAllDepartmentsByWorkplaceIdAsync(department.WorkplaceId);
                cBoxDepartment.DisplayMemberPath = "Name";
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Could net fetch department");
            }
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Schedule schedule = null;
            Department department = (Department)cBoxDepartment.SelectedItem;

            schedule = Mediator.GetInstance().OnCBoxSelectionChanged(department);
            Mediator.GetInstance().OnCBoxSelectionChangedVoid(department);
            SetStartEndTxt(schedule);

            btnReset.IsEnabled = false;
            btnSave.IsEnabled = false;

        }

        private void EventChangesListener()
        {
            Mediator.GetInstance().EmployeeDropped += (e, tod, dow) =>
            {
                EnableSaveAndResetBtn();
            };

            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                EnableSaveAndResetBtn();
            };

            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
            {
                EnableSaveAndResetBtn();
            };
        }

        private void EnableSaveAndResetBtn()
        {
            btnSave.IsEnabled = true;
            btnReset.IsEnabled = true;
        }

        private void SetStartEndTxt(Schedule schedule)
        {
            if (schedule != null)
            {
                lblStart.Visibility = Visibility.Visible;
                lblEnd.Visibility = Visibility.Visible;
                txtStart.Visibility = Visibility.Visible;
                txtEnd.Visibility = Visibility.Visible;
                txtStart.Text = schedule.StartDate.ToShortDateString();
                txtEnd.Text = schedule.EndDate.ToShortDateString();
            }
            else
            {
                HideStartEndTxt();
            }
        }
        private void SetOnNewScheduleActive()
        {
            Mediator.GetInstance().NewScheduleActive += (s) =>
            {
                SetStartEndTxt(s);
            };
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnEditScheduleClicked();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            btnReset.IsEnabled = false;
            btnSave.IsEnabled = false;
            Mediator.GetInstance().OnResetButtonClicked();
        }
    }
}
