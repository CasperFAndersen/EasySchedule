using System.Windows;
using System.Windows.Controls;
using DesktopClient.Views.EmployeeViews;

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
        }

        private void BtnSaveEmployee_Click(object sender, RoutedEventArgs e)
        { 
                Mediator.GetInstance().OnCreateEmployeeClicked(); 
        }
    }
}
