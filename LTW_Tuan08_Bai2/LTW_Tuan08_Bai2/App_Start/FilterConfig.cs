using System.Web;
using System.Web.Mvc;

namespace LTW_Tuan08_Bai2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}