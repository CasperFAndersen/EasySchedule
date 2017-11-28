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
    /// Interaction logic for UpdateEmployeeView.xaml
    /// </summary>
    public partial class UpdateEmployeeView : UserControl
    {
        public UpdateEmployeeView()
        {
            InitializeComponent();
            LoadDepartmentList();
            UpdateEmployeeClicked();
        }

        private void BtnUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnUpdateEmployeeClicked();
        }

        private void LoadDepartmentList()
        {
            List<Department> listOfDepartments = new DepartmentEvents().LoadDeparmentList();
            cBoxDepartment.ItemsSource = listOfDepartments;
            cBoxDepartment.DisplayMemberPath = "Name";
        }

        private void LoadEmployeeList(Department department)
        {
            List<Employee> listOfEmployees = new EmployeeEvents().GetListOfEmployees(department);
            EmployeeListBox.ItemsSource = listOfEmployees;
            EmployeeListBox.DisplayMemberPath = "Name";
        }

        public void UpdateEmployeeClicked()
        {
            Mediator.GetInstance().UpdateEmployeeClicked += () =>
            {
                try
                {
                    EmployeeProxy empProxy = new EmployeeProxy();

                    Employee emp = (Employee)EmployeeListBox.SelectedItem;
                    emp.Name = txtName.Text;
                    emp.Mail = txtEmail.Text;
                    emp.Phone = txtPhone.Text;
                    emp.NumbOfHours = Convert.ToInt32(txtNoOfHours.Text);
                    emp.IsAdmin = Convert.ToBoolean(chkIsAdmin.IsChecked);
                    emp.IsEmployed = Convert.ToBoolean(chkIsActive.IsChecked);
                    emp.Username = txtUsername.Text;
                    emp.Password = txtPassword.Text;
                    //Department selectedDepartment = (Department)cBoxDepartment.SelectedItem;
                    //emp.DepartmentId = selectedDepartment.Id;

                    empProxy.UpdateEmployee(emp);
                    
                    MessageBox.Show("An employee was succenfully updated", "Updated Employee");
                }
                catch (Exception e)
                {

                    MessageBox.Show("Something went wrong!", "Error:" + e.Message);

                }
                ClearEmployeeView();
                LoadDepartmentList();
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

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearEmployeeView();
            Department tempDept = (Department)cBoxDepartment.SelectedItem;
            if(tempDept != null)
            {
                LoadEmployeeList(tempDept);
            }
            else
            {
                EmployeeListBox.ItemsSource = null;
            }

        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Employee emp = (Employee)EmployeeListBox.SelectedItem;
            if (emp != null)
            {
                txtName.Text = emp.Name;
                txtEmail.Text = emp.Mail;
                txtPhone.Text = emp.Phone;
                txtNoOfHours.Text = emp.NumbOfHours.ToString();
                chkIsAdmin.IsChecked = emp.IsAdmin;
                chkIsActive.IsChecked = emp.IsEmployed;
                txtUsername.Text = emp.Username;
                txtPassword.Text = emp.Password;
            }
            else
            {
                ClearEmployeeView();
            }
        }
    }
}
