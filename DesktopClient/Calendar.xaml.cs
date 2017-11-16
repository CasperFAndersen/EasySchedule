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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        private static readonly TimeSpan STARTTIME;
        private static readonly TimeSpan ENDTIME;
        private static readonly int INCREMENT;
        public Calendar()
        {
            InitializeComponent();
        }

        public void LoadTimesColumn()
        {
            if (STARTTIME.Minutes == 0 && )
            {

            }

            
            
        }

        public bool ValidateStartTime()
        {
            bool res = false;
            if(STARTTIME.Minutes == 0 && STARTTIME.Seconds == 0)
            {
                res = true;
            }
            else
            {
                MessageBox.Show("StartTime Not Valid! Please use a time with 0 minutes and 0 secounds");
            }

            return res;
        }

        public bool ValidateEndTime()
        {
            bool res = false;
            if (ENDTIME.Minutes == 0 && ENDTIME.Seconds == 0)
            {
                res = true;
            }
            else
            {
                MessageBox.Show("StartTime Not Valid! Please use a time with 0 minutes and 0 secounds");
            }

            return res;
        }
    }
}
