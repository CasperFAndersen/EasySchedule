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
           // LoadDeparmentList();
            SetOnDepartmentSelected();
            SetOnTemplateScheduleUpdateClicked();
            SetOnDepartmentBoxSelected();
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

        public void GetListOfEmployees(int departmentIndex)
        {
            int deparmentId = departmentList.ElementAt(departmentIndex).Id;
            EmployeeProxy empProxy = new EmployeeProxy();
            List<Employee> listOfEmployees = new List<Employee>(empProxy.GetListOfEmployeeByDepartmentId(deparmentId).ToList());
            LoadEmployeeList(listOfEmployees);
        }





  

        //private void BtnSaveTemplateSchedule_Click(object sender, RoutedEventArgs e)
        //{
        //    TemplateSchedule tempSchedule = new TemplateSchedule();

        //    foreach (TemplateShift ts in Calendar.Shifts)
        //    {
        //        tempSchedule.ListOfTempShifts.Add(ts);
        //    }
        //    tempSchedule.NoOfWeeks = Convert.ToInt32(TxtBoxNoOfWeeks.Text);

        //    tempSchedule.Name = TxtBoxTemplateScheduleName.Text;
        //    tempSchedule.DepartmentID = departmentList.ElementAt(CBoxDepartment.SelectedIndex).Id;
        //    TempScheduleProxy tsProxy = new TempScheduleProxy();
        //    tsProxy.AddTempScheduleToDB(tempSchedule);
        //    MessageBox.Show("Basis planen er blevet gemt!");
        //}

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
            Mediator.GetInstance().DepartmentBoxChanged += (e) =>
            {
                LoadEmployeeList(e);
            };
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ControlPanel.Children.Clear();
            ControlPanel.Children.Add(new ViewCreateTemplateSchedule());
        }
    }

    
    
}

