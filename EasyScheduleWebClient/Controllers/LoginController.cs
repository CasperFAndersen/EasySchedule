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
            var emp1 = empProxy.GetEmployeeByUsername(loggingIn.Username);

            if (loggingIn.Password.Equals(emp1.Password))
            {
                Session["employee"] = emp1;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}