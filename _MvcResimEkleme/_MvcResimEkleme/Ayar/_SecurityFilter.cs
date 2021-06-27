using _MvcResimEkleme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _MvcResimEkleme.Ayar
{
    public class _SecurityFilter:ActionFilterAttribute
    {
        // Action çalışmadan öncesi
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (HttpContext.Current.Session["Kullanici"]==null && controllerName != "Login")
            {
                // Kullanıcı girişine yönlendir.
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }

            //Kullanici k = (Kullanici)HttpContext.Current.Session["Kullanici"];
            base.OnActionExecuting(filterContext);
        }
    }
}