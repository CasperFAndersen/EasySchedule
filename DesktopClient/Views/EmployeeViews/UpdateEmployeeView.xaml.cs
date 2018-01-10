using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.EmployeeViews
{
    /// <summary>
    /// Interaction logic for UpdateEmployeeView.xaml
    /// </summary>
    public partial class UpdateEmployeeView : UserControl
    {
        EmployeeProxy empProxy;
        DepartmentProxy departmentProxy;
        public UpdateEmployeeView()
        {
            departmentProxy = new DepartmentProxy();
            InitializeComponent();
            LoadDepartmentList();
            UpdateEmployeeClicked();
            empProxy = new EmployeeProxy();
        }

        private void BtnUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
                Mediator.GetInstance().OnUpdateEmployeeClicked();
        }

        private async void LoadDepartmentList()
        {
            try
            {
                Department department = await departmentProxy.GetDepartmentByIdAsync(MainWindow.Employee.DepartmentId);
                List<Department> departments = await departmentProxy.GetAllDepartmentsByWorkplaceIdAsync(department.WorkplaceId);
                CBoxDepartment.ItemsSource = departments;
                CBoxDepartment.DisplayMemberPath = "Name";
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Could net fetch department");
            }
        }

        private void LoadEmployeeList(Department department)
        {
            try
            {
                List<Employee> employees = new List<Employee>(empProxy.GetEmployeesByDepartmentId(department.Id));
                EmployeeListBox.ItemsSource = employees;
                EmployeeListBox.DisplayMemberPath = "Name";
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Could not feth employees");
            }
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
                    emp.Email = TxtEmail.Text;
                    emp.Phone = TxtPhone.Text;
                    emp.NoOfHours = Convert.ToInt32(TxtNoOfHours.Text);
                    emp.IsAdmin = Convert.ToBoolean(ChkIsAdmin.IsChecked);
                    emp.IsEmployed = Convert.ToBoolean(ChkIsActive.IsChecked);
                    emp.Username = TxtUsername.Text;
                    emp.Password = TxtPassword.Password;

                    empProxy.UpdateEmployee(emp);
                    
                    MessageBox.Show("An employee was succenfully updated", "Updated Employee");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while processing your request. Please check input parameters.", "Error:");
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

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                TxtEmail.Text = emp.Email;
                TxtPhone.Text = emp.Phone;
                TxtNoOfHours.Text = emp.NoOfHours.ToString();
                ChkIsAdmin.IsChecked = emp.IsAdmin;
                ChkIsActive.IsChecked = emp.IsEmployed;
                TxtUsername.Text = emp.Username;
                TxtPassword.Password = emp.Password;
            }
            else
            {
                ClearEmployeeView();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
