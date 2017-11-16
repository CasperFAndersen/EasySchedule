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
    /// Interaction logic for DayColumn.xaml
    /// </summary>
    public partial class DayColumn : UserControl
    {
        public DayColumn()
        {
            InitializeComponent();
        }

        public Grid GetGrid()
        {
            return DayColumnGrid;
        }

        public void BuildDayGrid(TimeSpan start, TimeSpan end, int increments)
        {
            TimeSpan timeCount = start;
            int rowCount = 0;
            while (timeCount <= end)
            {
                DayColumnGrid.RowDefinitions.Add(new RowDefinition());
                TimeCell tempTimeCell = new TimeCell() { Time = timeCount };
                TextBlock textBlock = new TextBlock() { Text = timeCount.ToString() };

                tempTimeCell.GetGrid().Children.Add(textBlock);
                DayColumnGrid.Children.Add(tempTimeCell);
                Grid.SetRow(tempTimeCell, rowCount);



                rowCount++;
                timeCount = timeCount.Add(new TimeSpan(0, increments, 0));

            }

        }
    }

}
