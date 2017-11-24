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
    /// Interaction logic for CreateEmployeeView.xaml
    /// </summary>
    public partial class CreateEmployeeView : UserControl
    {
        private string Name { get; set; }
        private string Email { get; set; }
        private string Phone { get; set; }
        private int NoOfHOurs { get; set; }
        private bool IsAdmin { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private List<Department> ListOfDepartments { get; set; }


        public CreateEmployeeView()
        {
            InitializeComponent();
            LoadDeparmentList();
        }

        private void LoadDeparmentList()
        {
            List<Department> listOfDepartments = new DepartmentEvents()
        }

        private void btnSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            emp.Name = txtName.Text;
            emp.Mail = txtEmail.Text;
            emp.Phone = txtPhone.Text;
            emp.NumbOfHours = Convert.ToInt32(txtNoOfHours.Text);
            emp.IsAdmin = Convert.ToBoolean(chkIsAdmin.IsChecked);
            emp.Username = txtUsername.Text;
            emp.Password = txtPassword.Text;
            Department selectedDepartment = (Department)cBoxDepartment.SelectedItem;
            emp.DepartmentId = selectedDepartment.Id;
            //TODO Make the client call the service.
        }
    }
}
