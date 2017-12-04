using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace EasyScheduleWebClient.Models
{
    public class ShiftModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Hours { get; set; }
        public Employee Employee { get; set; }
        public bool IsForSale { get; set; }
    }
}