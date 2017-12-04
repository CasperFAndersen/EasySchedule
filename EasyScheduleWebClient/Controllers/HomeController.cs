using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyScheduleWebClient.Services;
using EasyScheduleWebClient.Models;
using Core;

namespace EasyScheduleWebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            //var model = empRepo.GetEmployeesByDepartmentId(Convert.ToInt32(Session["employeeId"].ToString()));
            //var model = empRepo.GetEmployeesByDepartmentId(Convert.ToInt32(Session["employeeId"].ToString()));
            return View();
        }

        public ActionResult GetEvents()
        {
            ScheduleProxy scheduleProxy = new ScheduleProxy();
            Core.Employee emp = (Core.Employee)Session["employee"];
            List<Core.ScheduleShift> shifts = scheduleProxy.GetScheduleByDepartmentIdAndDate(emp.DepartmentId, DateTime.Now).Shifts;

            return new JsonResult { Data = shifts, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SetShiftForSale(ScheduleShift scheduleShift)
        {
            return Json("Response");
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
