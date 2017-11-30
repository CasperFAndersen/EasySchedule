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
        public ShiftElement(Shift shift, Color color, bool isLastElement)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = isLastElement;
            textBox.Background = new SolidColorBrush(color);
            SetCursor();
            button.Visibility = Visibility.Hidden;
        }

        public ShiftElement(Shift shift, string text, Color color)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = false;
            textBox.Background = new SolidColorBrush(color);
            textBox.Text = text;
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnShiftCloseClick(sender, (Shift)DataContext);
        }
    }
}
