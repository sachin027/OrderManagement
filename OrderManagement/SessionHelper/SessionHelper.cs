using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.SessionHelper
{
    public class SessionHelper
    {
        public static string Username
        {
            get
            {
                return HttpContext.Current.Session["Username"] == null ? "" : (string)HttpContext.Current.Session["Username"];
            }
            set
            {
                HttpContext.Current.Session["Username"] = value;
            }
        }
        public static string role
        {
            get
            {
                return HttpContext.Current.Session["role"] == null ? "" : (string)HttpContext.Current.Session["role"];
            }
            set
            {
                HttpContext.Current.Session["role"] = value;
            }
        }
        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : (int)HttpContext.Current.Session["UserId"];
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }
        public static string Email
        {
            get
            {
                return HttpContext.Current.Session["Email"] == null ? "" : (string)HttpContext.Current.Session["Email"];
            }
            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

    }
}