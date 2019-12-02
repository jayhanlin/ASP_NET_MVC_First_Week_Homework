using ASP_NET_MVC_First_Week_Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_First_Week_Homework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Homework()
        {
            //TODO
            //隨機產生在這
            var qwe = new daily_money_logViewModel();
            qwe.SerialNumber = 
            return View();
        }
    }
}