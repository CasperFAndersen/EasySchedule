using System;
using System.Windows.Controls;

namespace DesktopClient.Views.ScheduleViews
{
    /// <summary>
    /// Interaction logic for DateBox.xaml
    /// </summary>
    public partial class DateBox : UserControl
    {
        public DateTime Date { get; set; }
        public DateBox(DateTime date)
        {
            InitializeComponent();
            DataContext = date;
            txtBox.Text = string.Format("{0}-{1}/{2}", date.DayOfWeek.ToString(), date.Day, date.Month);
            Date = date;
        }

        public void UpdateDate(DateTime newDate)
        {
            DataContext = newDate;
            Date = newDate;
            txtBox.Text = string.Format("{0}-{1}/{2}", Date.DayOfWeek.ToString(), Date.Day, Date.Month);
        }
    }
}
