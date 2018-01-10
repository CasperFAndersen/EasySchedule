using System;
using System.Web.Mvc;
using Core;
using EasyScheduleWebClient.Models;
using EasyScheduleWebClient.Services;

namespace EasyScheduleWebClient.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(EmployeeModel loggingIn)
        {
            EmployeeProxy empProxy = new EmployeeProxy();
            
            try
            {
                Employee employee = empProxy.ValidatePassword(loggingIn.Username, loggingIn.Password);
                Session["employee"] = employee;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Wrong username or password");
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}