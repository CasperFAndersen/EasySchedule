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

namespace DesktopClient.Views.Schedule
{
    /// <summary>
    /// Interaction logic for ScheduleCalendar.xaml
    /// </summary>
    public partial class ScheduleCalendar : UserControl
    {
        public ScheduleCalendar()
        {
            InitializeComponent();
            DayColumnList = new List<DayColumn>();
            Shifts = new List<Shift>();
            WeekNumber = 1;
            btnNextWeek.IsEnabled = false;
            btnPrevWeek.IsEnabled = false;
            BuildTimesGrid();
            BuildDayColumns();
            EmployeeColors = new Dictionary<Employee, Color>();
            BuildDateBoxes();


            

            //    SetShiftDropHandler();
            //    SetCloseShiftClicked();
            //    SetEmployeeDroppedHandler();
            //    SetTemplateScheduleSelected();
            //    LoadShiftsIntoCalendar();
            //    SetTemplateScheduleUpdateClicked();
            //    SetCreateTemplateScheduleClicked();
            //    SetOnNumOfWeeksBoxChanged();
        }
        public static readonly TimeSpan STARTTIME = new TimeSpan(6, 0, 0);
        public static readonly TimeSpan ENDTIME = new TimeSpan(20, 0, 0);
        public static readonly int INCREMENT = 30;

        Color[] colors = { Colors.IndianRed, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.Thistle, Colors.SkyBlue, Colors.RoyalBlue, Colors.Turquoise };
        public static Dictionary<Employee, Color> EmployeeColors { get; set; }

        Random rnd = new Random();
        private int numOfWeeks = 1;
        public List<DayColumn> DayColumnList { get; set; }
        public List<Shift> Shifts { get; set; }
        public static int WeekNumber { get; set; }


        //private void AddShifts(List<Shift> list)
        //{
        //    list.ForEach(x => Shifts.Add(x));
        //    Shifts.ForEach(x => EmployeeColors.Add(x.Employee, GetRandomColor()));
        //}

        //public void AddShift(Shift shift)
        //{

        //    if (!EmployeeColors.ContainsKey(shift.Employee))
        //    {
        //        EmployeeColors.Add(shift.Employee, GetRandomColor());
        //    }
        //    Shifts.Add(shift);

        //}

        //public void LoadShiftsIntoCalendar()
        //{
        //    foreach (var shift in Shifts)
        //    {
        //        if (shift.StartTime. == Convert.ToInt32(txtWeekNum.Text))
        //        {
        //            DayColumn dayCol = GetDayCoulmByName(shift.WeekDay.ToString());
        //            dayCol.InsertShiftIntoDay(shift);
        //        }

        //    }

        //}

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

                //NavCalendar.SelectedDates.Add(date.AddDays(day));
                
