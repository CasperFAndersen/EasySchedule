using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.TemplateScheduleViews
{
    public partial class ViewEditTemplateSchedule : UserControl
    {
        TemplateScheduleProxy _templateProxy = new TemplateScheduleProxy();
        public ViewEditTemplateSchedule()
        {
            InitializeComponent();
            BindData();
            EventChangesListener();
        }

        private async void BindData()
        {
            List<Core.TemplateSchedule> templateSchedules = await _templateProxy.GetAllTemplateSchedulesAsync();
            ChooseSchedule.ItemsSource = templateSchedules;
            ChooseSchedule.DisplayMemberPath = "Name";
        }

        private void ChooseSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Core.TemplateSchedule templateSchedule = (Core.TemplateSchedule)ChooseSchedule.SelectedItem;
            int[] weeks = { 1, 2, 3, 4 };
            Weeks.ItemsSource = weeks;
            Weeks.SelectedItem = templateSchedule.NoOfWeeks;
            Department dep = new DepartmentProxy().GetDepartmentById(templateSchedule.DepartmentId);
            TxtBoxTemplateScheduleName.Text = dep.Name;
            Mediator.GetInstance().OnTemplateScheduleSelected(sender, templateSchedule);
        }

        private void EventChangesListener()
        {
            Mediator.GetInstance().EmployeeDropped += (e, tod, dow) =>
            {
                BtnSaveUpdatedTemplateSchedule.IsEnabled = true;
            };

            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                BtnSaveUpdatedTemplateSchedule.IsEnabled = true;
            };

            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
            {
                BtnSaveUpdatedTemplateSchedule.IsEnabled = true;
            };

            Mediator.GetInstance().CreateTemplateScheduleButtonClicked += (t) =>
            {
                BindData();
            };
        }

        private void BtnSaveUpdatedTemplateSchedule_Click(object sender, RoutedEventArgs e)
        {
            Core.TemplateSchedule templateSchedule = (Core.TemplateSchedule)ChooseSchedule.SelectedItem;
            Mediator.GetInstance().OnTemplateScheduleUpdateButtonClicked(sender, templateSchedule);
            MessageBox.Show("Changes to: " + templateSchedule.Name + " have been saved to database ");
           // BindData();
        }
    }
}
