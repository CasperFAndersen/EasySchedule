using Core;
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
    /// Interaction logic for ManageEmployeeView.xaml
    /// </summary>
    public partial class ManageEmployeeView : UserControl
    {
        public ManageEmployeeView()
        {
            InitializeComponent();
            LoadDepartmentList();

        }

        public void LoadDepartmentList()
        {
            List<Department> departments = new DepartmentEvents().LoadDeparmentList();
            CbDepartment.ItemsSource = departments;
            CbDepartment.DisplayMemberPath = "Name";
        }

        private void CbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Employee> employees = new 
        }
    }
}
