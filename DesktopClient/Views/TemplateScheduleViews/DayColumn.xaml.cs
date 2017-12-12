using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Core;
using DesktopClient.Views.TemplateScheduleViews;
using System.Windows.Media;

namespace DesktopClient.Views.TemplateScheduleViews
{
    public partial class DayColumn : UserControl
    {
        public List<TimeCell> TimeCellList { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public List<Shift> Shifts { get; set; }
        private List<Shift> loadedShifts = new List<Shift>();
        public DayColumn(DayOfWeek dayOfWeek)
        {
            this.DayOfWeek = dayOfWeek;
            InitializeComponent();
            TimeCellList = new List<TimeCell>();
            Shifts = new List<Shift>();
            SetOnResizeShiftStarted();
            LoadTimeCells();
        }

        private void SetOnResizeShiftStarted()
        {
            Mediator.GetInstance().ResizeShiftStarted += () =>
            {
                ResetTimeCells();
            };
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
                    
                    DayColumnGrid.Children.Add(tempTimeCell);
                    Grid.SetZIndex(tempTimeCell, 100);
                    Grid.SetRow(tempTimeCell, rowCount);

                    TimeCellList.Add(tempTimeCell);

                    rowCount++;
                    timeCount = timeCount.Add(new TimeSpan(0, TemplateScheduleCalendar.INCREMENT, 0));
                }
            }
        }


