using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyScheduleWebClient.Models
{
    public class Email
    {
        public int EmailID { get; set; }
        public string RecieverEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}