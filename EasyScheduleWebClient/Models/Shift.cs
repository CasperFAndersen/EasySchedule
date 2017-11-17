using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyScheduleWebClient.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public double Hours { get; set; }
        public Employee Employee { get; set; }
    
    }
}
