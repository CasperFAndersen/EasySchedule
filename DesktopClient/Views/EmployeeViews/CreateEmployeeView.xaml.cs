using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.EmployeeViews
{
    /// <summary>
    /// Interaction logic for CreateEmployeeView.xaml
    /// </summary>
    public partial class CreateEmployeeView : UserControl
    {
        public CreateEmployeeView()
        {
            InitializeComponent();
            LoadDepartmentList();
            CreateEmployeeClicked();
        }

        private void LoadDepartmentList()
        {
            List<Department> departments = new DepartmentEvents().LoadDeparmentList();
            CBoxDepartment.ItemsSource = departments;
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private void BtnSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnCreateEmployeeClicked();
        }

        public void CreateEmployeeClicked()
        {
            Mediator.GetInstance().CreateEmployeeClicked += () =>
            {
                try
                {
                    Employee emp = new Employee();
                    EmployeeProxy empProxy = new EmployeeProxy();

                    emp.Name = TxtName.Text;
                    emp.Mail = TxtEmail.Text;
                    emp.Phone = TxtPhone.Text;
                    emp.NumbOfHours = Convert.ToInt32(TxtNoOfHours.Text);
                    emp.IsAdmin = Convert.ToBoolean(ChkIsAdmin.IsChecked);
                    emp.IsEmployed = Convert.ToBoolean(ChkIsActive.IsChecked);
                    emp.Username = TxtUsername.Text;
                    emp.Password = TxtPassword.Text;
                    Department selectedDepartment = (Department)CBoxDepartment.SelectedItem;
                    emp.DepartmentId = selectedDepartment.Id;

                    empProxy.InsertEmployee(emp);

                    MessageBox.Show("An employee was succesfully saved", "Saved Employee");
                }
                catch (ArgumentException)
                {
                    //TODO
                    //har fjernet så den ikke printer exception -> det fik vi at vide at user ikke skulle bruge til noget.
                    MessageBox.Show("Something went wrong while processing your request. Please check input parameters.");

                }
                // ClearEmployeeView();

            };
        }
    }
}
