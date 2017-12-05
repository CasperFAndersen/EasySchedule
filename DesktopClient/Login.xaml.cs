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
            EmployeeProxy employeeService = new EmployeeProxy();

            try
            {
                employee = employeeService.ValidatePassword(TxtUsername.Text, PwBox.Password);

                Mediator.GetInstance().OnLoginButtonClicked(employee);

            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong. Please try again");
            }


        }
    }
}
