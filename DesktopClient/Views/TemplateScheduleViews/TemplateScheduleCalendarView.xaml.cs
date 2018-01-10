using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core;
using DesktopClient.Services;
using DesktopClient.Views.TemplateScheduleViews;

namespace DesktopClient.Views.TemplateScheduleViews
{
    /// <summary>
    /// Interaction logic for TemplateScheduleCalendar.xaml
    /// </summary>
    public partial class TemplateScheduleCalendarView : Page
    {
        public static Dictionary<string, Color> EmployeeColors { get; set; }
        Color[] colors = { Colors.IndianRed, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.Thistle, Colors.SkyBlue, Colors.RoyalBlue, Colors.Turquoise };
        Random rnd = new Random();
        public TemplateScheduleCalendarView()
        {
            InitializeComponent();
            //LoadEmployeeColors();
            SetOnTemplateScheduleSelected();
            SetOnTemplateScheduleUpdateClicked();
            SetOnDepartmentBoxSelected();
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

        private void SetOnTemplateScheduleUpdateClicked()
        {
            Mediator.GetInstance().TemplateScheduleUpdateClicked += (s, e) =>
            {
                ControlPanel.Content = new ViewEditTemplateSchedule();
                EmployeeList.Items.Clear();
            };
        }


        public void SetOnTemplateScheduleSelected()
        {
            Mediator.GetInstance().TemplateScheduleSelected += (s, e) =>
            {
                try
                {
                    EmployeeProxy employeeProxy = new EmployeeProxy();
                    List<Employee> employees = employeeProxy.GetEmployeesByDepartmentId(e.TemplateSchedule.DepartmentId);
                    LoadEmployeeList(employees);
                }
                catch (Exception)
                {

                    MessageBox.Show("Something went wrong! Could not feth employees");
                }
            };
        }

        private void SetOnDepartmentBoxSelected()
        {
            Mediator.GetInstance().DepartmentBoxChanged += (d) =>
            {
                LoadEmployeeList(d.Employees);
                DepartmentName.Content = d.Name;
            };
        }
    }
}
