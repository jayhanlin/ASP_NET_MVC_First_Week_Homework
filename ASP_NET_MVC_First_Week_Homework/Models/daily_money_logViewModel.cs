using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_First_Week_Homework.Models
{
    public class daily_money_logViewModel
    {
        public int SerialNumber { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public int money { get; set; }
    }
}