using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shoelace.Models
{
    public class UserLoginModel
    {
        public class UserLoginRequestModel
        {
            public string userName { get; set; }

            public string password { get; set; }

            public bool rememberMe { get; set; }

            public string returnUrl { get; set; }
        }
        public class UserLoginResponseModel
        {
            public bool validLogin { get; set; }
            public String validLoginUrl { get; set; }
        }

        public class UserRegistrationModel
        {
            public string userName { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string confirmPassword { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }
    }
}