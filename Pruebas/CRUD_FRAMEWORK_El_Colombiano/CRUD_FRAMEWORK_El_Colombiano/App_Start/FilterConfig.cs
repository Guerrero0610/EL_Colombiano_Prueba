using System.Web;
using System.Web.Mvc;

namespace CRUD_FRAMEWORK_El_Colombiano
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
