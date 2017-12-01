using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Core;
using DesktopClient.Views.TemplateScheduleViews;

namespace DesktopClient.Views.TemplateScheduleViews
{
    public partial class DayColumn : UserControl
    {
        public List<TimeCell> TimeCellList { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DayColumn(DayOfWeek dayOfWeek)
        {
            this.DayOfWeek = dayOfWeek;
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
            if (60 % TemplateScheduleCalendar.INCREMENT == 0)
            {
                TimeSpan timeCount = TemplateScheduleCalendar.STARTTIME;
                int rowCount = 0;
                while (timeCount <= TemplateScheduleCalendar.ENDTIME.Add(new TimeSpan(0, 60 - TemplateScheduleCalendar.INCREMENT, 0)))
                {
                    DayColumnGrid.RowDefinitions.Add(new RowDefinition());
                    TimeCell tempTimeCell = new TimeCell() { Time = timeCount, WeekDay = DayOfWeek };
                    tempTimeCell.SetToolTipText(timeCount.ToString());

                    DayColumnGrid.Children.Add(tempTimeCell);
                    Grid.SetRow(tempTimeCell, rowCount);

                    TimeCellList.Add(tempTimeCell);

                    rowCount++;
                    timeCount = timeCount.Add(new TimeSpan(0, TemplateScheduleCalendar.INCREMENT, 0));
                }
            }
        }

        public void InsertShiftIntoDay(Shift shift)
        {
            TimeCell timeCell = new TimeCell();
            if (shift.GetType() == typeof(TemplateShift))
            {
                TemplateShift ts = (TemplateShift)shift;
                timeCell = FindMatchingTimeCell(ts.StartTime);
            }
            else if (shift.GetType() == typeof(ScheduleShift))
            {
                ScheduleShift ss = (ScheduleShift)shift;
                timeCell = FindMatchingTimeCell(new TimeSpan(ss.StartTime.Hour, ss.StartTime.Minute, ss.StartTime.Second));
            }
            
            for (int i = 0; i < (shift.Hours * (60 / TemplateScheduleCalendar.INCREMENT)); i++)
            {
                if (i == 0)
                {
                    timeCell.FillCell(shift, true, false);
                    
                }
                else if (i == (shift.Hours * (60 / TemplateScheduleCalendar.INCREMENT)) - 1)
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

        internal void Clear()
        {
            TimeCellList.ForEach(x => x.Clear());
        }
    }

}
