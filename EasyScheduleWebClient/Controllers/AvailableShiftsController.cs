using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core;
using EasyScheduleWebClient.Services;

namespace EasyScheduleWebClient.Controllers
{
    public class AvailableShiftsController : Controller
    {
        ScheduleShiftProxy scheduleShiftProxy = new ScheduleShiftProxy();

        // GET: AvailableShifts
        public ActionResult Index()
        {
            if (Session["employee"] != null)
            {
                Employee employee = new Employee();
                employee = (Employee)Session["employee"];
                     
                var shifts = scheduleShiftProxy.GetAllAvailableShiftsByDepartmentId(employee.DepartmentId);

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

            scheduleShiftProxy.AcceptAvailableShift(scheduleShift, employee);

            return RedirectToAction("Index", "AvailableShifts");
        }
    }
}