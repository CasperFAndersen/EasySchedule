using System;
using System.Windows;
using Core;
using DesktopClient.Services;
using CreateScheduleView = DesktopClient.Views.ScheduleViews.CreateScheduleView;
using ScheduleCalendarView = DesktopClient.Views.ScheduleViews.ScheduleCalendarView;
using TemplateScheduleCalendarView = DesktopClient.Views.TemplateScheduleViews.TemplateScheduleCalendarView;
using ViewCreateTemplateSchedule = DesktopClient.Views.TemplateScheduleViews.ViewCreateTemplateSchedule;
using ViewEditTemplateSchedule = DesktopClient.Views.TemplateScheduleViews.ViewEditTemplateSchedule;
using ViewScheduleView = DesktopClient.Views.ScheduleViews.ViewScheduleView;

namespace DesktopClient.Views
{
    public partial class MainWindow : Window
    {
        TemplateScheduleCalendarView templateScheduleCalendarView1;
        TemplateScheduleCalendarView templateScheduleCalendarView2;
        ViewCreateTemplateSchedule viewCreateTemplateSchedule;
        ViewEditTemplateSchedule viewEditTemplateSchedule;
        EmployeeViews.CreateEmployeeView createEmployeeView;
        EmployeeViews.UpdateEmployeeView updateEmployeeView;
        ScheduleCalendarView scheduleCalendarViewEdit;
        ScheduleCalendarView scheduleCalendarCreate;
        CreateScheduleView createScheduleView;
        ViewScheduleView viewScheduleView;
        public static Employee Employee { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Frame.Content = new Login();
            Menu.Visibility = Visibility.Hidden;
            SetOnLoginButtonClicked();
            employeeBox.Visibility = Visibility.Hidden;
        }

        private void LoginSuccess()
        {
            Menu.Visibility = Visibility.Visible;
            Frame.Content = null;

            templateScheduleCalendarView1 = new TemplateScheduleCalendarView();
            templateScheduleCalendarView2 = new TemplateScheduleCalendarView();
            viewCreateTemplateSchedule = new ViewCreateTemplateSchedule();
            viewEditTemplateSchedule = new ViewEditTemplateSchedule();
            createEmployeeView = new EmployeeViews.CreateEmployeeView();
            updateEmployeeView = new EmployeeViews.UpdateEmployeeView();

            scheduleCalendarViewEdit = new ScheduleCalendarView();
            scheduleCalendarViewEdit.Calendar.SetUpAsViedEditCalendar();

            scheduleCalendarCreate = new ScheduleCalendarView();
            scheduleCalendarCreate.Calendar.SetUpAsCreateCalendar();

            createScheduleView = new CreateScheduleView();
            createEmployeeView = new EmployeeViews.CreateEmployeeView();
            viewScheduleView = new ViewScheduleView();

            Frame.Content = new WelcomePage(this);

            SetEmployeeInfo();
        }

        private async void SetEmployeeInfo()
        {
            try
            {
                Department department = await new DepartmentProxy().GetDepartmentByIdAsync(Employee.DepartmentId);
                employeeBox.Visibility = Visibility.Visible;
                TxtDepartment.Text = department.Name;
                TxtName.Text = Employee.Name;
                TxtUserName.Text = Employee.Username;
                TxtAdmin.Text = Employee.IsAdmin.ToString();
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
            Frame.Content = templateScheduleCalendarView1;
            templateScheduleCalendarView1.Calendar.LoadShiftsIntoCalendar();

            TxtViewTitle.Text = "View/Edit Template Schedule";
        }

        public void CreateTemplateScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            templateScheduleCalendarView2.Calendar.Clear();
            templateScheduleCalendarView1.Calendar.Clear();
            templateScheduleCalendarView2.ControlPanel.Content = viewCreateTemplateSchedule;
            templateScheduleCalendarView2.EmployeeList.Items.Clear();
            Frame.Content = templateScheduleCalendarView2;
            templateScheduleCalendarView2.Calendar.LoadShiftsIntoCalendar();

            TxtViewTitle.Text = "Create Template Schedule";
        }

        public void ViewScheduleMenuItemClicked(object sender, RoutedEventArgs e)
        {
            scheduleCalendarViewEdit.ControlPanel.Content = viewScheduleView;
            scheduleCalendarViewEdit.EmployeeList.Items.Clear();
            Frame.Content = scheduleCalendarViewEdit;

            TxtViewTitle.Text = "View/Edit Schedule";
        }

        public void CreateScheduleMenuItemClicked(object sender, RoutedEventArgs e)
        {
            scheduleCalendarCreate.ControlPanel.Content = createScheduleView;
            scheduleCalendarCreate.EmployeeList.Items.Clear();
            Frame.Content = scheduleCalendarCreate;
            scheduleCalendarCreate.Calendar.Disable();
            TxtViewTitle.Text = "Create Schedule";
        }


        public void CreateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            Frame.Content = createEmployeeView;
            TxtViewTitle.Text = "Create Employee";
        }

        public void UpdateEmployeeMenuItemClicked(object sender, RoutedEventArgs e)
        {
            Frame.Content = updateEmployeeView;
            TxtViewTitle.Text = "Update Employee";
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

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new Login();
            Employee = null;
            Menu.Visibility = Visibility.Hidden;
            employeeBox.Visibility = Visibility.Hidden;
            TxtViewTitle.Text = "";
            Mediator.ResetMediator();
            SetOnLoginButtonClicked();
        }
    }
}
