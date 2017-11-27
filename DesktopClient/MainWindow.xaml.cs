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
        public bool VisibilityConverter { get; set; }

        Color[] colors = { Colors.IndianRed, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.Thistle, Colors.SkyBlue, Colors.RoyalBlue, Colors.Turquoise };
        public static Dictionary<string, Color> EmployeeColors { get; set; }
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            SetOnDepartmentSelected();
            SetOnTemplateScheduleUpdateClicked();
            SetOnDepartmentBoxSelected();
            LoadEmployeeColors();
        }

        private async void LoadEmployeeColors()
        {
            EmployeeColors = new Dictionary<string, Color>();
            List<Employee> employees = await new EmployeeProxy().GetAllEmployeesAsync();
            foreach (var emp in employees)
            {
                EmployeeColors.Add(emp.Name, Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));

            };
        }

        public void LoadEmployeeList(List<Employee> employees)
        {
            EmployeeList.Items.Clear();
            foreach (Employee e in employees)
            {
                EmployeeList.Items.Add(new EmployeeListItem(e));
            }
            EmployeeList.BorderThickness = new Thickness(1, 1, 1, 1);
        }

        public Color GetRandomColor()
        {
            Color color = colors[rnd.Next(colors.Length)];
            bool isUniqeColorFound = false;
            while (!isUniqeColorFound)
            {
                if (!EmployeeColors.Values.Contains(color))
                {
                    isUniqeColorFound = true;
                }
                else
                {
                    color = colors[rnd.Next(colors.Length)];
                }
            }
            return color;
        }

        private void ViewEditTempScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            TempScheduleMenuItem(new ViewEditTemplateSchedule(), "View / Edit Template Schedule");
        }

        private void CreateTempScheduleMenuItimClicked(object sender, RoutedEventArgs e)
        {
            TempScheduleMenuItem(new ViewCreateTemplateSchedule(), "Create Template Schedule");
        }

        private void TempScheduleMenuItem(UserControl view, string title)
        {
            ControlPanel.Children.Clear();
            ControlPanel.Children.Add(view);
            EmployeeList.Items.Clear();
            DepartmentName.Content = "";
            LblTitle.Content = title;
            Mediator.GetInstance().OnMenuItemChanged();
        }

        private void ManageEmployeesMenuItemClicked(object sender, RoutedEventArgs e)
        {
            ControlPanel.Children.Clear();
            ControlPanel.Children.Add(new ManageEmployeeView());
            EmployeeList.Items.Clear();
            DepartmentName.Content = "";
            LblTitle.Content = "Manage Employees";
            Mediator.GetInstance().OnMenuItemChanged();
        }

        public void SetOnDepartmentSelected()
        {
            Mediator.GetInstance().TempScheduleSelected += (s, e) =>
            {
                EmployeeProxy employeeProxy = new EmployeeProxy();
                LoadEmployeeList(employeeProxy.GetListOfEmployeeByDepartmentId(e.TempSchedule.DepartmentID));

            };
        }

        private void SetOnTemplateScheduleUpdateClicked()
        {
            Mediator.GetInstance().TempScheduleUpdateClicked += (s, e) =>
            {
                ControlPanel.Children.Clear();
                ControlPanel.Children.Add(new ViewEditTemplateSchedule());
                EmployeeList.Items.Clear();
            };
        }

        private void SetOnDepartmentBoxSelected()
        {
            Mediator.GetInstance().DepartmentBoxChanged += (e, d) =>
            {
                LoadEmployeeList(e);
                DepartmentName.Content = d.Name;
            };
        }

    }
}

