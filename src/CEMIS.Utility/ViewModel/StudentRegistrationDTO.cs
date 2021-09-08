using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class StudentRegistrationDTO
    {
        [Required(ErrorMessage = "*Student ID is required.")]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "*Registration Pin is required.")]
        public string RegistrationPin { get; set; }
        [Required(ErrorMessage = "*First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*Last Name is required.")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "*Phone Number is required.")]
        [RegularExpression(@"^[0]\d{10}$", ErrorMessage = "Invalid Phone Number")]
        [StringLength(14, ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        public string CollegeName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-z])(?=.*[A-Z])(?=.*[0-9])\S{6,12}$",
        ErrorMessage = "Password should contain at one number, One uppercase letter and length at least 6 characters and a maximum of 12 characters")]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
               [Compare("Password" , ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }
    }
}
