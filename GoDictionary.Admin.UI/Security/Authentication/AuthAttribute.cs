using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoDictionary.Admin.UI.Security.Authentication
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/account/signin");
            }
        }
    }
}