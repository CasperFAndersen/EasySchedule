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
    /// Interaction logic for ViewCreateTemplateSchedule.xaml
    /// </summary>
    public partial class ViewCreateTemplateSchedule : UserControl
    {
        private List<Department> DepartmentList { get; set; }
        public ViewCreateTemplateSchedule()
        {
            InitializeComponent();
            LoadDeparmentList();
            NoOfWeeks.ItemsSource = new int[] { 1, 2, 3, 4 };
        }

        public void LoadDeparmentList()
        {
            List<Department> departmens = new DepartmentEvents().LoadDeparmentList();
            CBoxDepartment.ItemsSource = departmens;
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Employee> employees = new EmployeeEvents().GetListOfEmployees((Department)CBoxDepartment.SelectedItem);
            Mediator.GetInstance().OnDepartmentBoxSelected(employees, (Department)CBoxDepartment.SelectedItem);
        }

        private void BtnSaveTemplateSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxTemplateScheduleName.Text.Length == 0)
            {
                MessageBox.Show("Please enter name");
            }
            else if (NoOfWeeks.SelectedItem == null)
            {
                MessageBox.Show("Please choose number of weeks!");
            }
            else
            {
                TemplateSchedule tempSchedule = new TemplateSchedule();
                Department selectedDep = (Department)CBoxDepartment.SelectedItem;
                tempSchedule.DepartmentId = selectedDep.Id;
                tempSchedule.NoOfWeeks = (int)NoOfWeeks.SelectedItem;
                tempSchedule.Name = TxtBoxTemplateScheduleName.Text;
                Mediator.GetInstance().OnCreateTemplateScheduleButtonClicked(tempSchedule);
            }


        }

        private void NoOfWeeks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int prevSelection = -1;
            if (e.RemovedItems.Count != 0)
            {
                prevSelection = (int)e.RemovedItems[0];
            }
            
            Mediator.GetInstance().OnNumOfWeekBoxChanged((int)NoOfWeeks.SelectedItem, NoOfWeeks, prevSelection);
        }
    }
}
