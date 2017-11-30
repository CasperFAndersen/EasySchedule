using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [DataContract]
    public class ScheduleShift : Shift
    {
        [DataMember]
        public DateTime StartTime { get; set; }

        public ScheduleShift()
        {
            
        }
    }
}
