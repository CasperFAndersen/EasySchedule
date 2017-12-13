using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;
using DesktopClient.Views.EmployeeViews;

namespace DesktopClient.Views.ScheduleViews
{
    /// <summary>
    /// Interaction logic for CreateScheduleView.xaml
    /// </summary>
    public partial class CreateScheduleView : Page
    {
        DepartmentProxy departmentProxy;
        public CreateScheduleView()
        {
            departmentProxy = new DepartmentProxy();
            InitializeComponent();
            BtnGenerateSchedule.IsEnabled = false;
            BtnPublishSchedule.IsEnabled = false;
            BindData();
            
        }

        private async void BindData()
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

        private void ActivateButtons()
        {
            Department selectedDepartment = (Department)CBoxDepartment.SelectedItem;
            if (CBoxDepartment.SelectedIndex != 1 && DatePicker.SelectedDate != null)
            {
                BtnGenerateSchedule.IsEnabled = true;
                BtnPublishSchedule.IsEnabled = false;
            }
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department selectedDepartment = (Department)CBoxDepartment.SelectedItem;
            Mediator.GetInstance().OnCBoxDepartmentCreateScheduleChanged(selectedDepartment);
            LoadTemplateScheduleList(selectedDepartment.Id);
            BlackOutDatePicker(selectedDepartment.Id);
            BtnGenerateSchedule.IsEnabled = false;
            BtnPublishSchedule.IsEnabled = false;
        }

        private async void LoadTemplateScheduleList(int departmentId)
        {
            try
            {
                List<TemplateSchedule> templateSchedulesForDepartment = new List<TemplateSchedule>();
                List<TemplateSchedule> allTemplateSchedules = await new TemplateScheduleProxy().GetAllTemplateSchedulesAsync();
                foreach (TemplateSchedule templateSchedule in allTemplateSchedules)
                {
                    if (templateSchedule.DepartmentId == departmentId)
                    {
                        templateSchedulesForDepartment.Add(templateSchedule);
                    }
                }
                ListTemplateSchedule.ItemsSource = templateSchedulesForDepartment;
                ListTemplateSchedule.DisplayMemberPath = "Name";
            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong! Could not fetch templateschedules");
            }

        }

        private void BlackOutDatePicker(int departmentId)
        {
            DatePicker.BlackoutDates.Clear();
            DatePicker.SelectedDate = null;
            ScheduleProxy scheduleProxy = new ScheduleProxy();

            try
            {
                List<Core.Schedule> schedules = scheduleProxy.GetSchedulesByDepartmentId(departmentId);
                foreach (Core.Schedule s in schedules)
                {
                    CalendarDateRange blackOutDates = new CalendarDateRange();
                    blackOutDates.Start = s.StartDate;
                    blackOutDates.End = s.EndDate;
                    DatePicker.BlackoutDates.Add(blackOutDates);
                }
            }
            catch (Exception)
            {

                
            }

        }

        private void btnGenerateSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate != null && ListTemplateSchedule.SelectedIndex != -1)
            {
                try
                {
                    Core.TemplateSchedule templateSchedule = (Core.TemplateSchedule)ListTemplateSchedule.SelectedItem;
                    DateTime startTime = (DateTime)DatePicker.SelectedDate;
                    Core.Schedule schedule = new ScheduleProxy().GenerateScheduleFromTemplateScheduleAndStartDate(templateSchedule, startTime);
                    Mediator.GetInstance().OnGenerateScheduleButtonClicked(schedule);
                    BtnPublishSchedule.IsEnabled = true;
                }
                catch (Exception)
                {

                    MessageBox.Show("Could not generate Schedule! Please check all parameters and try again");
                }

            }
            else
            {
                MessageBox.Show("Please select both, department, templateschedule and start date");
            }
        }

        private void btnPublishSchedule_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnCreateScheduleButtonClicked();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate != null)
            {
                DateTime date = (DateTime)DatePicker.SelectedDate;
                date = (date.DayOfWeek == DayOfWeek.Sunday) ? (date.AddDays(-6)) : (date.AddDays(-(int)date.DayOfWeek + 1));
                if (!DatePicker.BlackoutDates.Contains(date))
                {
                    DatePicker.SelectedDate = date;
                }
                ActivateButtons();
            }

        }
    }
}
