using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Core;

namespace DesktopClient.Views.ScheduleViews
{
    /// <summary>
    /// Interaction logic for ShiftElement.xaml
    /// </summary>
    public partial class ScheduleShiftElement : UserControl
    {
        public bool IsFirstElement { get; set; }
        public bool IsLastElement { get; set; }
        public ScheduleShiftElement(TemplateShift shift, Color color, bool isLastElement)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = isLastElement;
            TextBox.Background = new SolidColorBrush(color);
            SetCursor();
            Button.Visibility = Visibility.Hidden;
        }

        public ScheduleShiftElement(TemplateShift shift, string text, Color color)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = false;
            TextBox.Background = new SolidColorBrush(color);
            TextBox.Text = text;
            SetCursor();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData("IsLastShiftElement", IsLastElement);
                data.SetData("Object", DataContext);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        public void SetCursor()
        {
            if (IsLastElement)
            {
                Grid.Cursor = Cursors.SizeNS;
            }
            else
            {
                Grid.Cursor = Cursors.Hand;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnShiftCloseClick(sender, (TemplateShift)DataContext);
        }
    }
}
