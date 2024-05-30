using OrderManagement_Model.CustomModel;
using OrderManagement_Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement_Repository.Interface
{
    public interface ILoginInterface
    {
        bool Login(Registration login);
        Registration Signup(RegistrationModel register);
    }
}
