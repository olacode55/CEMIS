
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


using System.Text;

namespace CEMIS.Utility.ViewModel
{
    public class UsersObject
    {

        public long AppUserId { get; set; }
        [Display(Name = "Role")]
        [Required]
        public string RoleId { get; set; }
        [Display(Name = "Role")]
        public bool  IsFirstLogin { get; set; }
        public string Rolename { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Staff No")]
        public string StaffID { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        [Display(Name = "Role")]
        [Required]
        public IEnumerable<Int64> RoleIDs { get; set; }
        //[Required]
        public string UserNameUcase { get; set; }
        [Required]
        [Display(Name = "last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        //  [Remote(action: "VerifyEmail", controller: "Validation")]
        [Display(Name = "Email Official Only")]
        public string Email { get; set; }

    }
}
