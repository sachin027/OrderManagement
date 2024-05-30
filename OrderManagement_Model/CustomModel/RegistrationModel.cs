using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OrderManagement_Model.CustomModel
{
    public class RegistrationModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="Username Required")]
        [MaxLength(8,ErrorMessage ="Username length greater than 8")]
        [MinLength(6,ErrorMessage ="Username length less than 6")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{6,8}$" , ErrorMessage = "Contain alphabets and numbers")]
        public string Username { get; set; }

        [Required(ErrorMessage ="FirstName Required")]
        [RegularExpression(@"^[A-Za-z]+$" , ErrorMessage ="only contain alphabets")]
        [MaxLength(15, ErrorMessage = "Username length greater than 15")]
        [MinLength(2, ErrorMessage = "Username length less than 2")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8,10}$" , ErrorMessage ="Must contain alphabets , numbers , special characters, capital letter")]
        [MaxLength(10,ErrorMessage ="Maximum length should be 10")]
        [MinLength(8,ErrorMessage ="Mimimum length should be 8")]
        public string Password { get; set; }


        [Required]
        [Compare("Password", ErrorMessage = "Password is not identical")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email required")]
        [RegularExpression(@"^[a-zA-Z0-9_.%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email id.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="At least one required")]
        public string[] hobbies { get; set; }

        [Required(ErrorMessage ="Gender Required")]
        public string gender { get; set; }



        ///image
        public string profilePicture { get; set; }
        [Required(ErrorMessage = "Please upload photo")]
        public HttpPostedFileBase ImageFile { get; set; }


        /// image end


        [Required(ErrorMessage ="Role must be selected")]
        public Nullable<int> role { get; set; }

        [Required(ErrorMessage = "Country must be selected")]
        public Nullable<int> Country { get; set; }

        [Required(ErrorMessage = "State must be selected")]
        public Nullable<int> State { get; set; }

        [Required(ErrorMessage = "City must be selected")]
        public Nullable<int> City { get; set; }

        [Required(ErrorMessage ="DOB required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "at least one should be selected")]
        public string[] Destination { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression("^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }
    }
}
