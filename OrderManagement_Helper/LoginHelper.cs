using OrderManagement_Model.CustomModel;
using OrderManagement_Model.DBContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrderManagement_Helper
{
    public class LoginHelper
    {
        public static Registration RegisterModelToRegisterDB(RegistrationModel registrationModel)
        {
            try
            {
                Registration registerDB = new Registration();
                if(registrationModel != null)
                {
                    registerDB.Username = registrationModel.Username;
                    registerDB.role = registrationModel.role;
                    registerDB.DateOfBirth = registrationModel.DateOfBirth;
                    registerDB.FirstName = registrationModel.FirstName;
                    registerDB.LastName = registrationModel.LastName;
                    registerDB.Password = registrationModel.Password;
                    registerDB.Email = registrationModel.Email;
                    registerDB.hobbies = string.Join("," , registrationModel.hobbies) ;
                    registerDB.Country = registrationModel.Country;
                    registerDB.State = registrationModel.State;
                    registerDB.City = registrationModel.City;
                    registerDB.gender = registrationModel.gender;
                    registerDB.PhoneNumber = registrationModel.PhoneNumber;
                    registerDB.Destination = string.Join(",", registrationModel.Destination);

                    // Generate unique file name
                    string fileName = UniqueFileName(registrationModel);

                    // Save file name in registrationDB
                    registerDB.profilePicture = fileName;

                    // Save the uploaded file
                    SaveFile(registrationModel.ImageFile, fileName);
                }
                return registerDB;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static string UniqueFileName(RegistrationModel model)
        {
            if (model.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                return fileName;
            }
            return null;
        }

        private static void SaveFile(HttpPostedFileBase file, string fileName)
        {
            if (file != null && file.ContentLength > 0)
            {
                string uploadsFolder = HttpContext.Current.Server.MapPath("~/Content/Theme/Registration/Uploads/");
                string filePath = Path.Combine(uploadsFolder, fileName);
                file.SaveAs(filePath);
            }
        }


    }
}
