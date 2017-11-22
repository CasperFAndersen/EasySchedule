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
        private List<Department> departmentList { get; set; }
        public ViewCreateTemplateSchedule()
        {
            InitializeComponent();
        }

        //public void LoadDeparmentList()
        //{
        //    DepartmentProxy deptProxy = new DepartmentProxy();
        //    departmentList = deptProxy.GetAllDepartments().ToList();
        //    CBoxDepartment.ItemsSource = departmentList;
        //    CBoxDepartment.DisplayMemberPath = "Name";
        //}

        //public List<Employee> GetListOfEmployees(int departmentIndex)
        //{
        //    Department deparment = departmentList.ElementAt(departmentIndex);
        //    DepartmentProxy deptProxy = new DepartmentProxy();
        //    //return deptProxy.GetAllEmployeesByDepartmentID(deparment);
        //    return null;
        //}
    }
}
