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
        public CreateScheduleView()
        {
            InitializeComponent();
            BindData();
        }

        private async void BindData()
        {
            DepartmentProxy departmentProxy = new DepartmentProxy();
            CBoxDepartment.ItemsSource = await departmentProxy.GetAllDepartmentsAsync();
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department selectedDepartment = (Department)CBoxDepartment.SelectedItem;
            LoadTemplateScheduleList(selectedDepartment.Id);
            BlackOutDatePicker(selectedDepartment.Id);
        }

        private async void LoadTemplateScheduleList(int departmentId)
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

        private void BlackOutDatePicker(int departmentId)
        {
            DatePicker.BlackoutDates.Clear();
            ScheduleProxy scheduleProxy = new ScheduleProxy();

            List<Core.Schedule> schedules = scheduleProxy.GetSchedulesByDepartmentId(departmentId);
            foreach (Core.Schedule s in schedules)
            {
                CalendarDateRange blackOutDates = new CalendarDateRange();
                blackOutDates.Start = s.StartDate;
                blackOutDates.End = s.EndDate;
                DatePicker.BlackoutDates.Add(blackOutDates);
            }
        }

        private void btnGenerateSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate != null && ListTemplateSchedule.SelectedIndex != 1)
            {
                Core.TemplateSchedule templateSchedule = (Core.TemplateSchedule)ListTemplateSchedule.SelectedItem;
                DateTime startTime = (DateTime)DatePicker.SelectedDate;
                Core.Schedule schedule = new ScheduleProxy().GenerateScheduleFromTemplateScheduleAndStartDate(templateSchedule, startTime);
                Mediator.GetInstance().OnGenerateScheduleButtonClicked(schedule);
            }
        }

        private void btnPublishSchedule_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnCreateScheduleButtonClicked();
        }
    }
}
