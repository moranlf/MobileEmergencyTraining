using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MobileBasedTrainingServer.Models;

namespace MobileBasedTrainingServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Mobile Based Emergency Training";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Humanitarian Toolbox - Mobile Based Emergency Training.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}