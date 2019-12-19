using ASP_NET_MVC_First_Week_Homework.Models;
using Homework.Repository.Services;
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

            var result = new List<dailymoneylogViewModel>();

            using (var Srv = new AccountBookService())
            {
                var query = Srv.GetDataAll().ToList();
                int i = 1;
                foreach (var item in query)
                {
                    result.Add(new dailymoneylogViewModel(item)
                    {
                        SerialNumber = i
                    });
                    i++;
                }
            }
            result = result.OrderByDescending(x => x.Date).ToList();
            return View(result);
        }
    }
}