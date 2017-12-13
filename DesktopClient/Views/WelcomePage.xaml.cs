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

namespace DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public MainWindow MainWindow { get; set; }
        public WelcomePage(MainWindow mainWindow)
        {
            InitializeComponent();
            SetWelcomeText();
            MainWindow = mainWindow;
        }

        private void SetWelcomeText()
        {
            string welcome = String.Format("Welcome {0}!", MainWindow.Employee.Name);
            txtWelcome.Text = welcome;
            
        }

        private void btnViewEditTemp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ViewEditTemplateScheduleMenuItimClicked(sender, e);
        }

        private void btnCreateTemp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CreateTemplateScheduleMenuItimClicked(sender, e);
        }

        private void btnViewEditSchedule_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ViewScheduleMenuItemClicked(sender ,e);
        }

        private void btnCreateSchedule_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CreateScheduleMenuItemClicked(sender, e);
        }

        private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.CreateEmployeeMenuItemClicked(sender, e);
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.UpdateEmployeeMenuItemClicked(sender, e);
        }
    }
}
