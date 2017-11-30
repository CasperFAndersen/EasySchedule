using DesktopClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;

namespace DesktopClient.Views.Schedule
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
            cBoxDepartment.ItemsSource = await departmentProxy.GetAllDepartmentsAsync();
            cBoxDepartment.DisplayMemberPath = "Name";
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department selectedDepartment = (Department)cBoxDepartment.SelectedItem;
            LoadTemplateScheduleList(selectedDepartment.Id);
            BlackOutDatePicker(selectedDepartment.Id);
        }

        private async void LoadTemplateScheduleList(int departmentId)
        {
            List<TemplateSchedule> temSchedulesForChoosenDepartment = new List<TemplateSchedule>();
            List<TemplateSchedule> allTempSchedules =await new TempScheduleProxy().GetAllTempSchedulesAsync();
            foreach (TemplateSchedule ts in allTempSchedules)
            {
                if (ts.DepartmentId == departmentId)
                {
                    temSchedulesForChoosenDepartment.Add(ts);
                }
            }
            listTempSchedule.ItemsSource = temSchedulesForChoosenDepartment;
            listTempSchedule.DisplayMemberPath = "Name";
        }

        private void BlackOutDatePicker(int departmentId)
        {
            datePicker.BlackoutDates.Clear();
            ScheduleProxy scheduleProxy = new ScheduleProxy();
           
            List<Core.Schedule> schedules = scheduleProxy.GetSchedulesByDepartmentId(departmentId);
            foreach (Core.Schedule s in schedules) 
            {
                CalendarDateRange blackOutDates = new CalendarDateRange();
                blackOutDates.Start = s.StartDate;
                blackOutDates.End = s.EndDate;
                datePicker.BlackoutDates.Add(blackOutDates);
            }
        }

        private void btnGenerateSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate != null && listTempSchedule.SelectedIndex != 1)
            {
                Core.TemplateSchedule templateSchedule = (Core.TemplateSchedule)listTempSchedule.SelectedItem;
                DateTime startTime = (DateTime)datePicker.SelectedDate;
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