        public void RenderShifts()
        {
            loadedShifts.Clear();
            bool isTemplate = false;
            int zIndex = 600;
            foreach (Shift shift in Shifts)
            {

                //Find the corosponding timecell element
                TimeCell timeCell = new TimeCell();
                if (shift.GetType() == typeof(TemplateShift))
                {
                    TemplateShift ts = (TemplateShift)shift;
                    timeCell = FindMatchingTimeCell(ts.StartTime);
                    isTemplate = true;
                }
                else if (shift.GetType() == typeof(ScheduleShift))
                {
                    ScheduleShift ss = (ScheduleShift)shift;
                    timeCell = FindMatchingTimeCell(new TimeSpan(ss.StartTime.Hour, ss.StartTime.Minute, ss.StartTime.Second));
                }
             
              
                //------------------Set rows and columns-----------------------
                //Find out how many columns the should be in the current timecell
                int columnAmount = OverlapsWithShiftsInList(shift, Shifts) > 0 ? OverlapsWithShiftsInList(shift, Shifts) + 1 : 1;
                //Find out which column nr the current shift shall insertes into
                int columnNr = OverlapsWithShiftsInList(shift, loadedShifts);

                //Find how many rows the timecell should have
                int rowCount = (int)(shift.Hours * (60 / TemplateScheduleCalendar.INCREMENT));
                //Set the max-rowcount for block of shifts
                timeCell.MaxRowCount = timeCell.MaxRowCount < rowCount ? rowCount : timeCell.MaxRowCount;

                //------------------Insert shiftelement-------------------------
                //Find the right color
                Color col = Colors.RoyalBlue;
                if (!isTemplate)
                {
                    ScheduleShift scheduleShift = (ScheduleShift)shift;
                    if (scheduleShift.IsForSale)
                    {
                        col = Colors.MistyRose;  // Mmmmmmm.... Misty Rose
                    }
                }
                //Instansiate the shiftelement
                ShiftElement shiftElement = new ShiftElement(shift, col);
                shiftElement.RootTimeCell = timeCell;
                shiftElement.AddButtom(new ShiftElement(shift, col, true));
                //shiftElement.SetMouseOver();
                //shiftElement.SetMouseLeave();
                //Add shiftelement to timecell
                timeCell.TimeCellGrid.Children.Add(shiftElement);
                //Add columns
                timeCell.TimeCellGrid.ColumnDefinitions.Clear();
                for (int i = 0; i < columnAmount; i++)
                {
                    timeCell.TimeCellGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                //Add rows for the timeCell
                timeCell.TimeCellGrid.RowDefinitions.Clear();
                for (int i = 0; i < timeCell.MaxRowCount; i++)
                {
                    timeCell.TimeCellGrid.RowDefinitions.Add(new RowDefinition());
                }
                //Set rowspan for timecell
                Grid.SetRowSpan(timeCell, timeCell.MaxRowCount);
                //Set rowspan for shiftelement
                Grid.SetRowSpan(shiftElement, rowCount);
                //Set columnspan for timeCell
                Grid.SetColumnSpan(timeCell, columnAmount);
                //Set column for shiftelement
                Grid.SetColumn(shiftElement, columnNr);
                Grid.SetZIndex(timeCell, zIndex);
                //zIndex--;
                //Finally add shift to list of loaded shifts
                loadedShifts.Add(shift);
        
            }         
        }

        public int OverlapsWithShiftsInList(Shift shift, List<Shift> shifts)
        {
            int res = 0;

            if (shift.GetType() == typeof(TemplateShift))
            {
                TemplateShift templateShift = (TemplateShift)shift;
                foreach (Shift s in shifts)
                {
                    TemplateShift currShift = (TemplateShift)s;
                    if (templateShift.Employee != currShift.Employee)
                    {
                        if (templateShift.StartTime < currShift.StartTime &&
                            (templateShift.StartTime.Add(new TimeSpan((int)templateShift.Hours, 0, 0))) > currShift.StartTime)
                        {
                            res++;
                        }
                        else if (templateShift.StartTime > currShift.StartTime &&
                            (currShift.StartTime.Add(new TimeSpan((int)currShift.Hours, 0, 0))) > templateShift.StartTime)
                        {
                            res++;
                        }
                        else if (templateShift.StartTime == currShift.StartTime)
                        {
                            res++;
                        }
                    }

                }
            }
            else if (shift.GetType() == typeof(ScheduleShift))
            {
                ScheduleShift scheduleShift = (ScheduleShift)shift;
                foreach (Shift s in shifts)
                {
                    ScheduleShift currShift = (ScheduleShift)s;
                    if (scheduleShift.Employee != currShift.Employee)
                    {
                        if (scheduleShift.StartTime < currShift.StartTime &&
                            (scheduleShift.StartTime.AddHours(scheduleShift.Hours) > currShift.StartTime))
                        {
                            res++;
                        }
                        else if (scheduleShift.StartTime > currShift.StartTime &&
                            (currShift.StartTime.AddHours(currShift.Hours) > scheduleShift.StartTime))
                        {
                            res++;
                        }
                        else if (scheduleShift.StartTime == currShift.StartTime)
                        {
                            res++;
                        }
                    }

                }
            }

            return res;
        }





        public void ResetTimeCells()
        {
            TimeCellList.ForEach(x =>
            {
                x.Visibility = System.Windows.Visibility.Visible;
                Grid.SetZIndex(x, 100);
                x.ShiftAndRootCell.Clear();
            });


        }

        //public void InsertShiftIntoDay(Shift shift)
        //{
        //    TimeCell timeCell = new TimeCell();
        //    if (shift.GetType() == typeof(TemplateShift))
        //    {
        //        TemplateShift ts = (TemplateShift)shift;
        //        timeCell = FindMatchingTimeCell(ts.StartTime);
        //    }
        //    else if (shift.GetType() == typeof(ScheduleShift))
        //    {
        //        ScheduleShift ss = (ScheduleShift)shift;
        //        timeCell = FindMatchingTimeCell(new TimeSpan(ss.StartTime.Hour, ss.StartTime.Minute, ss.StartTime.Second));
        //    }

        //    for (int i = 0; i < (shift.Hours * (60 / TemplateScheduleCalendar.INCREMENT)); i++)
        //    {
        //        if (i == 0)
        //        {
        //            timeCell.FillCell(shift, true, false);

        //        }
        //        else if (i == 1)
        //        {
        //            timeCell.TimeCellGrid.Opacity = 0.0;
        //        }
        //        else if (i == (shift.Hours * (60 / TemplateScheduleCalendar.INCREMENT)) - 1)
        //        {
        //            timeCell.FillCell(shift, false, true);
        //        }
        //        else
        //        {
        //            timeCell.FillCell(shift, false, false);
        //        }
        //        timeCell = GetNextTimeCell(timeCell);
        //    }
        //}

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
           
            Shifts.Clear();
            TimeCellList.ForEach(x => x.Clear());
        }
    }

}
