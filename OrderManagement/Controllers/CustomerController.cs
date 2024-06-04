using OrderManagement_Model.CustomModel;
using OrderManagement_Model.DBContext;
using OrderManagement_Repository.Interface;
using OrderManagement_Repository.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class CustomerController : Controller
    {
        practice_547Entities _DBContext = new practice_547Entities();
        ICustomerInterface customerInterface = new CustomerService(); 
        // GET: User
        public ActionResult CustomerDashboard()
        {
            RegistrationModel profile = customerInterface.GetUserProfile(38);
            return View(profile);
        }

        [HttpPost]
        public ActionResult CustomerDashboard(RegistrationModel registrationModel)
        {

            customerInterface.UpdateUserProfile(registrationModel);
            return RedirectToAction("CustomerDashboard");
        }
        public ActionResult AddOrder()
        {
            ViewBag.ItemList = customerInterface.GetItemList();
            return View();
        }
        public JsonResult AddOrderItem(int itemId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@itemid" , itemId)
                };
                ItemModel itemAmount = _DBContext.Database.SqlQuery<ItemModel>("exec SP_GetItemAmountByItemid @itemid", sqlParameters).FirstOrDefault();
                return Json(itemAmount, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}