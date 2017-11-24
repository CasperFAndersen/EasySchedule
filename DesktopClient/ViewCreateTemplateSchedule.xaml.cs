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
            NoOfWeeks.ItemsSource = new int[] {1,2,3,4 };
        }

        public List<Employee> GetListOfEmployees(Department department)
        {
            EmployeeProxy empProxy = new EmployeeProxy();
            List<Employee> listOfEmployees = new List<Employee>(empProxy.GetListOfEmployeeByDepartmentId(department.Id).ToList());
            return listOfEmployees;
        }



        public void LoadDeparmentList()
        {
            List<Department> departmens = new DepartmentEvents().LoadDeparmentList();
            CBoxDepartment.ItemsSource = departmens;
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Employee> employees = GetListOfEmployees((Department)CBoxDepartment.SelectedItem);
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
                tempSchedule.DepartmentID = selectedDep.Id;
                tempSchedule.NoOfWeeks = (int)NoOfWeeks.SelectedItem;
                tempSchedule.Name = TxtBoxTemplateScheduleName.Text;
                Mediator.GetInstance().OnCreateTemplateScheduleButtonClicked(tempSchedule);
            }

        
        }


    }
}
