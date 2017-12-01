using System.Collections.Generic;
using System.Windows.Controls;
using Core;

namespace DesktopClient.Views.EmployeeViews
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
           // List<Employee> employees = new 
        }
    }
}
