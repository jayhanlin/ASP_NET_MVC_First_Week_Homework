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
            var result = new List<dailymoneylogViewModel>();
            #region 亂數設定
            var random = new Random();
            #endregion
            #region 時間亂數設定
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(random.Next(range));
            }
            #endregion
            for (int i = 1; i < 101; i++)
            {
                var randomNum = random.Next(0, 10000);
                result.Add(new dailymoneylogViewModel
                {
                    //SerialNumber = (i %20>0 ) ? i % 20 : 20,
                    type = randomNum > 5000 ? "收入" : "支出",
                    date = RandomDay(),//格式化
                    Amount = randomNum//格式化
                });
                //foreach (var item in result)
                //{
                //    item.SerialNumber = (i % 20 != 0) ? i & 20 : 20;
                //    item.type = randomNum > 500 ? "收入" : "支出";
                //    item.date = RandomDay();
                //    item.Amount = randomNum;
                //    result.Add(item);
                //}
            }
            result = result.OrderByDescending(x => x.date).ToList();

            return View(result);
        }
    }
}