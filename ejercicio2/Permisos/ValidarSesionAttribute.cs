using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejercicio2.Permisos
{
	public class ValidarSesionAttribute : ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {

                filterContext.Result = new RedirectResult("~/login/Login");
            }

            base.OnActionExecuting(filterContext);
        }

    }
}