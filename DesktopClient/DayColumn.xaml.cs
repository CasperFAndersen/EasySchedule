using Core;
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
    /// Interaction logic for DayColumn.xaml
    /// </summary>
    public partial class DayColumn : UserControl
    {

        
        public List<TimeCell> TimeCellList { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        public DayColumn(DayOfWeek dayOfWeek)
        {
            this.dayOfWeek = dayOfWeek;
            InitializeComponent();
            TimeCellList = new List<TimeCell>();
            LoadTimeCells();
        }



        public Grid GetGrid()
        {
            return DayColumnGrid;
        }

        public void LoadTimeCells()
        {
            if (60 % Calendar.INCREMENT == 0)
            {
                TimeSpan timeCount = Calendar.STARTTIME;
                int rowCount = 0;
                while (timeCount <= Calendar.ENDTIME.Add(new TimeSpan(0, 60 -Calendar.INCREMENT, 0)))
                {
                    DayColumnGrid.RowDefinitions.Add(new RowDefinition());
                    TimeCell tempTimeCell = new TimeCell() { Time = timeCount, weekDay = dayOfWeek };
                    tempTimeCell.SetToolTipText(timeCount.ToString());

                    DayColumnGrid.Children.Add(tempTimeCell);
                    Grid.SetRow(tempTimeCell, rowCount);

                    TimeCellList.Add(tempTimeCell);

                    rowCount++;
                    timeCount = timeCount.Add(new TimeSpan(0, Calendar.INCREMENT, 0));
                }

            }
        }

        public void InsertShiftIntoDay(TemplateShift shift)
        {
            TimeCell timeCell = FindMatchingTimeCell(shift.StartTime);
            for (int i = 0; i < (shift.Hours * (60 / Calendar.INCREMENT)); i++)
            {
                if (i == 0)
                {
                    timeCell.FillCell(shift, true, false);
                    
                }

                else if (i == (shift.Hours * (60 / Calendar.INCREMENT)) - 1)
                {
                    timeCell.FillCell(shift, false, true);
                }
                else
                {
                    timeCell.FillCell(shift, false, false);
                }
                timeCell = GetNextTimeCell(timeCell);

            }
        }

        public TimeCell FindMatchingTimeCell(TimeSpan time)
        {
            return TimeCellList.Find(x => x.Time == time);
        }

        public TimeCell GetNextTimeCell(TimeCell timeCell)
        {
            TimeCell res = timeCell;
            int index = TimeCellList.IndexOf(timeCell);

            if ((index + 1) < TimeCellList.Count)
            {
                res = TimeCellList[index + 1];
            }

            return res;
        }

    }

}
