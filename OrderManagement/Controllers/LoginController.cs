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
    public class LoginController : Controller
    {
        practice_547Entities _DBContext = new practice_547Entities();
        ILoginInterface loginInterface = new LoginService();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include ="role , Email , Password")] Registration _Login)
        {
            try
            {
                if(_Login.Email != null && _Login.Password != null && _Login.role == 1)
                {
                    bool IsValidUser = loginInterface.Login(_Login);
                    if (IsValidUser)
                    {

                        TempData["success"] = "Login successfully ";
                        return RedirectToAction("AdminDashboard", "Admin");
                    }
                }                
                else if(_Login.Email != null && _Login.Password != null && _Login.role == 2)
                {
                    bool IsValidUser = loginInterface.Login(_Login);
                    if (IsValidUser)
                    {
                        TempData["success"] = "Login successfully ";
                        return RedirectToAction("UserDashboard", "User");
                    }
                }
                 return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult Registration()
        {
            ViewBag.Countries = _DBContext.country.ToList();
            ViewBag.Destination = _DBContext.Destination.ToList();
            return View();
        }        
        
        [HttpPost]
        public ActionResult Registration(RegistrationModel Register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(Register.ImageFile != null)
                    {
                        string[] allowedTypes = { "image/jpeg", "image/jpg", "image/png" };
                        if (!allowedTypes.Contains(Register.ImageFile.ContentType))
                        {
                            ModelState.AddModelError("ImageFile", "Please upload a valid image file (JPEG, JPG, PNG.");
                        }
                        int maxFileSize = 5 * 1024 ; // 5MB in bytes
                        if (Register.ImageFile.ContentLength > maxFileSize)
                        {
                            ModelState.AddModelError("ImageFile", "The image file size should not exceed 5MB.");
                        }
                    }
                }

                if (ModelState.IsValid)
                {
                    if (loginInterface.Signup(Register) != null)
                    {
                        ModelState.Clear();
                        TempData["success"] = "Register successfully ";
                        return View("Login");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Email I'd already exist");
                        ModelState.AddModelError("Username", "Username already exist");
                        TempData["error"] = "Something went wrong ! ";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
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