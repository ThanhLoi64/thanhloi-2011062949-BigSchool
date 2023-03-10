using System.Web;
using System.Web.Mvc;

namespace thanhloi_2011062949
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
