using System.Web;
using System.Web.Mvc;

namespace LTW_Tuan10_BT9
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}