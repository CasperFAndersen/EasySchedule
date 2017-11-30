using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.EmployeeViews
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
            CBoxDepartment.ItemsSource = listOfDepartments;
            CBoxDepartment.DisplayMemberPath = "Name";
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
                    emp.Name = TxtName.Text;
                    emp.Mail = TxtEmail.Text;
                    emp.Phone = TxtPhone.Text;
                    emp.NumbOfHours = Convert.ToInt32(TxtNoOfHours.Text);
                    emp.IsAdmin = Convert.ToBoolean(ChkIsAdmin.IsChecked);
                    emp.IsEmployed = Convert.ToBoolean(ChkIsActive.IsChecked);
                    emp.Username = TxtUsername.Text;
                    emp.Password = TxtPassword.Text;
                    //Department selectedDepartment = (Department)CBoxDepartment.SelectedItem;
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
            TxtName.Clear();
            TxtEmail.Clear();
            TxtPhone.Clear();
            TxtNoOfHours.Clear();
            ChkIsAdmin.IsChecked = false;
            ChkIsActive.IsChecked = true;
            TxtUsername.Clear();
            TxtPassword.Clear();
        }

        private void cBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearEmployeeView();
            Department tempDept = (Department)CBoxDepartment.SelectedItem;
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
                TxtName.Text = emp.Name;
                TxtEmail.Text = emp.Mail;
                TxtPhone.Text = emp.Phone;
                TxtNoOfHours.Text = emp.NumbOfHours.ToString();
                ChkIsAdmin.IsChecked = emp.IsAdmin;
                ChkIsActive.IsChecked = emp.IsEmployed;
                TxtUsername.Text = emp.Username;
                TxtPassword.Text = emp.Password;
            }
            else
            {
                ClearEmployeeView();
            }
        }
    }
}
