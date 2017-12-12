using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Core;
using EasyScheduleWebClient.Services;

namespace EasyScheduleWebClient.Controllers
{
    public class HomeController : Controller
    {
        ScheduleShiftProxy scheduleShiftProxy = new ScheduleShiftProxy();
        ScheduleProxy scheduleProxy = new ScheduleProxy();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEvents()
        {
            ScheduleProxy scheduleProxy = new ScheduleProxy();
            Employee emp = (Employee)Session["employee"];
            try
            {
                List<ScheduleShift> shifts = scheduleProxy.GetScheduleByDepartmentIdAndDate(emp.DepartmentId, DateTime.Now).Shifts;
                return new JsonResult { Data = shifts, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception)
            {

            }
            return null;
        }

        public ActionResult GetShiftsByEmployee()
        {
            List<ScheduleShift> res = new List<ScheduleShift>();

            Employee emp = (Employee)Session["employee"];
            try
            {
                List<ScheduleShift> shifts = scheduleProxy.GetScheduleByDepartmentIdAndDate(emp.DepartmentId, DateTime.Now).Shifts;
                res = shifts.Where(x => x.Employee.Name == emp.Name).ToList();
                return new JsonResult { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            catch (Exception)
            {

            }
            return null;
        }

        public ActionResult GetLoggedInEmployee()
        {
            if ((Employee)Session["employee"] != null)
            {
                return new JsonResult { Data = (Employee)Session["employee"], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return null;
        }

        [HttpPost]
        public ActionResult AcceptShift(ScheduleShift scheduleShift)
        {
            Employee employee = new Employee();
            employee = (Employee)Session["employee"];

         
            scheduleShiftProxy.AcceptAvailableShift(scheduleShift, employee);

            return null;
        }

        [HttpPost]
        public JsonResult SetShiftForSale(ScheduleShift scheduleShift)
        {
  
            scheduleShift.Employee = (Employee)Session["employee"];
            scheduleShiftProxy.SetScheduleShiftForSale(scheduleShift);
            return null;
        }

        [HttpPost]
        public ActionResult SaveEvent(Event e)
        {
            Debug.WriteLine(e.Subject);
            Debug.WriteLine(e.Start);
            Debug.WriteLine(" " + e.End);
            return null;
        }


    }


}
