using OrderManagement_Model.CustomModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement_Repository.Interface
{
    public interface IAdminInterface
    {
        List<RegistrationModel> GetAdminProfile(int Userid);
    }
}
