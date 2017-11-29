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

namespace DesktopClient.Views.Schedule
{
    /// <summary>
    /// Interaction logic for ScheduleCalendarView.xaml
    /// </summary>
    public partial class ScheduleCalendarView : Page
    {
        public ScheduleCalendarView()
        {
            InitializeComponent();
            SetOnCBoxSelectionChanged();
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

        private void SetOnCBoxSelectionChanged()
        {
            Mediator.GetInstance().CBoxDepartmentChanged += (d,s) =>
            {
                List<Employee> employees = new EmployeeProxy().GetListOfEmployeeByDepartmentId(d.Id);
                LoadEmployeeList(employees);
            };
            
        }
    }
}
