using System.Web;
using System.Web.Mvc;
using GraduateManagement.Attribute;

namespace GraduateManagement
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorityFilter());
        }
    }
}
