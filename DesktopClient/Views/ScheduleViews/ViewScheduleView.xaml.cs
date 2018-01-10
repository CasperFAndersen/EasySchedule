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
            LblStart.Visibility = Visibility.Hidden;
            LblEnd.Visibility = Visibility.Hidden;
            TxtStart.Visibility = Visibility.Hidden;
            TxtEnd.Visibility = Visibility.Hidden;
        }

        private async void BindComboBoxData()
        {
            try
            {
                Department department = await departmentProxy.GetDepartmentByIdAsync(MainWindow.Employee.DepartmentId);
                CBoxDepartment.ItemsSource = await departmentProxy.GetAllDepartmentsByWorkplaceIdAsync(department.WorkplaceId);
                CBoxDepartment.DisplayMemberPath = "Name";
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Could net fetch department");
            }
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Schedule schedule = null;
            Department department = (Department)CBoxDepartment.SelectedItem;

            schedule = Mediator.GetInstance().OnCBoxSelectionChanged(department);
            Mediator.GetInstance().OnCBoxSelectionChangedVoid(department);
            SetStartEndTxt(schedule);

            BtnReset.IsEnabled = false;
            BtnSave.IsEnabled = false;

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
            BtnSave.IsEnabled = true;
            BtnReset.IsEnabled = true;
        }

        private void SetStartEndTxt(Schedule schedule)
        {
            if (schedule != null)
            {
                LblStart.Visibility = Visibility.Visible;
                LblEnd.Visibility = Visibility.Visible;
                TxtStart.Visibility = Visibility.Visible;
                TxtEnd.Visibility = Visibility.Visible;
                TxtStart.Text = schedule.StartDate.ToShortDateString();
                TxtEnd.Text = schedule.EndDate.ToShortDateString();
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
            BtnReset.IsEnabled = false;
            BtnSave.IsEnabled = false;
            Mediator.GetInstance().OnResetButtonClicked();
        }
    }
}
