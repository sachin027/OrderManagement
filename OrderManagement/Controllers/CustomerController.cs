using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class CustomerController : Controller
    {
        // GET: User
        public ActionResult CustomerDashboard()
        {
            return View();
        }
    }
}