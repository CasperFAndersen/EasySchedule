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
using DesktopClient.Views;

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
        ViewScheduleView viewScheduleView;
        public static Employee Employee { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            frame.Content = new Login();
            Menu.Visibility = Visibility.Hidden;
            SetOnLoginButtonClicked();
            employeeBox.Visibility = Visibility.Hidden;
        }



        private void LoginSuccess()
        {
            Menu.Visibility = Visibility.Visible;
            frame.Content = null;

            employeeColors = new EmployeeColors();
            templateScheduleCalendarView1 = new TemplateScheduleCalendarView();
            templateScheduleCalendarView2 = new TemplateScheduleCalendarView();
            viewCreateTemplateSchedule = new ViewCreateTemplateSchedule();
            viewEditTemplateSchedule = new ViewEditTemplateSchedule();
            createEmployeeView = new Views.EmployeeViews.CreateEmployeeView();
            updateEmployeeView = new Views.EmployeeViews.UpdateEmployeeView();

            scheduleCalendarViewEdit = new ScheduleCalendarView();
            scheduleCalendarViewEdit.Calendar.SetUpAsViedEditCalendar();

            scheduleCalendarCreate = new ScheduleCalendarView();
            scheduleCalendarCreate.Calendar.SetUpAsCreateCalendar();

            createScheduleView = new CreateScheduleView();
            createEmployeeView = new Views.EmployeeViews.CreateEmployeeView();
            viewScheduleView = new ViewScheduleView();

            frame.Content = new WelcomePage(this);

            SetEmployeeInfo();
        }

        private async void SetEmployeeInfo()
        {
            try
            {
                Department department = await new DepartmentProxy().GetDepartmentByIdAsync(Employee.DepartmentId);
                employeeBox.Visibility = Visibility.Visible;
                txtDepartment.Text = department.Name;
                txtName.Text = Employee.Name;
                txtUserName.Text = Employee.Username;
                txtAdimn.Text = Employee.IsAdmin.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Could net fetch department");
            }
        }

        public void ViewEditTemplateScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            templateScheduleCalendarView2.Calendar.Clear();
            templateScheduleCalendarView1.ControlPanel.Content = viewEditTemplateSchedule;
            viewCreateTemplateSchedule.CBoxDepartment.SelectedIndex = 0;
            templateScheduleCalendarView1.Calendar.Clear();
            templateScheduleCalendarView1.EmployeeList.Items.Clear();
            frame.Content = templateScheduleCalendarView1;
            templateScheduleCalendarView1.Calendar.LoadShiftsIntoCalendar();

            txtViewtitle.Text = "View/Edit Template Schedule";
        }

        public void CreateTemplateScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            templateScheduleCalendarView2.Calendar.Clear();
            templateScheduleCalendarView1.Calendar.Clear();
            templateScheduleCalendarView2.ControlPanel.Content = viewCreateTemplateSchedule;
            templateScheduleCalendarView2.EmployeeList.Items.Clear();
            frame.Content = templateScheduleCalendarView2;
            templateScheduleCalendarView2.Calendar.LoadShiftsIntoCalendar();

            txtViewtitle.Text = "Create Template Schedule";

        }

        public void ViewScheduleMenuItemClicked(object sender, RoutedEventArgs e)
        {
            scheduleCalendarViewEdit.ControlPanel.Content = viewScheduleView;
            scheduleCalendarViewEdit.EmployeeList.Items.Clear();
           // scheduleCalendarViewEdit.Calendar.IsViewScheduleEnabled = true;
           // scheduleCalendarViewEdit.Calendar.SetOnDepartmentSelected();
            frame.Content = scheduleCalendarViewEdit;

            txtViewtitle.Text = "View/Edit Schedule";

        }

        public void CreateScheduleMenuItemClicked(object sender, RoutedEventArgs e)
        {
            scheduleCalendarCreate.ControlPanel.Content = createScheduleView;
            //scheduleCalendarCreate.Calendar.IsViewScheduleEnabled = false;
            //scheduleCalendarCreate.Calendar.SetOnCreateScheduleClicked();
            scheduleCalendarCreate.EmployeeList.Items.Clear();
           // scheduleCalendarCreate.Calendar.SetOnCreateScheduleDepartmentChanged();;
            frame.Content = scheduleCalendarCreate;
            scheduleCalendarCreate.Calendar.Disable();
            txtViewtitle.Text = "Create Schedule";
        }


        public void CreateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            frame.Content = createEmployeeView;

            txtViewtitle.Text = "Create Employee";
        }

        public void UpdateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            frame.Content = updateEmployeeView;

            txtViewtitle.Text = "Update Employee";
        }



        private void SetOnLoginButtonClicked()
        {
            Mediator.GetInstance().LoginButtonClicked += (employee) =>
            {
                if (employee != null)
                {
                    Employee = employee;
                    LoginSuccess();
                }

            };
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new Login();
            MainWindow.Employee = null;
            Menu.Visibility = Visibility.Hidden;
            employeeBox.Visibility = Visibility.Hidden;
            txtViewtitle.Text = "";
        }
    }
}

