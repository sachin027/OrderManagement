using OrderManagement_Model.CustomModel;
using OrderManagement_Model.DBContext;
using OrderManagement_Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement_Repository.Service
{
    public class AdminService : IAdminInterface
    {
        practice_547Entities _DBContext = new practice_547Entities();
        public List<RegistrationModel> GetAdminProfile(int Userid)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@userId" , Userid)
            };
            List<RegistrationModel> registrationModels = new List<RegistrationModel>();
            registrationModels=_DBContext.Database.SqlQuery<RegistrationModel>("exec SP_GetAdminProfileUsingId @userId", sqlParameters).ToList();
            return registrationModels;


        }
    }
}
