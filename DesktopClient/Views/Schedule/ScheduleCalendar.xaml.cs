using Core;
using DesktopClient.Services;
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
    /// Interaction logic for ScheduleCalendar.xaml
    /// </summary>
    public partial class ScheduleCalendar : UserControl
    {
        public Core.Schedule Schedule { get; set; }
        public int DepartmentId { get; set; }
        public DateTime SelectedWeekStartDate { get; set; }
        public List<DateBox> DateBoxes { get; set; }
        public ScheduleCalendar()
        {
            InitializeComponent();
            Shifts = new List<ScheduleShift>();
            DayColumnList = new List<DayColumn>();
            DateBoxes = new List<DateBox>();
            WeekNumber = 1;
            btnNextWeek.IsEnabled = false;
            btnPrevWeek.IsEnabled = false;
            BuildTimesGrid();
            BuildDayColumns();
            EmployeeColors = new Dictionary<Employee, Color>();
            BuildDateBoxes();
            btnNextWeek.IsEnabled = true;
            btnPrevWeek.IsEnabled = true;
            SetSelectedStartDate(DateTime.Now);
            SetOnDepartmentSelected();
            LoadShiftsIntoCalendar();
            SetShiftDropHandler();
            SetCloseShiftClicked();
            SetEmployeeDroppedHandler();
            SetOnEditScheduleClicked();
            SetOnGenerateScheduleButtonClicked();
        }
        public static readonly TimeSpan STARTTIME = new TimeSpan(6, 0, 0);
        public static readonly TimeSpan ENDTIME = new TimeSpan(20, 0, 0);
        public static readonly double DEFAULTSHIFTLENGTH = 3;
        public static readonly int INCREMENT = 30;

        Color[] colors = { Colors.IndianRed, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.Thistle, Colors.SkyBlue, Colors.RoyalBlue, Colors.Turquoise };
        public static Dictionary<Employee, Color> EmployeeColors { get; set; }

        Random rnd = new Random();
        public List<DayColumn> DayColumnList { get; set; }
        public List<ScheduleShift> Shifts { get; set; }
        public static int WeekNumber { get; set; }



        public void LoadShiftsIntoCalendar()
        {
            foreach (var shift in Shifts)
            {
                ScheduleShift s = (ScheduleShift)shift;
                foreach (var dbox in DateBoxes)
                {
                    if (dbox.Date.Day == s.StartTime.Day && dbox.Date.Month == s.StartTime.Month)
                    {
                        DayColumn dayCol = GetDayCoulmByName(s.StartTime.DayOfWeek.ToString());
                        dayCol.InsertShiftIntoDay(shift);
                    }
                }

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
            int row = 2; int col = 2;
            int day = 1;
            while (day < 6)
            {
                string name = Enum.GetName(typeof(DayOfWeek), day);
                DayColumn dayCol = new DayColumn((DayOfWeek)day) { Name = name };
                CalendarGrid.Children.Add(dayCol);

                Grid.SetColumn(dayCol, col);
                Grid.SetRow(dayCol, row);
                Grid.SetRowSpan(dayCol, 12);

                day++;
                col++;

                DayColumnList.Add(dayCol);

            }
        }

        public void BuildDateBoxes()
        {
            DateTime currentDate = DateTime.Now;
            int thisMonday = (currentDate.DayOfWeek == DayOfWeek.Sunday) ? (currentDate.Day - 6) : (currentDate.Day - ((int)currentDate.DayOfWeek - 1));
            DateTime date = new DateTime(currentDate.Year, currentDate.Month, thisMonday);

            int row = 1; int col = 2;
            int day = 0;
            while (day < 5)
            {
                DateBox dBox = new DateBox(date.AddDays(day));
                CalendarGrid.Children.Add(dBox);

                Grid.SetColumn(dBox, col);
                Grid.SetRow(dBox, row);

                day++;
                col++;
                DateBoxes.Add(dBox);
            }
        }

        public void UpdateDateBoxes()
        {
            for (int i = 0; i < 5; i++)
            {
                DateBox curr = DateBoxes[i];
                curr.UpdateDate(SelectedWeekStartDate.AddDays(i));
            }
        }



        private void NavCalendar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavCalendar.DataContext = SelectFullWeek();
        }

        private void NavCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SetSelectedStartDate((DateTime)NavCalendar.SelectedDate);
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            UpdateDateBoxes();
            Clear();
            LoadShiftsIntoCalendar();
        }

        public void SetSelectedStartDate(DateTime date)
        {
            SelectedWeekStartDate = (date.DayOfWeek == DayOfWeek.Sunday) ? (date.AddDays(-6)) : (date.AddDays(-(int)date.DayOfWeek + 1));
        }

        private List<DateTime> SelectFullWeek()
        {
            List<DateTime> res = new List<DateTime>();
            for (int i = 0; i < 5; i++)
            {
                res.Add(new DateTime(SelectedWeekStartDate.Year, SelectedWeekStartDate.Month, SelectedWeekStartDate.Day + i));
            }
            return res;
        }

        public void SetShiftDropHandler()
        {
            Mediator.GetInstance().ShiftDropped += (s, e) =>
            {
                if (!e.IsLastElement && this.IsVisible)
                {
                    ScheduleShift ss = (ScheduleShift)e.Shift;
                    DateBox db = DateBoxes[ss.StartTime.Day - 1];
                    DateTime dt = new DateTime(db.Date.Year, db.Date.Month, db.Date.Day, ss.StartTime.Hour, ss.StartTime.Minute, 0);
                    ss.StartTime = dt;
                }
                LoadShiftsIntoCalendar();
            };
        }

        public void SetEmployeeDroppedHandler()
        {
            Mediator.GetInstance().EmployeeDropped += (e, tod, dow) =>
            {
                if (this.IsVisible)
                {
                    ScheduleShift ss = new ScheduleShift();
                    DateBox db = DateBoxes[(int)dow - 1];
                    DateTime dt = new DateTime(db.Date.Year, db.Date.Month, db.Date.Day, tod.Hours, tod.Minutes, 0);
                    ss.StartTime = dt;
                    ss.Employee = e;
                    ss.Hours = DEFAULTSHIFTLENGTH;
                    Shifts.Add(ss);
                    LoadShiftsIntoCalendar();
                }


            };
        }

        public void SetCloseShiftClicked()
        {
            Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
            {
                Shifts.Remove((ScheduleShift)e.Shift);
                LoadShiftsIntoCalendar();
            };
        }

        public void SetOnDepartmentSelected()
        {
            Mediator.GetInstance().CBoxDepartmentChanged += (d, s) =>
            {
                if (s != null)
                {
                    Shifts = s.Shifts;
                    Schedule = s;
                    LoadShiftsIntoCalendar();
                }
                else
                {
                    Shifts.Clear();
                    Schedule = null;
                    Clear();
                }
                DepartmentId = d.Id;
            };

        }

        public void SetOnEditScheduleClicked()
        {
            Mediator.GetInstance().EditScheduleClicked += () =>
            {
                try
                {
                    ScheduleProxy scheduleProxy = new ScheduleProxy();
                    if (Schedule != null)
                    {
                        scheduleProxy.UpdateSchedule(Schedule);
                    }

                    MessageBox.Show("Schedule for " + Schedule.Department.Name + " Saved sucessfully");
                    
                }
                catch (Exception)
                {

                    throw;
                }
            };
        }

        private void SetOnGenerateScheduleButtonClicked()
        {
            Mediator.GetInstance().GenerateScheduleButtonClicked += (s) =>
            {
                Schedule = s;
                Shifts = s.Shifts;
                LoadShiftsIntoCalendar();
            };

        }

        private void SetOnCreateScheduleClicked()
        {
            Mediator.GetInstance().CreateScheduleClicked += () =>
            {
                if (Schedule != null)
                {
                    ScheduleProxy scheduleProxy = new ScheduleProxy();
                    scheduleProxy.InsertScheduleIntoDb(Schedule);
                }
               

            };
        }


        private void NextWeek_Click(object sender, RoutedEventArgs e)
        {
            SelectedWeekStartDate = SelectedWeekStartDate.AddDays(7);
            UpdateDateBoxes();
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            Clear();

            if (Schedule != null && Schedule.EndDate.CompareTo(DateBoxes[0].Date) < 0)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;
                }
                catch (Exception)
                {

                    Schedule = null;
                }

            }
            else if(Schedule == null)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;
                }
                catch (Exception)
                {

                    Schedule = null;
                }
            }
            LoadShiftsIntoCalendar();
            Mediator.GetInstance().OnNextOrPreviousButtonClicked(Schedule);

        }

        private void PrevWeek_Click(object sender, RoutedEventArgs e)
        {
            SelectedWeekStartDate = SelectedWeekStartDate.AddDays(-7);
            UpdateDateBoxes();
            NavCalendar.SelectedDate = SelectedWeekStartDate;
            Clear();
            if (Schedule != null && Schedule.StartDate.CompareTo(DateBoxes[0].Date) >= 0)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;
                }
                catch (Exception)
                {

                    Schedule = null;
                }

            }
            else if(Schedule == null)
            {
                try
                {
                    Schedule = new ScheduleProxy().GetScheduleByDepartmentIdAndDate(DepartmentId, DateBoxes[0].Date);
                    Shifts = Schedule.Shifts;
                }
                catch (Exception)
                {

                    Schedule = null;
                }
            }
            
            Mediator.GetInstance().OnNextOrPreviousButtonClicked(Schedule);
            LoadShiftsIntoCalendar();
        }

        public void Clear()
        {
            DayColumnList.ForEach(x => x.Clear());
        }


        public static List<ScheduleShift> GetListOfTestShifts()
        {
            List<ScheduleShift> res = new List<ScheduleShift>();
            ScheduleShift ts = new ScheduleShift() { StartTime = new DateTime(2017, 11, 28, 15, 0, 0), Hours = 6, Employee = new Employee() { Name = "Holger" } };
            res.Add(ts);

            return res;
        }


    }


}
