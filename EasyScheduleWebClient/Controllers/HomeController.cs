using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Core;
using EasyScheduleWebClient.Services;
using EasyScheduleWebClient.Models;

namespace EasyScheduleWebClient.Controllers
{
    public class HomeController : Controller
    {
        readonly ScheduleShiftProxy _scheduleShiftProxy = new ScheduleShiftProxy();
        readonly ScheduleProxy _scheduleProxy = new ScheduleProxy();

        public ActionResult Index()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            if (Session["employee"] != null)
            {
                Employee employee = (Employee)Session["employee"];
                Department department = new DepartmentProxy().GetDepartmentById(employee.DepartmentId);
                employeeModel.Employee = employee;
                employeeModel.Department = department;
            }
            return View(employeeModel);
        }

        public ActionResult GetEvents()
        {
            ScheduleProxy scheduleProxy = new ScheduleProxy();
            Employee employee = (Employee)Session["employee"];
            try
            {
                List<ScheduleShift> shifts = scheduleProxy.GetScheduleByDepartmentIdAndDate(employee.DepartmentId, DateTime.Now).Shifts;
                return new JsonResult { Data = shifts, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public ActionResult GetShiftsByEmployee()
        {
            List<ScheduleShift> res = new List<ScheduleShift>();

            Employee employee = (Employee)Session["employee"];
            try
            {
                List<ScheduleShift> shifts = _scheduleProxy.GetScheduleByDepartmentIdAndDate(employee.DepartmentId, DateTime.Now).Shifts;
                res = shifts.Where(x => x.Employee.Name == employee.Name).ToList();
                return new JsonResult { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch (Exception e)
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
            Employee employee = (Employee)Session["employee"];
            _scheduleShiftProxy.AcceptAvailableShift(scheduleShift, employee);
            return null;
        }

        [HttpPost]
        public JsonResult SetShiftForSale(ScheduleShift scheduleShift)
        {
            scheduleShift.Employee = (Employee)Session["employee"];
            _scheduleShiftProxy.SetScheduleShiftForSale(scheduleShift);
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
