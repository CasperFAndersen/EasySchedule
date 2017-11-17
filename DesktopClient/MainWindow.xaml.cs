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

            LoadEmployeeList(GetListOfEmployees());
           // LoadDeparmentList();
        }

        public void LoadEmployeeList(List<Employee> employees)
        {
            foreach (Employee e in employees)
            {
                EmployeeList.Items.Add(new EmployeeListItem(e));
            }
        }


        public List<Employee> GetListOfEmployees()
        {
            List<Employee> emps = new List<Employee>();
            Employee e = new Employee() { Name = "Fro", };
            Employee e2 = new Employee() { Name = "Arne", };

            emps.Add(e);
            emps.Add(e2);

            return emps;
        }

        //public List<Department> LoadDeparmentList()
        //{
        //    DepartmentProxy deptProxy = new DepartmentProxy();
        //    List<Department> departmentList = deptProxy.GetAllDepartments();
        //}

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //CBoxDepartment.selec
        }

        private void BtnSaveTemplateSchedule_Click(object sender, RoutedEventArgs e)
        {

        }

    }

    
    
}

