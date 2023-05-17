using System.Web;
using System.Web.Mvc;

namespace AzureB2C_WebApp_ASP.NETFramework_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
