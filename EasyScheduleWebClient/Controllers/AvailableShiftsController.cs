using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyScheduleWebClient.Controllers
{
    public class AvailableShiftsController : Controller
    {
        public List<int> test { get; set; }
        // GET: AvailableShifts
        public ActionResult Index()
        {
            ServiceLibrary.Schedules.ScheduleService scheduleService = new ServiceLibrary.Schedules.ScheduleService();
            
            
            return View();
        }

        


    }
}