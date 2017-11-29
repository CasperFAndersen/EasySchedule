using Core;
using DesktopClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DesktopClient
{
    public class EmployeeColors
    {
        public static Dictionary<string, Color> EmpColors { get; set; }
        Random rnd = new Random();
        Color[] colors = { Colors.IndianRed, Colors.DarkKhaki, Colors.DarkOrange, Colors.LightGreen, Colors.Thistle, Colors.SkyBlue, Colors.RoyalBlue, Colors.Turquoise };


        public EmployeeColors()
        {
            EmpColors = new Dictionary<string, Color>();
            LoadEmployeeColors();
        }

        private async void LoadEmployeeColors()
        {
            EmpColors = new Dictionary<string, Color>();
            List<Employee> employees = await new EmployeeProxy().GetAllEmployeesAsync();
            foreach (var emp in employees)
            {
                EmpColors.Add(emp.Name, Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));

            };
        }

        public Color GetRandomColor()
        {
            Color color = colors[rnd.Next(colors.Length)];
            bool isUniqeColorFound = false;
            while (!isUniqeColorFound)
            {
                if (!EmpColors.Values.Contains(color))
                {
                    isUniqeColorFound = true;
                }
                else
                {
                    color = colors[rnd.Next(colors.Length)];
                }
            }
            return color;
        }
    }
}
