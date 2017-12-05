using System.Web.Mvc;
using EasyScheduleWebClient.Models;
using EasyScheduleWebClient.Services;
using Core;

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
                Employee emp = empProxy.ValidatePassword(loggingIn.Username, loggingIn.Password);
                Session["employee"] = emp;
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception)
            {
                ModelState.AddModelError("", "Wrong username or password");
                return RedirectToAction("Index", "Login");
            }

         
        }

        public ActionResult Logout()
        {
            //int id = (int)Session["employeeId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}