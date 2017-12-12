using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Core;

namespace DesktopClient.Views
{
    /// <summary>
    /// Interaction logic for EmployeeListItem.xaml
    /// </summary>
    public partial class EmployeeListItem : UserControl
    {
        public EmployeeListItem(Employee employee)
        {
            InitializeComponent();
            DataContext = employee;
       
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Mediator.GetInstance().OnResizeStarted();
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, DataContext);
                // data.SetData("Double", circleUI.Height);
                data.SetData("Object", DataContext);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
