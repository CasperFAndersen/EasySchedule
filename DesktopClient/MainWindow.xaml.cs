using Core;
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

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewEditTempScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            TempScheduleMenuItem(new ViewEditTemplateSchedule(), "View / Edit Template Schedule");
            TemplateScheduleCalendarView templateScheduleCalendar = new TemplateScheduleCalendarView();
            templateScheduleCalendar.ControlPanel.Content = new ViewEditTemplateSchedule();
            frame.Content = templateScheduleCalendar;
        }

        private void CreateTempScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            TempScheduleMenuItem(new ViewCreateTemplateSchedule(), "Create Template Schedule");
            TemplateScheduleCalendarView templateScheduleCalendar = new TemplateScheduleCalendarView();
            templateScheduleCalendar.ControlPanel.Content = new ViewCreateTemplateSchedule();
            frame.Content = templateScheduleCalendar;
        }

        private void TempScheduleMenuItem(UserControl view, string title)
        {
            //ControlPanel.Children.Clear();
            //ControlPanel.Children.Add(view);
            //EmployeeList.Items.Clear();
            //DepartmentName.Content = "";
            //LblTitle.Content = title;
            //Mediator.GetInstance().OnMenuItemChanged();
        }

        private void CreateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            //ControlPanel.Children.Clear();
            //ControlPanel.Children.Add(new CreateEmployeeView());
            frame.Content = new CreateEmployeeView();

        }




    }
}

