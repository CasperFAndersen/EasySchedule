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
using Core;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for TimeCell.xaml
    /// </summary>
    public partial class TimeCell : UserControl
    {
        public List<TemplateShift> ShiftsInCell { get; set; }
        public TimeSpan Time { get; set; }
        public TimeCell()
        {
            InitializeComponent();
        }

        public Grid GetGrid()
        {
            return TimeCellGrid;
        }

        public void SetToolTipText(string text)
        {
            TimeCellGrid.ToolTip = text;
        }


        public void FillCell(TemplateShift shift, bool isFirstElement, bool isLastElement)
        {
            Color color = Colors.RoyalBlue;
            ShiftElement shiftElement = null;
            if (isFirstElement)
            {
                //shiftElement = new ShiftElement(shift, shift.Employee.Name, color);
            }
            else
            {
                shiftElement = new ShiftElement(shift, color);
                shiftElement.IsLastElement = true;
            }

            TimeCellGrid.ColumnDefinitions.Add(new ColumnDefinition());

            TimeCellGrid.Children.Add(shiftElement);
            Grid.SetColumn(shiftElement, ShiftsInCell.Count);

            ShiftsInCell.Add(shift);

        }

    }
}
