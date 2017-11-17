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

        Color[] colors = { Colors.IndianRed, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.Thistle, Colors.SkyBlue, Colors.RoyalBlue, Colors.Turquoise };
        public static Dictionary<Employee, Color> EmployeeColors { get; set; }

        Random rnd = new Random();

        public List<DayColumn> DayColumnList { get; set; }
        public List<TemplateShift> Shifts { get; set; }
        public Calendar()
        {
            InitializeComponent();
            DayColumnList = new List<DayColumn>();
            Shifts = new List<TemplateShift>();
            BuildTimesGrid();
            BuildDayColumns();
            EmployeeColors = new Dictionary<Employee, Color>();
            AddShifts(GetListOfTemplateShifts());
            SetShiftDropHandler();
            SetCloseShiftClicked();
            SetEmployeeDroppedHandler();
            LoadShiftsIntoCalendar();
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
                Border border = new Border() { BorderBrush = new SolidColorBrush(Colors.Black), BorderThickness = new Thickness(0.5,0.5,0.5,0.5)};
                border.Background = new SolidColorBrush(Colors.LightGray);
                TextBlock textBlock = new TextBlock() { Text = timeCount.ToString().Substring(0,5), FontSize = 14, FontWeight = FontWeights.Bold};
                textBlock.Margin = new Thickness(0,-2,5,0);
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
            int row = 1; int col = 1;
            int day = 1;
            while (day <6)
            {
                string name = Enum.GetName(typeof(DayOfWeek), day);
                DayColumn dayCol = new DayColumn((DayOfWeek)day) {Name = name };
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
                LoadShiftsIntoCalendar();
            };
        }

        public void SetEmployeeDroppedHandler()
        {
            Mediator.GetInstance().EmployeeDropped += (s, e) =>
            {
                AddShift(e.Shift);
                LoadShiftsIntoCalendar();
            };
        }

        public void SetCloseShiftClicked()
        {
            Mediator.GetInstance().ShiftCloseClicked+= (s, e) =>
            {
                Shifts.Remove(e.Shift);
                LoadShiftsIntoCalendar();
            };
        }

        public Color GetRandomColor()
        {
            return colors[rnd.Next(colors.Length)];
        }

        public List<TemplateShift> GetListOfTemplateShifts()
        {
            List<TemplateShift> res = new List<TemplateShift>();
            TemplateShift ts1 = new TemplateShift() { StartTime = new TimeSpan(10, 0, 0),WeekDay = DayOfWeek.Thursday, Employee = new Employee() { Name = "Hanne" }, Hours =3 };
            TemplateShift ts2= new TemplateShift() { StartTime = new TimeSpan(10, 0, 0), WeekDay = DayOfWeek.Monday, Employee = new Employee() { Name = "Ole" }, Hours = 6};
            TemplateShift ts3 = new TemplateShift() { StartTime = new TimeSpan(10, 0, 0),WeekDay = DayOfWeek.Wednesday, Employee = new Employee() { Name = "Bendy" }, Hours = 4 };

            res.Add(ts1);
            res.Add(ts2);
            res.Add(ts3);

            return res;
        }



    }
}
