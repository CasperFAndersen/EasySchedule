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

namespace DesktopClient.Views.Schedule
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
            txtBox.Text = string.Format("{0}-{1}/{2}", date.DayOfWeek.ToString(),date.Day.ToString(), date.Month.ToString());
            Date = date;
        }

        public void UpdateDate(DateTime newDate)
        {
            DataContext = newDate;
            Date = newDate;
            txtBox.Text = string.Format("{0}-{1}/{2}", Date.DayOfWeek.ToString(), Date.Day.ToString(), Date.Month.ToString());
        }
    }
}