                day++;
                col++;


            }
        }



        private void NavCalendar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            DateTime selectedDate = (DateTime)NavCalendar.SelectedDate;
            selectedDate = new DateTime(selectedDate.Year, selectedDate.Month, (int)NavCalendar.FirstDayOfWeek);
            for (int i = 0; i < 5; i++)
            {
                NavCalendar.SelectedDates.Add(selectedDate.AddDays(i));
            }
        }

        //    public void SetShiftDropHandler()
        //    {
        //        Mediator.GetInstance().ShiftDropped += (s, e) =>
        //        {
        //            LoadShiftsIntoCalendar();
        //        };
        //    }

        //    public void SetEmployeeDroppedHandler()
        //    {
        //        Mediator.GetInstance().EmployeeDropped += (s, e) =>
        //        {
        //            e.Shift.WeekNumber = WeekNumber;
        //            AddShift(e.Shift);
        //            LoadShiftsIntoCalendar();
        //        };
        //    }

        //    public void SetCloseShiftClicked()
        //    {
        //        Mediator.GetInstance().ShiftCloseClicked += (s, e) =>
        //        {
        //            Shifts.Remove(e.Shift);
        //            LoadShiftsIntoCalendar();
        //        };
        //    }

        //    public void SetTemplateScheduleSelected()
        //    {
        //        Mediator.GetInstance().TempScheduleSelected += (s, e) =>
        //        {
        //            Shifts.Clear();
        //            EmployeeColors.Clear();
        //            AddShifts(e.TempSchedule.ListOfTempShifts);
        //            if (e.TempSchedule.NoOfWeeks > 1)
        //            {
        //                btnNextWeek.IsEnabled = true;
        //            }
        //            numOfWeeks = e.TempSchedule.NoOfWeeks;
        //            LoadShiftsIntoCalendar();
        //        };
        //    }

        //    private void SetTemplateScheduleUpdateClicked()
        //    {
        //        Mediator.GetInstance().TempScheduleUpdateClicked += (s, e) =>
        //        {
        //            e.TempSchedule.ListOfTempShifts = Shifts;
        //            TempScheduleProxy tempScheduleProxy = new TempScheduleProxy();
        //            tempScheduleProxy.UpdateTemplateSchedule(e.TempSchedule);
        //        };
        //    }

        //    private void SetCreateTemplateScheduleClicked()
        //    {
        //        Mediator.GetInstance().CreateTemplateScheduleButtonClicked += (t) =>
        //        {
        //            if (Shifts.Count == 0)
        //            {
        //                MessageBox.Show("No shifts has been added!");
        //            }
        //            else
        //            {
        //                TempScheduleProxy tempScheduleProxy = new TempScheduleProxy();
        //                t.ListOfTempShifts = Shifts;
        //                tempScheduleProxy.AddTempScheduleToDB(t);
        //                Shifts.Clear();
        //                MessageBox.Show("Template schedule is now saved onto database");
        //            }

        //        };

        //    }

        //    private void SetOnNumOfWeeksBoxChanged()
        //    {

        //        Mediator.GetInstance().NumOfWeekBoxChanged += (n, b, p) =>
        //        {
        //            numOfWeeks = n;
        //            if (numOfWeeks > WeekNumber)
        //            {
        //                btnNextWeek.IsEnabled = true;
        //            }
        //            else if (numOfWeeks == WeekNumber)
        //            {
        //                btnNextWeek.IsEnabled = false;
        //            }
        //            else if (n < WeekNumber)
        //            {
        //                btnNextWeek.IsEnabled = false;
        //                bool noShiftsWillBeLost = Shifts.TrueForAll(x => x.WeekNumber < n);
        //                if (!noShiftsWillBeLost)
        //                {
        //                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Shifts placed in higher week numbers will be lost. Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
        //                    if (messageBoxResult == MessageBoxResult.Yes)
        //                    {
        //                        Shifts.RemoveAll(x => x.WeekNumber > n);
        //                        txtWeekNum.Text = n.ToString();
        //                        WeekNumber = n;
        //                        btnNextWeek.IsEnabled = false;
        //                        Clear();
        //                        LoadShiftsIntoCalendar();
        //                    }
        //                    else if (messageBoxResult == MessageBoxResult.No)
        //                    {
        //                        b.SelectedIndex = p;
        //                    }
        //                }
        //                else
        //                {
        //                    WeekNumber = n;
        //                    txtWeekNum.Text = n.ToString();
        //                }
        //                if (n == 1)
        //                {
        //                    btnPrevWeek.IsEnabled = false;
        //                }



        //            }
        //        };
        //    }


        //    public Color GetRandomColor()
        //    {
        //        return colors[rnd.Next(colors.Length)];
        //    }

        //    private void NextWeek_Click(object sender, RoutedEventArgs e)
        //    {
        //        if (WeekNumber < numOfWeeks)
        //        {
        //            WeekNumber++;
        //            txtWeekNum.Text = WeekNumber.ToString();
        //            Clear();
        //            btnPrevWeek.IsEnabled = true;
        //            if (WeekNumber == numOfWeeks)
        //            {
        //                btnNextWeek.IsEnabled = false;
        //            }
        //            LoadShiftsIntoCalendar();
        //        }

        //    }


        //    private void PrevWeek_Click(object sender, RoutedEventArgs e)
        //    {
        //        if (WeekNumber != 1)
        //        {
        //            WeekNumber--;
        //            txtWeekNum.Text = WeekNumber.ToString();
        //            Clear();
        //            LoadShiftsIntoCalendar();
        //            if (WeekNumber == 1)
        //            {
        //                btnPrevWeek.IsEnabled = false;
        //            }
        //            btnNextWeek.IsEnabled = true;
        //        }

        //    }

        //    public void Clear()
        //    {
        //        DayColumnList.ForEach(x => x.Clear());
        //    }
        //}
    }
}
