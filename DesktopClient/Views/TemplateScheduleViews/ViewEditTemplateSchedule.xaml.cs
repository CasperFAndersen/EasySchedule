using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.TemplateScheduleViews
{
    public partial class ViewEditTemplateSchedule : UserControl
    {
        public List<TemplateSchedule> TemplateSchedules  { get; set; }
        TemplateScheduleProxy _templateProxy;
        DepartmentProxy _departmentProxy;
        public ViewEditTemplateSchedule()
        {
            InitializeComponent();
            TemplateSchedules = new List<TemplateSchedule>();
            _departmentProxy = new DepartmentProxy();
            _templateProxy = new TemplateScheduleProxy();
            BindDataDepartmentcBox();
            EventChangesListener();
            BtnSaveUpdatedTemplateSchedule.IsEnabled = false;
        }

        private async void BindDataDepartmentcBox()
        {
            Department department = _departmentProxy.GetDepartmentById(MainWindow.Employee.DepartmentId);
            CBoxDepartment.ItemsSource = await _departmentProxy.GetAllDepartmentsByWorkplaceIdAsync(department.WorkplaceId);
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private async void BindDataTempScheduleCBox()
        {
            Department department = (Department)CBoxDepartment.SelectedItem;
            if (department != null)
            {
                List<TemplateSchedule> templateSchedules = await _templateProxy.GetAllTemplateSchedulesAsync();
                templateSchedules = templateSchedules.FindAll(x => x.DepartmentId == department.Id);
                CBoxSchedule.ItemsSource = templateSchedules;
                CBoxSchedule.DisplayMemberPath = "Name";
            }

        }

        private void ChooseSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBoxSchedule.HasItems)
            {
                Core.TemplateSchedule templateSchedule = (Core.TemplateSchedule)CBoxSchedule.SelectedItem;
                txtWeeks.Text = templateSchedule.NoOfWeeks.ToString();
                Mediator.GetInstance().OnTemplateScheduleSelected(sender, templateSchedule);
            }
            else
            {
                txtWeeks.Text = "";
            }

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
                BindDataTempScheduleCBox();
            };
        }

        private void BtnSaveUpdatedTemplateSchedule_Click(object sender, RoutedEventArgs e)
        {
            Core.TemplateSchedule templateSchedule = (Core.TemplateSchedule)CBoxSchedule.SelectedItem;
            Mediator.GetInstance().OnTemplateScheduleUpdateButtonClicked(sender, templateSchedule);
            MessageBox.Show("Changes to: " + templateSchedule.Name + " have been saved to database ");
           // BindData();
        }

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindDataTempScheduleCBox();
        }
    }
}
