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
            //List SNList= new List<SerialNumber>
            var result = new List<daily_money_logViewModel>();
            for (int i = 1; i <= 101; i++)
            {
                
                result.Add()
                result.SerialNumber = i % 20;
                result.type = "good";
                result.date = DateTime.Now;
                result.Amount = 100;
            }
            //result.date = DateTime.Now;
            //result.SerialNumber = 5;
            //var random = new Random(Guid.NewGuid().GetHashCode());
            //result.type = random.NextDouble() > 0.5 ? "支出" : "收入";
            //result.Amount = 5000;
        

            return View(result);
        }
    }
}