using System.Web;
using System.Web.Mvc;

namespace W2022A3PGBNGUYEN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
