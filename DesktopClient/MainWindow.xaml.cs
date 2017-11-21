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
        private List<Department> departmentList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            LoadDeparmentList();

        }

        public void LoadEmployeeList(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                EmployeeList.Items.Add(new EmployeeListItem(e));
            }
        }


        public void GetListOfEmployees(int departmentIndex)
        {
            int deparmentId = departmentList.ElementAt(departmentIndex).Id;
            EmployeeProxy empProxy = new EmployeeProxy();
            List<Employee> listOfEmployees = new List<Employee>(empProxy.GetListOfEmployeesByDepartmentID(deparmentId).ToList());
            LoadEmployeeList(listOfEmployees);
        }

        public void LoadDeparmentList()
        {
            DepartmentProxy deptProxy = new DepartmentProxy();
            departmentList = deptProxy.GetAllDepartments().ToList();
            CBoxDepartment.ItemsSource = departmentList;
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int departmentIndexChoice = CBoxDepartment.SelectedIndex;
            EmployeeList.Items.Clear();
            GetListOfEmployees(departmentIndexChoice);
        }

        private void BtnSaveTemplateSchedule_Click(object sender, RoutedEventArgs e)
        {
            TemplateSchedule tempSchedule = new TemplateSchedule();

            foreach (TemplateShift ts in Calendar.Shifts)
            {
                tempSchedule.ListOfTempShifts.Add(ts);
            }
            tempSchedule.NoOfWeeks = Convert.ToInt32(TxtBoxNoOfWeeks.Text);

            tempSchedule.Name = TxtBoxTemplateScheduleName.Text;
            tempSchedule.DepartmentID = departmentList.ElementAt(CBoxDepartment.SelectedIndex).Id;
            TempScheduleProxy tsProxy = new TempScheduleProxy();
            tsProxy.AddTempScheduleToDB(tempSchedule);
            MessageBox.Show("Basis planen er blevet gemt!");
        }

        private void TxtBoxNoOfWeeks_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }



}

