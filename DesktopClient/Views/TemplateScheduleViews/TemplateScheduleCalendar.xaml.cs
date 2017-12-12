using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Core;

namespace DesktopClient.Views.TemplateScheduleViews
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class TemplateScheduleCalendar : UserControl
    {
        public static readonly TimeSpan STARTTIME = new TimeSpan(6, 0, 0);
        public static readonly TimeSpan ENDTIME = new TimeSpan(20, 0, 0);
        public static readonly double DEFAULTSHIFTLENGTH = 3;
        public static readonly int INCREMENT = 30;

        Color[] colors = { Colors.IndianRed, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.Thistle, Colors.SkyBlue, Colors.RoyalBlue, Colors.Turquoise };
        public static Dictionary<Employee, Color> EmployeeColors { get; set; }

        Random rnd = new Random();
        private int numOfWeeks = 1;
        public List<TemplateScheduleViews.DayColumn> DayColumnList { get; set; }
        public List<TemplateShift> Shifts { get; set; }
        public static int WeekNumber { get; set; }
        public TemplateScheduleCalendar()
        {
            InitializeComponent();
            DayColumnList = new List<TemplateScheduleViews.DayColumn>();
            Shifts = new List<TemplateShift>();
            WeekNumber = 1;
            btnNextWeek.IsEnabled = false;
            btnPrevWeek.IsEnabled = false;
            BuildTimesGrid();
            BuildDayColumns();
            EmployeeColors = new Dictionary<Employee, Color>();
            //AddShifts(GetListOfTemplateShifts());
            SetShiftDropHandler();
            SetCloseShiftClicked();
            SetEmployeeDroppedHandler();
            SetTemplateScheduleSelected();
            LoadShiftsIntoCalendar();
            SetTemplateScheduleUpdateClicked();
            SetCreateTemplateScheduleClicked();
            SetOnNumOfWeeksBoxChanged();
        }


        private void AddShifts(List<TemplateShift> list)
        {
            list.ForEach(x => Shifts.Add(x));
            Shifts.ForEach(x => EmployeeColors.Add(x.Employee, GetRandomColor()));
        }

        public void AddShift(TemplateShift shift)
        {

            if (!EmployeeColors.ContainsKey(shift.Employee))
            {
                EmployeeColors.Add(shift.Employee, GetRandomColor());
            }
            Shifts.Add(shift);

        }

        public void LoadShiftsIntoCalendar()
        {
            foreach (var shift in Shifts)
            {
                if (shift.WeekNumber == Convert.ToInt32(txtWeekNum.Text))
                {
                    TemplateScheduleViews.DayColumn dayCol = GetDayCoulmByName(shift.WeekDay.ToString());
                    // dayCol.InsertShiftIntoDay(shift);
                    
                    dayCol.Shifts.Add(shift);
                    
                }

            }
            DayColumnList.ForEach(x => x.RenderShifts());

        }

        public TemplateScheduleViews.DayColumn GetDayCoulmByName(string name)
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
                Border border = new Border() { BorderBrush = new SolidColorBrush(Colors.Black), BorderThickness = new Thickness(0.5, 0.5, 0.5, 0.5) };
                border.Background = new SolidColorBrush(Colors.LightGray);
                TextBlock textBlock = new TextBlock() { Text = timeCount.ToString().Substring(0, 5), FontSize = 14, FontWeight = FontWeights.Bold };
                textBlock.Margin = new Thickness(0, -2, 5, 0);
                border.Child = textBlock;
                textBlock.HorizontalAlignment = HorizontalAlignment.Right;

                TimesColumn.Children.Add(border);
                Grid.SetRow(border, rowCount);

                rowCount++;
                timeCount = timeCount.Add(new TimeSpan(0, 60, 0));
            }
        }

        public void BuildDayColumns()
        {
            int row = 2; int col = 1;
            int day = 1;
            while (day < 6)
            {
                string name = Enum.GetName(typeof(DayOfWeek), day);
                TemplateScheduleViews.DayColumn dayCol = new TemplateScheduleViews.DayColumn((DayOfWeek)day) { Name = name };
                CalendarGrid.Children.Add(dayCol);

                Grid.SetColumn(dayCol, col);
                Grid.SetRow(dayCol, row);
                Grid.SetRowSpan(dayCol, 12);

                day++;
                col++;

                DayColumnList.Add(dayCol);
            }
        }

        public void SetShiftDropHandler()
        {

            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                Clear();
                //  DayColumnList.ForEach(x => x.ResetTimeCells());
                LoadShiftsIntoCalendar();
            };
        }
        
        public void SetEmployeeDroppedHandler()
        {
            Mediator.GetInstance().EmployeeDropped += (e, tod, dow) =>
            {
                if (this.IsVisible)
                {
                    Clear();
                    Shifts.Add(new TemplateShift() { Employee = e, StartTime = tod, WeekDay = dow, WeekNumber = WeekNumber, Hours = DEFAULTSHIFTLENGTH });
                    LoadShiftsIntoCalendar();
                }

            };
        }

        public void SetCloseShiftClicked()
        {
            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
             {
                 if (e.Shift.GetType() == typeof(TemplateShift))
                 {
                     TemplateShift ts = (TemplateShift)e.Shift;
                     Shifts.Remove(ts);
                 }
                 DayColumnList.ForEach(x => x.ResetTimeCells());
                 Clear();
                 LoadShiftsIntoCalendar();
             };
        }

        public void SetTemplateScheduleSelected()
        {
            Mediator.GetInstance().TemplateScheduleSelected += (s, e) =>
            {
                if (this.IsVisible)
                {
                    Shifts.Clear();
                    EmployeeColors.Clear();
                    AddShifts(e.TemplateSchedule.TemplateShifts);
                    if (e.TemplateSchedule.NoOfWeeks > 1)
                    {
                        btnNextWeek.IsEnabled = true;
                    }
                    numOfWeeks = e.TemplateSchedule.NoOfWeeks;
                    LoadShiftsIntoCalendar();
                }

            };
        }

        private void SetTemplateScheduleUpdateClicked()
        {
            Mediator.GetInstance().TemplateScheduleUpdateClicked += (schedule, e) =>
            {
                e.TemplateSchedule.TemplateShifts = Shifts;
                TemplateScheduleProxy templateScheduleProxy = new TemplateScheduleProxy();
                templateScheduleProxy.UpdateTemplateSchedule(e.TemplateSchedule);
            };
        }

        private void SetCreateTemplateScheduleClicked()
        {
            Mediator.GetInstance().CreateTemplateScheduleButtonClicked += (templateSchedule) =>
            {
                if (this.IsVisible)
                {
                    if (Shifts.Count == 0)
                    {
                        MessageBox.Show("No shifts has been added!");
                    }
                    else
                    {
                        TemplateScheduleProxy templateScheduleProxy = new TemplateScheduleProxy();
                        templateSchedule.TemplateShifts = Shifts;
                        templateScheduleProxy.AddTemplateScheduleToDb(templateSchedule);
                        Shifts.Clear();
                        MessageBox.Show("Template schedule is now saved onto database");
                    }
                }

            };
        }

        private void SetOnNumOfWeeksBoxChanged()
        {
            //TODO: WHAT IS B AND P ARNE?
            Mediator.GetInstance().NumOfWeekBoxChanged += (numberOfWeeks, b, p) =>
            {
                numOfWeeks = numberOfWeeks;
                if (numOfWeeks > WeekNumber)
                {
                    btnNextWeek.IsEnabled = true;
                }
                else if (numOfWeeks == WeekNumber)
                {
                    btnNextWeek.IsEnabled = false;
                }
                else if (numberOfWeeks < WeekNumber)
                {
                    btnNextWeek.IsEnabled = false;
                    bool noShiftsWillBeLost = Shifts.TrueForAll(x => x.WeekNumber < numberOfWeeks);
                    if (!noShiftsWillBeLost)
                    {
                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Shifts placed in higher week numbers will be lost. Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            Shifts.RemoveAll(x => x.WeekNumber > numberOfWeeks);
                            txtWeekNum.Text = numberOfWeeks.ToString();
                            WeekNumber = numberOfWeeks;
                            btnNextWeek.IsEnabled = false;
                            Clear();
                            LoadShiftsIntoCalendar();
                        }
                        else if (messageBoxResult == MessageBoxResult.No)
                        {
                            b.SelectedIndex = p;
                        }
                    }
                    else
                    {
                        WeekNumber = numberOfWeeks;
                        txtWeekNum.Text = numberOfWeeks.ToString();
                    }
                    if (numberOfWeeks == 1)
                    {
                        btnPrevWeek.IsEnabled = false;
                    }
                }
            };
        }


        public Color GetRandomColor()
        {
            return colors[rnd.Next(colors.Length)];
        }

        private void NextWeek_Click(object sender, RoutedEventArgs e)
        {
            if (WeekNumber < numOfWeeks)
            {
                WeekNumber++;
                txtWeekNum.Text = WeekNumber.ToString();
                Clear();
                btnPrevWeek.IsEnabled = true;
                if (WeekNumber == numOfWeeks)
                {
                    btnNextWeek.IsEnabled = false;
                }
                LoadShiftsIntoCalendar();
            }
        }

        private void PrevWeek_Click(object sender, RoutedEventArgs e)
        {
            if (WeekNumber != 1)
            {
                WeekNumber--;
                txtWeekNum.Text = WeekNumber.ToString();
                Clear();
                LoadShiftsIntoCalendar();
                if (WeekNumber == 1)
                {
                    btnPrevWeek.IsEnabled = false;
                }
                btnNextWeek.IsEnabled = true;
            }
        }

        public void Clear()
        {
            DayColumnList.ForEach(x => x.Clear());
        }
    }
}
