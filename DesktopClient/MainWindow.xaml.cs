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
            SetOnDepartmentSelected();
            //LoadEmployeeList(GetListOfEmployees());
            
        }

        public void LoadEmployeeList(List<Employee> employees)
        {
            EmployeeList.Items.Clear();
            foreach (Employee e in employees)
            {
                EmployeeList.Items.Add(new EmployeeListItem(e));
            }
        }


        public List<Employee> GetListOfEmployees(int departmentIndex)
        {
            Department deparment = departmentList.ElementAt(departmentIndex);
            DepartmentProxy deptProxy = new DepartmentProxy();
            //return deptProxy.GetAllEmployeesByDepartmentID(deparment);
            return null;
        }

        public List<Department> LoadDeparmentList()
        {
            DepartmentProxy deptProxy = new DepartmentProxy();
            return departmentList = deptProxy.GetAllDepartments().ToList();
        }

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int departmentIndexChoice = CBoxDepartment.SelectedIndex;
            GetListOfEmployees(departmentIndexChoice);
        }

        private void BtnSaveTemplateSchedule_Click(object sender, RoutedEventArgs e)
        {
            TemplateSchedule tempSchedule = new TemplateSchedule();

            foreach (TemplateShift ts in Calendar.GetListOfTemplateShifts())
            {
                tempSchedule.ListOfTempShifts.Add(ts);
            }
            tempSchedule.NoOfWeeks = Convert.ToInt32(TxtBoxNoOfWeeks.Text);
            //get this from a textbox / or smth. Ask arne what he ment

            tempSchedule.Name = TxtBoxTemplateScheduleName.Text;
            TempScheduleProxy tsProxy = new TempScheduleProxy();
            tsProxy.AddTempScheduleToDB(tempSchedule);
            MessageBox.Show("Basis planen er blevet gemt!");
        }

        private void TxtBoxNoOfWeeks_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ControlPanel.Children.Clear();
            ControlPanel.Children.Add(new ViewEditTemplateSchedule());
        }

        public void SetOnDepartmentSelected()
        {
            Mediator.GetInstance().DepartmentSelected += (s, e) =>
            {
                          
                EmployeeProxy employeeProxy = new EmployeeProxy();
                LoadEmployeeList(employeeProxy.GetListOfEmployeeByDepartmentId(e.TempSchedule.DepartmentID));

            };
            

        }
    }

    
    
}

