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
    /// Interaction logic for ShiftElement.xaml
    /// </summary>
    public partial class ShiftElement : UserControl
    {
        public bool IsFirstElement { get; set; }
        public bool IsLastElement { get; set; }
        public ShiftElement(TemplateShift shift, Color color)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = false;
            textBox.Background = new SolidColorBrush(color);
            button.Visibility = Visibility.Hidden;
        }

        public ShiftElement(TemplateShift shift, string text, Color color)
        {
            InitializeComponent();
            DataContext = shift;
            IsLastElement = false;
            textBox.Background = new SolidColorBrush(color);
            textBox.Text = text;

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Mediator.GetInstance().OnShiftCloseClick(sender, (TemplateShift)DataContext);
        }
    }
}
