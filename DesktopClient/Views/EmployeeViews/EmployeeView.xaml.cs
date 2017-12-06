using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.EmployeeViews
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
                catch (ArgumentException)
                {
                    //TODO
                    //har fjernet så den ikke printer exception -> det fik vi at vide at user ikke skulle bruge til noget.
                    MessageBox.Show("Something went wrong while processing your request. Please check input parameters.");
                    
                }
                //ClearEmployeeView();
                
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

        private void txtName_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }
    }
}
