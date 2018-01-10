using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core;
using EasyScheduleWebClient.Services;
using System;

namespace EasyScheduleWebClient.Controllers
{
    public class AvailableShiftsController : Controller
    {
        private readonly ScheduleShiftProxy _scheduleShiftProxy = new ScheduleShiftProxy();

        // GET: AvailableShifts
        public ActionResult Index()
        {
            if (Session["employee"] != null)
            {
                Employee employee = new Employee();
                employee = (Employee)Session["employee"];
                     
                List<ScheduleShift> shifts = _scheduleShiftProxy.GetAllAvailableShiftsByDepartmentId(employee.DepartmentId).ToList();

                foreach (var s in shifts)
                {
                    s.RowVersion = null;
                }

                var model = from s in shifts
                            orderby s.StartTime
                            select s;

                return View(model);
            }
            return RedirectToAction("Index", "Login");
        }
        
        public ActionResult AcceptShift(ScheduleShift scheduleShift)
        {
            Employee employee = (Employee)Session["employee"];

            _scheduleShiftProxy.AcceptAvailableShift(scheduleShift, employee);

            return RedirectToAction("Index", "AvailableShifts");
        }
    }
}