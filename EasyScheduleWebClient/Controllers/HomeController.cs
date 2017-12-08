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

        public ActionResult GetShiftsByEmployee()
        {
            List<ScheduleShift> res = new List<ScheduleShift>();
            ScheduleProxy scheduleProxy = new ScheduleProxy();
            Core.Employee emp = (Core.Employee)Session["employee"];
            List<Core.ScheduleShift> shifts = scheduleProxy.GetScheduleByDepartmentIdAndDate(emp.DepartmentId, DateTime.Now).Shifts;
            res = shifts.Where(x => x.Employee.Name == emp.Name).ToList();

            return new JsonResult { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }



        public ActionResult GetLoggedInEmployee()
        {
            if ((Core.Employee)Session["employee"] != null)
            {
                return new JsonResult { Data = (Core.Employee)Session["employee"], JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return null;
           
        }

        [HttpPost]
        public ActionResult AcceptShift(ScheduleShift scheduleShift)
        {
            Employee employee = new Employee();
            employee = (Employee)Session["employee"];

            ScheduleProxy scheduleProxy = new ScheduleProxy();
            scheduleProxy.AcceptAvailableShift(scheduleShift, employee);

            return null;
        }

        [HttpPost]
        public JsonResult SetShiftForSale(ScheduleShift scheduleShift)
        {
            ScheduleProxy scheduleProxy = new ScheduleProxy();
            scheduleShift.Employee = (Employee) Session["employee"];
            scheduleProxy.SetScheduleShiftForSale(scheduleShift);
            return null;
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
