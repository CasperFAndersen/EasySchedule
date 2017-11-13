using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    
    public class TempSchedule
    {
        public int NoOfWeeks { get; set; }
        public string Name { get; set; }
        public List<TempShift> ListOfTempShift { get; }

        public TempSchedule(int numberOfWeeks, string name)
        {
            NoOfWeeks = numberOfWeeks;
            Name = name; 
        }

        public void AddTempShift(TempShift tShift)
        {
            ListOfTempShift.Add(tShift);
        }
    }
}
