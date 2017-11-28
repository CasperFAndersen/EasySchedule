using Core;
using DesktopClient.Services;
using DesktopClient.Views.Schedule;
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

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemplateScheduleCalendarView templateScheduleCalendarView;
        ViewCreateTemplateSchedule viewCreateTemplateSchedule;
        ViewEditTemplateSchedule viewEditTemplateSchedule;
        CreateEmployeeView createEmployeeView;
        UpdateEmployeeView updateEmployeeView;
        ScheduleCalendarView scheduleCalendarView;

        public MainWindow()
        {
            InitializeComponent();
            templateScheduleCalendarView = new TemplateScheduleCalendarView();
            viewCreateTemplateSchedule = new ViewCreateTemplateSchedule();
            viewEditTemplateSchedule = new ViewEditTemplateSchedule();
            createEmployeeView = new CreateEmployeeView();
            updateEmployeeView = new UpdateEmployeeView();
            scheduleCalendarView = new ScheduleCalendarView();
        }

        private void ViewEditTempScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            templateScheduleCalendarView.ControlPanel.Content = viewEditTemplateSchedule;
            templateScheduleCalendarView.Calendar.Clear();
            templateScheduleCalendarView.EmployeeList.Items.Clear();
            frame.Content = templateScheduleCalendarView;
        }

        private void CreateTempScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            templateScheduleCalendarView.Calendar.Clear();
            templateScheduleCalendarView.ControlPanel.Content = viewCreateTemplateSchedule;
            templateScheduleCalendarView.EmployeeList.Items.Clear();
            frame.Content = templateScheduleCalendarView;
        }

        private void ViewScheduleMenuItemClicked(object sender, RoutedEventArgs e)
        {
            frame.Content = scheduleCalendarView;
        }


        private void CreateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            frame.Content = createEmployeeView;
        }

        private void UpdateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            frame.Content = updateEmployeeView;
        }
    }
}

