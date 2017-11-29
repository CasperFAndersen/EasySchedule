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

namespace DesktopClient.Views.Schedule
{
    /// <summary>
    /// Interaction logic for ViewScheduleView.xaml
    /// </summary>
    public partial class ViewScheduleView : Page
    {
        public ViewScheduleView()
        {
            InitializeComponent();
            BindComboBoxData();
        }

        private async void BindComboBoxData()
        {
            List<Department> departments = await new DepartmentProxy().GetAllDepartmentsAsync();
            cBoxDepartment.ItemsSource = departments;
            cBoxDepartment.DisplayMemberPath = "Name";
            
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mediator.GetInstance().OnCBoxSelectionChanged((Department)cBoxDepartment.SelectedItem);
        }
    }
}
