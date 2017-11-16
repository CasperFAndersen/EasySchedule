using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [DataContract]
    public class TemplateShift
    {
        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public int Hours { get; set; }

        [DataMember]
        public Employee Employee { get; set; }

        public TemplateShift()
        {

        }

    }
}
