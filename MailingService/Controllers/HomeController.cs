using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MailingService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
<<<<<<< HEAD
            ViewBag.Message = "Det løgn";
=======
            ViewBag.Message = "Arne er sej!";
>>>>>>> bc9546bdc1d8ad33a40040c70abc3d2c146d5766

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}