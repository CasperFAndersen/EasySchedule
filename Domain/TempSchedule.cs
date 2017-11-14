using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [DataContract]
    public class TempSchedule
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int NoOfWeeks { get; set; }
        [DataMember]
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
