using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EasyScheduleWebClient.Models;
using Core;
using EasyScheduleWebClient.Services;

namespace EasyScheduleWebClient.Controllers
{
    public class AvailableShiftsController : Controller
    {
        public List<int> test { get; set; }
        // GET: AvailableShifts
        public ActionResult Index()
        {

            if (Session["employee"] != null)
            {
                Employee employee = new Employee();
                employee = (Employee)Session["employee"];

                ScheduleProxy scheduleProxy = new ScheduleProxy();
                var shifts = scheduleProxy.GetAllAvailableShiftsByDepartmentId(employee.DepartmentId);


                var model = from s in shifts
                    orderby s.StartTime
                    select s;

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
       
        }

       [HttpPost]
        public ActionResult AcceptShift(ScheduleShift scheduleShift)
        {
            Employee employee = new Employee();
            employee = (Employee)Session["employee"];

            ScheduleProxy scheduleProxy = new ScheduleProxy();
            scheduleProxy.AcceptAvailableShift(scheduleShift, employee);
            
            return RedirectToAction("Index", "AvailableShifts");
        }
    }
}