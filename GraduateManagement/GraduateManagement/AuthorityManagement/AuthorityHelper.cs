using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using GraduateManagement.Models;

namespace Se.Aee.Helpers
{
    public class AuthorityHelper
    {
        private SqlDbContext db = new SqlDbContext();

        public void InitialAuthorityList()
        {
            var controllers = Assembly.GetExecutingAssembly().GetExportedTypes().Where(t =>
                typeof(ControllerBase).IsAssignableFrom(t)).Select(t => t);
            foreach (Type controller in controllers)
            {
                var actions = controller.GetMethods().Where(a => a.Name != "Dispose" && !a.IsSpecialName
                    && a.DeclaringType.IsSubclassOf(typeof(ControllerBase)) && a.IsPublic && !a.IsStatic).ToList();
                foreach (var action in actions)
                {
                    authority auth = new authority();
                    string t_controllerName = controller.Name.Substring(0, controller.Name.Length
                        - "Controller".Length);

                    auth.controllerName = t_controllerName;
                    auth.actionName = action.Name;
                    if (!db.authority_table.Any(a => a.actionName == auth.actionName
                        && a.controllerName == auth.controllerName))
                    {
                        db.authority_table.Add(auth);
                    }
                }
            }
            db.SaveChanges();
        }

        public int GetAuthorId(string controllerName, string actionName)
        {
            int authorId = db.authority_table.FirstOrDefault(a =>
               a.actionName == actionName && a.controllerName == controllerName).ID;
            return authorId;
        }

        public ICollection<AR> GetContainRoles(string controlName, string actionName)
        {
            int authorID = this.GetAuthorId(controlName, actionName);
            ICollection<AR> roleAuthorities = db.authorityRole_table.Where(r => r.authorityID == authorID).ToList();
            return roleAuthorities;
        }

        public role GetRole(string accountNum)
        {
            int role = db.user_table.Single(a => a.accountNum == accountNum).roleID;
            return db.role_table.Single(a => a.ID == role);
        }
    }
}