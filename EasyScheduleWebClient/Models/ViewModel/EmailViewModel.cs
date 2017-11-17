using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyScheduleWebClient.Models.ViewModel
{
    public class EmailViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}