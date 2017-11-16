using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyScheduleWebClient.Services;


namespace EasyScheduleWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            var model = empRepo.GetEmployees();
            return View(model);
        }

        public ActionResult GetEvents()
        {
            EventRepository eventRepo = new EventRepository();
            List<Event> events = eventRepo.GetEvents().ToList();
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult SaveEvent(Event e)
        {
            System.Diagnostics.Debug.WriteLine(e.Subject);
            System.Diagnostics.Debug.WriteLine(e.Start);
            System.Diagnostics.Debug.WriteLine(" " + e.End);
            return null;
        }


    }
}
