using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    
    public class TempSchedule
    {
        public int ID { get; set; }
        public int NoOfWeeks { get; set; }
        public string Name { get; set; }
        public List<TempShift> ListOfTempShift { get; }

        public TempSchedule(int numberOfWeeks, string name)
        {
            NoOfWeeks = numberOfWeeks;
            Name = name; 
        }
        public TempSchedule(int id, int numberOfWeeks, string name)
        {
            ID = id;
            NoOfWeeks = numberOfWeeks;
            Name = name;
        }

        public TempSchedule()
        {
        }

        public void AddTempShift(TempShift tShift)
        {
            ListOfTempShift.Add(tShift);
        }
    }
}
