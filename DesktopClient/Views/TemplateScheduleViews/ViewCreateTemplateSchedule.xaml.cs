using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core;

namespace DesktopClient.Views.TemplateScheduleViews
{
    public partial class ViewCreateTemplateSchedule : UserControl
    {
        private List<Department> DepartmentList { get; set; }

        public ViewCreateTemplateSchedule()
        {
            InitializeComponent();
            LoadDeparmentList();
            NoOfWeeks.ItemsSource = new int[] { 1, 2, 3, 4 };
        }

        public void LoadDeparmentList()
        {
            List<Department> departmens = new DepartmentEvents().LoadDeparmentList();
            CBoxDepartment.ItemsSource = departmens;
            CBoxDepartment.DisplayMemberPath = "Name";
        }

        private void CBoxDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Employee> employees = new EmployeeEvents().GetListOfEmployees((Department)CBoxDepartment.SelectedItem);
            Mediator.GetInstance().OnDepartmentBoxSelected(employees, (Department)CBoxDepartment.SelectedItem);
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
