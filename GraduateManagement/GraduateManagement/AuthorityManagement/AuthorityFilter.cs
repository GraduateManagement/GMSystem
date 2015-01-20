using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraduateManagement.Models;

namespace GraduateManagement.Attributes
{
    public class AuthorityFilter : System.Web.Mvc.AuthorizeAttribute
    {
        private SqlDbContext db = new SqlDbContext();
        private ICollection<AR> containedARs { get; set; }

        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (filterContext.ActionDescriptor.ActionName == "Login" ||
                filterContext.ActionDescriptor.ActionName == "ForgotPassword")
                return;
            this.containedARs = this.getContainedRoles(controllerName);
            authorityJudge(filterContext.RequestContext.HttpContext.Request.Cookies["userName"], filterContext.HttpContext);
        }

        #region Helpers
        protected void authorityJudge(HttpCookie cookie, HttpContextBase httpContext)
        {
            if (containedARs.Count() == 0)
                return;
            if (cookie != null)
            {
                int roleID = this.getRoleID(cookie.Value);
                if (containedARs.Any(r => r.roleID == roleID))
                    return;
                httpContext.Response.Redirect("~/Home/Error");
                httpContext.Response.End();
            }
            else
            {
                string returnUrl = httpContext.Request.Url.AbsolutePath;
                string Url = "~/Account/Login?returnUrl=" + returnUrl;
                httpContext.Response.Redirect(Url);
                httpContext.Response.End();
            }
        }

        protected int getRoleID(string accountNum)
        {
            int role = db.user_table.Single(a => a.accountNum == accountNum).roleID;
            return db.role_table.Single(a => a.ID == role).ID;
        }

        protected int getAuthorityID(string controllerName)
        {
            var set = db.authority_table.Where(a =>
                a.controllerName == controllerName).ToArray();
            if (set != null && set.Length == 1)
            {
                int authorityID = set[0].ID;
                return authorityID;
            }
            return -1;
        }

        protected ICollection<AR> getContainedRoles(string controllerName)
        {
            int authorityID = this.getAuthorityID(controllerName);
            ICollection<AR> roleAuthorities = db.authorityRole_table.Where(r => r.authorityID == authorityID).ToList();
            return roleAuthorities;
        }
        #endregion
    }
}