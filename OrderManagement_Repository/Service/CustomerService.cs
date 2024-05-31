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
    }
}
