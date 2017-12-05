using System.Web.Mvc;
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
            var emp = empProxy.GetEmployeeByUsername(loggingIn.Username);

            
            if (empProxy.ValidatePassword(loggingIn.Username, loggingIn.Password))
            {
                Session["employee"] = emp;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Wrong username or password");
            }
            return View(loggingIn); 
        }

        public ActionResult Logout()
        {
            //int id = (int)Session["employeeId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}