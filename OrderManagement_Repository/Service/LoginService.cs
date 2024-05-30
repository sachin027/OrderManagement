using OrderManagement_Helper;
using OrderManagement_Model.CustomModel;
using OrderManagement_Model.DBContext;
using OrderManagement_Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement_Repository.Service
{
    public class LoginService : ILoginInterface
    {
        practice_547Entities _DBContext = new practice_547Entities();

        public bool Login(Registration login)
        {
            Registration register = new Registration();
            try
            {
                if(login.role == 1)
                {
                    //register = LoginHelper.RegisterModelToRegisterDB(login);
                    register = _DBContext.Registration.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                    if (register != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(login.role == 2)
                {
                    //register = LoginHelper.RegisterModelToRegisterDB(login);
                    register = _DBContext.Registration.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                    if (register != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Registration Signup(RegistrationModel register)
        {
            Registration registration = new Registration();
            try
            {
                if(register.role == 2)
                {
                    registration = LoginHelper.RegisterModelToRegisterDB(register);
                    var IsEmailExist = _DBContext.Registration.Any(x => x.Email == register.Email);
                    var IsUserExist = _DBContext.Registration.Any(x => x.Username == register.Username);

                    if(!IsEmailExist && !IsUserExist)
                    {
                        registration =_DBContext.Registration.Add(registration);
                        _DBContext.SaveChanges();
                        return registration;
                    }
                }
                else if(register.role == 1)
                {
                    registration = LoginHelper.RegisterModelToRegisterDB(register);
                    var IsEmailExist = _DBContext.Registration.Any(x => x.Email == register.Email);
                    var IsUserExist = _DBContext.Registration.Any(x => x.Username == register.Username);

                    if (!IsEmailExist && !IsUserExist)
                    {
                        registration= _DBContext.Registration.Add(registration);
                        _DBContext.SaveChanges();
                        return registration;
                    }
                }
                return registration;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
