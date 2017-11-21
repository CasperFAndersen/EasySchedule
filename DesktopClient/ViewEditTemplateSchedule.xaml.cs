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
using DesktopClient.Services;
using Core;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for ViewEditTemplateSchedule.xaml
    /// </summary>
    public partial class ViewEditTemplateSchedule : UserControl
    {
        TempScheduleProxy tempProxy = new TempScheduleProxy();
        public ViewEditTemplateSchedule()
        {

            InitializeComponent();
            BindData();
        }

        private async void BindData()
        {
            List<TemplateSchedule> tempSchedules = await tempProxy.GetAllTempSchedulesAsync();
            ChooseSchedule.ItemsSource = tempSchedules;
            ChooseSchedule.DisplayMemberPath = "Name";
        }

        private void ChooseSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TemplateSchedule tempSchedule = (TemplateSchedule)ChooseSchedule.SelectedItem;
            int[] weeks = { 1, 2, 3, 4 };
            Weeks.ItemsSource = weeks;
            Weeks.SelectedItem = tempSchedule.NoOfWeeks;
            Mediator.GetInstance().OnDepartmentSelected(sender, tempSchedule);
        }
    }
}
