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
    /// Interaction logic for CreateEmployeeView.xaml
    /// </summary>
    public partial class CreateEmployeeView : UserControl
    {
        public CreateEmployeeView()
        {
            InitializeComponent();
            LoadDepartmentList();
        }

        private async void LoadDepartmentList()
        {
            List<Department> departments = await new DepartmentController().GetDepartmentsByLoggedinEmployee();
            CBoxDepartment.ItemsSource = departments;
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private void BtnSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployeeClicked();

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
                    emp.NoOfHours = Convert.ToInt32(TxtNoOfHours.Text);
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
                ClearEmployeeView();
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
