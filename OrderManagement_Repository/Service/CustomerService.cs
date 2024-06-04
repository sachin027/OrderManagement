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
    public class CustomerService : ICustomerInterface
    {
        practice_547Entities _DBContext = new practice_547Entities();
        public List<ItemModel> GetItemList()
        {
            try
            {
                List<ItemModel> itemModels = _DBContext.Database.SqlQuery<ItemModel>("exec SP_GetAllItemList").ToList();
                return itemModels;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public RegistrationModel GetUserProfile(int userId)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@userId" , userId)
                };

                RegistrationModel profile = _DBContext.Database.SqlQuery<RegistrationModel>("exec SP_GetUserProfile @userId ", sqlParameters).FirstOrDefault();
                return profile;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void UpdateUserProfile(RegistrationModel userProfile)
        {
            try
            {
                // Call the stored procedure to update the user profile
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", userProfile.Username),
                    new SqlParameter("@FirstName", userProfile.FirstName),
                    new SqlParameter("@LastName", userProfile.LastName),
                    new SqlParameter("@ProfilePicture", userProfile.profilePicture)
                };

                _DBContext.Database.ExecuteSqlCommand("exec SP_UpdateUserProfile @Username, @FirstName, @LastName,@ProfilePicture, parameters");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
