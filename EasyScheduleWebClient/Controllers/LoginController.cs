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
        public ActionResult Authorize(Employee loggingIn)
        {
            EmployeeProxy empProxy = new EmployeeProxy();
            var emp = empProxy.GetEmployeeByUsername(loggingIn.Username);

            if (loggingIn.Password.Equals(emp.Password))
            {
                Session["employee"] = emp;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Logout()
        {
            //int id = (int)Session["employeeId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}