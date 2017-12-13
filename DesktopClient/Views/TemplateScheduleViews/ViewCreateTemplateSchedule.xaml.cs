using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;
using DesktopClient.Services;

namespace DesktopClient.Views.TemplateScheduleViews
{
    public partial class ViewCreateTemplateSchedule : UserControl
    {
        private List<Department> DepartmentList { get; set; }
        DepartmentProxy departmentProxy;

        public ViewCreateTemplateSchedule()
        {
            departmentProxy = new DepartmentProxy();
            InitializeComponent();
            LoadDeparmentList();
            NoOfWeeks.ItemsSource = new int[] { 1, 2, 3, 4 };
        }

        public async void LoadDeparmentList()
        {
            try
            {
                Department department = departmentProxy.GetDepartmentById(MainWindow.Employee.DepartmentId);
                List<Department> departmens = await departmentProxy.GetAllDepartmentsByWorkplaceIdAsync(department.WorkplaceId);
                CBoxDepartment.ItemsSource = departmens;
                CBoxDepartment.DisplayMemberPath = "Name";
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong! Could not fetch departments");
            }
        }

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mediator.GetInstance().OnDepartmentBoxSelected((Department)CBoxDepartment.SelectedItem);
            NoOfWeeks.SelectedIndex = 1;
        }

        private void BtnSaveTemplateSchedule_Click(object sender, RoutedEventArgs e)
        {
            if (TxtBoxTemplateScheduleName.Text.Length == 0)
            {
                MessageBox.Show("Please enter name");
            }
            else if (NoOfWeeks.SelectedItem == null)
            {
                MessageBox.Show("Please choose number of weeks!");
            }
            else
            {
                Core.TemplateSchedule templateSchedule = new Core.TemplateSchedule();
                Department selectedDep = (Department)CBoxDepartment.SelectedItem;
                templateSchedule.DepartmentId = selectedDep.Id;
                templateSchedule.NoOfWeeks = (int)NoOfWeeks.SelectedItem;
                templateSchedule.Name = TxtBoxTemplateScheduleName.Text;
                Mediator.GetInstance().OnCreateTemplateScheduleButtonClicked(templateSchedule);
           
            }
        }

        private void NoOfWeeks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int prevSelection = -1;
            if (e.RemovedItems.Count != 0)
            {
                prevSelection = (int)e.RemovedItems[0];
            }
            Mediator.GetInstance().OnNumOfWeekBoxChanged((int)NoOfWeeks.SelectedItem, NoOfWeeks, prevSelection);
        }
    }
}
