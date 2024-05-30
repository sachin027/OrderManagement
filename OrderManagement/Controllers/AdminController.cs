using OrderManagement_Model.CustomModel;
using OrderManagement_Repository.Interface;
using OrderManagement_Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class AdminController : Controller
    {
        IAdminInterface adminInterface = new AdminService();
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            List<RegistrationModel> registrationModels = adminInterface.GetAdminProfile(12);
           
            return View(registrationModels);
        }
    }
}