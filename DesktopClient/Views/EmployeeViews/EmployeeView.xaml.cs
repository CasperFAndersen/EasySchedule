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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
            LoadDepartmentList();
            CreateEmployeeClicked();

        }

        private void LoadDepartmentList()
        {
            List<Department> listOfDepartments = new DepartmentEvents().LoadDeparmentList();
            cBoxDepartment.ItemsSource = listOfDepartments;
            cBoxDepartment.DisplayMemberPath = "Name";
        }

        public void CreateEmployeeClicked()
        {
            Mediator.GetInstance().CreateEmployeeClicked += () =>
            {
                try
                {
                    Employee emp = new Employee();
                    EmployeeProxy empProxy = new EmployeeProxy();

                    emp.Name = txtName.Text;
                    emp.Mail = txtEmail.Text;
                    emp.Phone = txtPhone.Text;
                    emp.NumbOfHours = Convert.ToInt32(txtNoOfHours.Text);
                    emp.IsAdmin = Convert.ToBoolean(chkIsAdmin.IsChecked);
                    emp.IsEmployed = Convert.ToBoolean(chkIsActive.IsChecked);
                    emp.Username = txtUsername.Text;
                    emp.Password = txtPassword.Text;
                    Department selectedDepartment = (Department)cBoxDepartment.SelectedItem;
                    emp.DepartmentId = selectedDepartment.Id;

                    empProxy.InsertEmployee(emp);

                    MessageBox.Show("An employee was succenfully saved", "Saved Employee");
                }
                catch (Exception e)
                {

                    MessageBox.Show("Something went wrong!", "Error:" + e.Message);
                    
                }
                ClearEmployeeView();
                
            };
        }

        

        public void ClearEmployeeView()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtNoOfHours.Clear();
            chkIsAdmin.IsChecked = false;
            chkIsActive.IsChecked = true;
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
