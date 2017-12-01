using Core;
using DesktopClient.Services;
using DesktopClient.Views.ScheduleViews;
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
using DesktopClient.Views.TemplateScheduleViews;
using CreateScheduleView = DesktopClient.Views.ScheduleViews.CreateScheduleView;
using ScheduleCalendarView = DesktopClient.Views.ScheduleViews.ScheduleCalendarView;
using TemplateScheduleCalendarView = DesktopClient.Views.TemplateScheduleViews.TemplateScheduleCalendarView;
using ViewCreateTemplateSchedule = DesktopClient.Views.TemplateScheduleViews.ViewCreateTemplateSchedule;
using ViewEditTemplateSchedule = DesktopClient.Views.TemplateScheduleViews.ViewEditTemplateSchedule;
using ViewScheduleView = DesktopClient.Views.ScheduleViews.ViewScheduleView;

namespace DesktopClient
{
    public partial class MainWindow : Window
    {
        TemplateScheduleCalendarView templateScheduleCalendarView1;
        TemplateScheduleCalendarView templateScheduleCalendarView2;
        ViewCreateTemplateSchedule viewCreateTemplateSchedule;
        ViewEditTemplateSchedule viewEditTemplateSchedule;
        Views.EmployeeViews.CreateEmployeeView createEmployeeView;
        Views.EmployeeViews.UpdateEmployeeView updateEmployeeView;
        ScheduleCalendarView scheduleCalendarViewEdit;
        ScheduleCalendarView scheduleCalendarCreate;
        CreateScheduleView createScheduleView;
        EmployeeColors employeeColors;

        public MainWindow()
        {
            InitializeComponent();
            employeeColors = new EmployeeColors();
            templateScheduleCalendarView1 = new TemplateScheduleCalendarView();
            templateScheduleCalendarView2 = new TemplateScheduleCalendarView();
            viewCreateTemplateSchedule = new ViewCreateTemplateSchedule();
            viewEditTemplateSchedule = new ViewEditTemplateSchedule();
            createEmployeeView = new Views.EmployeeViews.CreateEmployeeView();
            updateEmployeeView = new Views.EmployeeViews.UpdateEmployeeView();
            scheduleCalendarViewEdit = new ScheduleCalendarView();
            scheduleCalendarCreate = new ScheduleCalendarView();
            createScheduleView = new CreateScheduleView();
            createEmployeeView = new Views.EmployeeViews.CreateEmployeeView();
        }

        private void ViewEditTemplateScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            templateScheduleCalendarView2.Calendar.Clear();
            templateScheduleCalendarView1.ControlPanel.Content = viewEditTemplateSchedule;
            viewCreateTemplateSchedule.CBoxDepartment.SelectedIndex = 0;
            templateScheduleCalendarView1.Calendar.Clear();
            templateScheduleCalendarView1.EmployeeList.Items.Clear();
            frame.Content = templateScheduleCalendarView1;
            templateScheduleCalendarView1.Calendar.LoadShiftsIntoCalendar();

            //TemplateScheduleCalendarView tscv = new TemplateScheduleCalendarView();
            //ViewEditTemplateSchedule vets = new ViewEditTemplateSchedule();
            //tscv.ControlPanel.Content = vets;
            //frame.Content = tscv;
        }

        private void CreateTemplateScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            templateScheduleCalendarView2.Calendar.Clear();
            templateScheduleCalendarView1.Calendar.Clear();
            templateScheduleCalendarView2.ControlPanel.Content = viewCreateTemplateSchedule;
            templateScheduleCalendarView2.EmployeeList.Items.Clear();
            frame.Content = templateScheduleCalendarView2;
            templateScheduleCalendarView2.Calendar.LoadShiftsIntoCalendar();

            //TemplateScheduleCalendarView tscv = new TemplateScheduleCalendarView();
            //ViewCreateTemplateSchedule vcts = new ViewCreateTemplateSchedule();
            //tscv.ControlPanel.Content = vcts;
            //frame.Content = tscv;
        }

        private void ViewScheduleMenuItemClicked(object sender, RoutedEventArgs e)
        {
            scheduleCalendarViewEdit.ControlPanel.Content = new ViewScheduleView();
            frame.Content = scheduleCalendarViewEdit;
            
            //ScheduleCalendarView scv = new ScheduleCalendarView();
            //ViewScheduleView vsv = new ViewScheduleView();
            //scv.ControlPanel.Content = vsv;
            //frame.Content = scv;
        }


        private void CreateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            frame.Content = createEmployeeView;
        }

        public void UpdateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            frame.Content = updateEmployeeView;
        }

        private void CreateScheduleMenuItemClicked(object sender, RoutedEventArgs e)
        {
            scheduleCalendarCreate.ControlPanel.Content = createScheduleView;
            scheduleCalendarCreate.Calendar.SetOnCreateScheduleClicked();
            frame.Content = scheduleCalendarCreate;
        }
    }
}

