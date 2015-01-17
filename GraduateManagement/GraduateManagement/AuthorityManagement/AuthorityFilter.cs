using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduateManagement.Models;

namespace GraduateManagement.Attributes
{
    public class AuthorityFilter : System.Web.Mvc.AuthorizeAttribute
    {
        public ICollection<AR> ARs { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.User.Identity.Name == string.Empty)
                return false;
            if (httpContext == null)
                throw new ArgumentException("HttpContext");
            if (ARs.Count() == 0)
                return true;
            role role = new AuthorityHelper().getRole(httpContext.User.Identity.Name);
            if (ARs.Any(r => r.roleID == role.ID))
                return true;
            httpContext.Response.Redirect("~/Shared/Error");
            return false;
        }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            ARs = new AuthorityHelper().getContainRoles(controllerName, actionName);
            base.OnAuthorization(filterContext);
        }
    }
}