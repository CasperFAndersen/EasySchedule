using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Schedule
    {
        public DateTime StartDate { get; set; }
        public List<TemplateShift> Shifts { get; set; }

        public Schedule()
        {

        }
    }
}
