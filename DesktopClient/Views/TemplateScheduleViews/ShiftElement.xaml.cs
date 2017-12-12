using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Core;

namespace DesktopClient.Views.TemplateScheduleViews
{
    public partial class ShiftElement : UserControl
    {
        public bool IsFirstElement { get; set; }
        public bool IsLastElement { get; set; }
        public TimeCell RootTimeCell { get; set; }
        public ShiftElement(Shift shift, Color color, bool isLastElement)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = isLastElement;
            ElementBorder.Background = new SolidColorBrush(color);
            //ElementGrid.Background = new SolidColorBrush(color);
            SetCursor();
            ElementBorder.Effect = null;
            ElementBorder.BorderBrush = null;
            button.Visibility = Visibility.Hidden;
        }

        public ShiftElement(Shift shift, Color color)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = false;
            ElementBorder.Background = new SolidColorBrush(color);
            // ElementGrid.Background = new SolidColorBrush(color);
            SetTextHeader(shift);
            SetCursor();

        }


        public void AddButtom(ShiftElement shiftElement)
        {
            shiftElement.ElementBorder.Effect = null;
            ElementGrid.Children.Add(shiftElement);
            Grid.SetRow(shiftElement, 3);
        }

        private void SetTextHeader(Shift shift)
        {
            ScheduleShift scheduleShift = null;
            TemplateShift templateShift = null;
            if (shift.GetType() == typeof(ScheduleShift))
            {
                scheduleShift = (ScheduleShift)shift;
                textBox1.Text = scheduleShift.Employee.Name;
                textBox2.Text = scheduleShift.StartTime.ToShortTimeString() + " - " + scheduleShift.StartTime.AddHours(scheduleShift.Hours).ToShortTimeString();
            }
            else
            {
                templateShift = (TemplateShift)shift;
                int minutes = (int)(60 * (templateShift.Hours - (int)templateShift.Hours));
                DateTime startTime = new DateTime(2017, 1, 1, templateShift.StartTime.Hours, templateShift.StartTime.Minutes, 0);
                DateTime endTime = startTime.AddHours(templateShift.Hours);

                textBox1.Text = templateShift.Employee.Name; //+ " : " + startTime.ToShortTimeString() + " - " + endTime.ToShortTimeString();
                textBox2.Text = startTime.ToShortTimeString() + " - " + endTime.ToShortTimeString();

            }
        }



        public void SetCursor()
        {
            if (IsLastElement)
            {
                ElementGrid.Cursor = Cursors.SizeNS;
            }
            else
            {
                ElementGrid.Cursor = Cursors.Hand;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnShiftCloseClick(sender, (Shift)DataContext);
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                Mediator.GetInstance().OnResizeStarted();
             
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("IsLastShiftElement", IsLastElement);
                data.SetData("Object", DataContext);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (RootTimeCell != null)
            {
                Grid.SetZIndex(RootTimeCell, 700);
            }
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            if (RootTimeCell != null)
            {
                Grid.SetZIndex(RootTimeCell, 600);
            }

        }

        private void UserControl_DragOver(object sender, DragEventArgs e)
        {
            if (RootTimeCell != null)
            {
                Grid.SetZIndex(RootTimeCell, 0);
            }
        }
    }
}
