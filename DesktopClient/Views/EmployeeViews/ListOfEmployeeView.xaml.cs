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

namespace DesktopClient.Views.EmployeeViews
{
    /// <summary>
    /// Interaction logic for ListOfEmployeeView.xaml
    /// </summary>
    public partial class ListOfEmployeeView : UserControl
    {
        public List<Employee> employeeList { get; set; }

        public ListOfEmployeeView()
        {
            InitializeComponent();
        }



        public void GetListOfEmployeesBasedOnDepartment(int departmentId)
        {
            EmployeeProxy empProxy = new EmployeeProxy();
            List<Employee> employeeList = empProxy.GetEmployeesByDepartmentId(departmentId);
        }
    }
}
