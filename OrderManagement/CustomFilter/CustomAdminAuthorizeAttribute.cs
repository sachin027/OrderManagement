using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OrderManagement.CustomFilter
{
    public class CustomAdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(SessionHelper.SessionHelper.Email != "" && SessionHelper.SessionHelper.role == "Admin")
            {
                return true;
            }
            else
            {
                return false;   
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller" , "Admin"},
                    {"action" , "AdminDashboard" }
                });
        }
    }
}