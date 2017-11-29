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
    /// Interaction logic for ViewScheduleView.xaml
    /// </summary>
    public partial class ViewScheduleView : Page
    {
        ScheduleProxy scheduleProxy = new ScheduleProxy();
        public ViewScheduleView()
        {
            InitializeComponent();
            BindComboBoxData();
            SetOnNextOrPrevClicked();
        }

        private async void BindComboBoxData()
        {
            List<Department> departments = await new DepartmentProxy().GetAllDepartmentsAsync();
            cBoxDepartment.ItemsSource = departments;
            cBoxDepartment.DisplayMemberPath = "Name";
            
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Core.Schedule schedule = null;
            Department department = (Department)cBoxDepartment.SelectedItem;
            try
            {
                schedule = scheduleProxy.GetScheduleByDepartmentIdAndDate(department.Id, DateTime.Now);
               
                txtNoSchedule.Text = "";
            }
            catch (Exception)
            {
                txtNoSchedule.Text = "There is no schedelue for the selected time period";
            }

            Mediator.GetInstance().OnCBoxSelectionChanged(department, schedule);
        }

        private void SetOnNextOrPrevClicked()
        {
            Mediator.GetInstance().NextOrPrevClicked += (s) =>
            {
                if (s != null)
                {
                    txtNoSchedule.Text = "";
                }
                else
                {
                    txtNoSchedule.Text = "There is no schedelue for the selected time period";
                }
            };
        }

        
    }
}
