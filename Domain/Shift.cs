using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Shift
    {
        public DateTime StartTime { get; set; }
        public int Hours { get; set; }
        public Employee Employee { get; set; }

        public Shift()
        {

        }

    }
}
