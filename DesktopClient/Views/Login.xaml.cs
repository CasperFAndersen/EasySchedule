using System;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = null;
            EmployeeProxy employeeProxy = new EmployeeProxy();

            try
            {
                employee = employeeProxy.ValidatePassword(TxtUsername.Text, PwBox.Password);
                if (employee != null && employee.IsAdmin)
                {
                    Mediator.GetInstance().OnLoginButtonClicked(employee);
                }
                else
                {
                    ShowErrorMessage();
                }
            }
            catch (Exception)
            {
                ShowErrorMessage();
            }
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("Something went wrong with the login information. Please try again");
            TxtUsername.Text = "";
            PwBox.Password = "";
        }
    }
}
