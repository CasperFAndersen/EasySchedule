using System.Web.Mvc;
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

        public ActionResult LoginUser(string username)
        {
            EmployeeProxy empProxy = new EmployeeProxy();

            Employee e1 = empProxy.GetEmployeeByUsername(username);

            if (e1 != null)
            {
                Session["Employee"] = e1;
                string tem = Session["Employee"].ToString();
                //return View("~/Views/Home/Index.html");
            }

            return null;
        }
    }
}