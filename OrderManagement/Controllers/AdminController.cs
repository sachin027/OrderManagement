﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            return View();
        }
    }
}