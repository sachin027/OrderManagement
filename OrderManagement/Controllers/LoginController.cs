using OrderManagement_Model.CustomModel;
using OrderManagement_Model.DBContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class LoginController : Controller
    {
        practice_547Entities _DBContext = new practice_547Entities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            ViewBag.Countries = _DBContext.country.ToList();
            return View();
        }        
        
        [HttpPost]
        public ActionResult Registration(RegistrationModel Register)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public JsonResult GetStateByCountry(int CountryId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@CountryId" , CountryId)
                };

                List<state> StateList = _DBContext.Database.SqlQuery<state>("exec GetStateId @CountryId" , sqlParameters).ToList();
                return Json(StateList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult GetCityByState(int StateId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@StateId" , StateId)
                };
                List<City> CityList = _DBContext.Database.SqlQuery<City>("exec GetCityByCountryId @StateId", sqlParameters).ToList();
                    return Json(CityList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}