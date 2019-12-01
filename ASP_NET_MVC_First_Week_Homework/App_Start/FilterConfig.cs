using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_First_Week_Homework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
