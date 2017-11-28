using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo_2017._11._26.Attributes
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]))
            {

            }
            else
            {
                //base.HandleUnauthorizedRequest(filterContext);
                filterContext.Result = new RedirectResult("Manager/Login");
                //new ViewResult { ViewName = "Login" };
            }

        }
    }
}