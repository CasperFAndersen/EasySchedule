using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core;

namespace DesktopClient.Views.TemplateScheduleViews
{
    /// <summary>
    /// Interaction logic for TimeCell.xaml
    /// </summary>
    public partial class TimeCell : UserControl
    {
        public List<Shift> ShiftsInCell { get; set; }
        public List<ShiftElement> ShiftElements { get; set; }
        public TemplateSchedule TemplateSchedule { get; set; }
        public TimeSpan Time { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public ShiftElement ShiftElement { get; set; }
        public Dictionary<Shift, TimeCell> ShiftAndRootCell { get; set; }
        public int ShiftCount { get; set; }
        public int MaxRowCount { get; set; }
        public TimeCell()
        {
            InitializeComponent();
            ShiftsInCell = new List<Shift>();
            ShiftElements = new List<ShiftElement>();
            ShiftAndRootCell = new Dictionary<Shift, TimeCell>();
            SetDropHandler();
            SetCloseClick();
            SetEmployeeDropped();
            SetTemplateScheduleSelected();
            SetOnTemplateScheduleUpdateClicked();
            SetOnMenuItemChanged();
        }

        public Grid GetGrid()
        {
            return TimeCellGrid;
        }


        public void FillCell(Shift shift, bool isFirstElement, bool isLastElement)
        {
            Color color = Colors.RoyalBlue;
            if (shift.GetType() == typeof(ScheduleShift))
            {
                ScheduleShift scheduleShift = (ScheduleShift)shift;
                color = scheduleShift.IsForSale ? Colors.Red : Colors.RoyalBlue;
            }


            ShiftElement shiftElement = null;
            if (isFirstElement)
            {
                shiftElement = new ShiftElement(shift, color);
                Grid.SetRowSpan(this, 2);

                // Border.BorderThickness = new Thickness(0.1, 0.1, 0.1, 0);

            }
            else if (isLastElement)
            {
                shiftElement = new ShiftElement(shift, color, true);
                //Border.BorderThickness = new Thickness(0.1, 0, 0.1, 0.1);
            }
            else // Middle Element 
            {
                shiftElement = new ShiftElement(shift, color, false);
                // Border.BorderThickness = new Thickness(0.1, 0, 0.1, 0);
            }
            TimeCellGrid.ColumnDefinitions.Add(new ColumnDefinition());
            TimeCellGrid.Children.Add(shiftElement);
            Grid.SetColumn(shiftElement, ShiftsInCell.Count);
            ShiftsInCell.Add(shift);
        }

        private void OnHandleDrop(object sender, DragEventArgs e)
        {
            object droppedItem = e.Data.GetData("Object");

            if (droppedItem.GetType().IsSubclassOf(typeof(Shift)))
            {
                Shift droppedShift = (Shift)e.Data.GetData("Object");
               
                bool isLastElement = (bool)e.Data.GetData("IsLastShiftElement");
                if (isLastElement)
                {
                    if (droppedShift.GetType() == typeof(TemplateShift))
                    {
                        TemplateShift ts = (TemplateShift)droppedShift;
                        double hours = (Time.Subtract(ts.StartTime).Add(new TimeSpan(0, TemplateScheduleCalendar.INCREMENT, 0)).TotalHours);
                        ts.Hours = hours > 0 ? hours : 1;
                    }
                    else if (droppedShift.GetType() == typeof(ScheduleShift))
                    {
                        ScheduleShift ss = (ScheduleShift)droppedShift;
                        double hours = (Time.Hours - (ss.StartTime.Hour)); //+ TemplateScheduleCalendar.INCREMENT);
                        droppedShift.Hours = hours > 0 ? hours : 1;
                    }
                }
                else
                {
                    if (droppedShift.GetType() == typeof(TemplateShift))
                    {
                        TemplateShift ts = (TemplateShift)droppedShift;
                        ts.StartTime = Time;
                        ts.WeekDay = WeekDay;
                        droppedShift = ts;
                    }
                    else if (droppedShift.GetType() == typeof(ScheduleShift))
                    {
                        ScheduleShift ss = (ScheduleShift)droppedShift;
                        DateTime dt = new DateTime(ss.StartTime.Year, ss.StartTime.Month, (int)WeekDay, Time.Hours, Time.Minutes, 0);
                        ss.StartTime = dt;
                        droppedShift = ss;
                    }
                }
                Mediator.GetInstance().OnShiftDropped(sender, droppedShift, isLastElement);
            }
            else if (droppedItem.GetType() == typeof(Employee))
            {
                Employee employee = (Employee)droppedItem;
                Mediator.GetInstance().OnEmployeeDropped(employee, Time, WeekDay);
            }
        }

        private void SetDropHandler()
        {
            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                Clear();
            };
        }

        private void SetCloseClick()
        {
            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
            {
                Clear();
            };
        }

        private void SetEmployeeDropped()
        {
            Mediator.GetInstance().EmployeeDropped += (e, tod, dow) =>
            {
               Clear();
            };
        }

        private void SetTemplateScheduleSelected()
        {
            Mediator.GetInstance().TemplateScheduleSelected += (s, e) =>
            {
                TemplateSchedule = e.TemplateSchedule;
                Clear();
            };
        }

        private void SetOnTemplateScheduleUpdateClicked()
        {
            Mediator.GetInstance().TemplateScheduleUpdateClicked += (s, e) =>
            {
                Clear();
            };
        }

        private void SetOnMenuItemChanged()
        {
            Mediator.GetInstance().MenuItemChanged += () =>
            {
                Clear();
            };
        }

        public void Clear()
        {
            TemplateSchedule = null;
            ShiftsInCell = new List<Shift>();
            ShiftElements = new List<ShiftElement>();
            TimeCellGrid.Children.Clear();
            TimeCellGrid.ColumnDefinitions.Clear();
            TimeCellGrid.RowDefinitions.Clear();
            MaxRowCount = 0;
        }

        public int GetMaxRowCount()
        {
            int res = 0;
            foreach (Shift s in ShiftsInCell)
            {
                int  rowCount  = (int)(s.Hours * (60 / TemplateScheduleCalendar.INCREMENT));
                if (rowCount > res)
                {
                    res = rowCount;
                }
            }
            return res;
        }

        private void Border_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void Border_DragLeave(object sender, DragEventArgs e)
        {
            
        }


    }
}
