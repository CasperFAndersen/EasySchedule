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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {
        public static readonly TimeSpan STARTTIME = new TimeSpan(6,0,0);
        public static readonly TimeSpan ENDTIME = new TimeSpan(20, 0, 0);
        public static readonly int INCREMENT = 30;

        Color[] colors = { Colors.AliceBlue, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.LightPink, Colors.Fuchsia, Colors.RoyalBlue };

        public List<DayColumn> DayColumnList { get; set; }
        public List<TemplateShift> Shifts { get; set; }
        public Calendar()
        {
            InitializeComponent();
            DayColumnList = new List<DayColumn>();
            //TimesColumn.BuildDayGrid(STARTTIME, ENDTIME, 60);
            BuildTimesGrid();
            BuildDayColumns();
        }

        public void LoadShiftsIntoCalendar()
        {
            foreach (var shift in Shifts)
            {
                DayColumn dayCol = GetDayCoulmByName(shift.WeekDay.ToString());
                dayCol.InsertShiftIntoDay(shift);
            }

        }

        public DayColumn GetDayCoulmByName(string name)
        {
            return DayColumnList.Find(x => x.Name == name);
        }


        public void BuildTimesGrid()
        {
            TimeSpan timeCount = STARTTIME;
            int rowCount = 0;
            while (timeCount <= ENDTIME)
            {
                TimesColumn.RowDefinitions.Add(new RowDefinition());
                TimeCell tempTimeCell = new TimeCell() { Time = timeCount };
                TextBlock textBlock = new TextBlock() { Text = timeCount.ToString() };
                textBlock.HorizontalAlignment = HorizontalAlignment.Right;
                tempTimeCell.GetGrid().Children.Add(textBlock);
                TimesColumn.Children.Add(tempTimeCell);
                Grid.SetRow(tempTimeCell, rowCount);

                rowCount++;
                timeCount = timeCount.Add(new TimeSpan(0, 60, 0));

            }

        }

        public void BuildDayColumns()
        {
            int row = 1; int col = 1;
            int day = 0;
            while (day <7)
            {
                string name = Enum.GetName(typeof(DayOfWeek), day);
                DayColumn dayCol = new DayColumn() { Name = name };
                CalendarGrid.Children.Add(dayCol);

                Grid.SetColumn(dayCol, col);
                Grid.SetRow(dayCol, row);
                Grid.SetRowSpan(dayCol, 12);

                day++;
                col++;

                DayColumnList.Add(dayCol);
            }
        }


    }
}
