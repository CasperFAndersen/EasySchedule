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
        public ActionResult Authorize(Employee employee)
        {
            EmployeeProxy empProxy = new EmployeeProxy();
            var emp1 = empProxy.GetEmployeeByUsername(employee.Username);
            Employee e1 = new Employee();

            e1.Username = emp1.Username;
            e1.Password = emp1.Password;

            if(e1.Username == null)
            {

            }
            


            return View();
        }
    }
}