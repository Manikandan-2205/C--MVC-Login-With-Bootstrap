using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace login.Models
{
    public class Registration
    {
        [Required(ErrorMessage ="Enter UserName !")]
        [Display(Name ="Enter UserName :")]
        [StringLength(maximumLength:50,MinimumLength =3,ErrorMessage ="UserName Length Must Be Max 7 & Min 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Valued Email Address !")]
        [Display(Name = "Email ID : ")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Enter The Password !")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Enter The RePassword !")]
        [Display(Name = "RePassword :")]
        [DataType(DataType.Password)]
        [Compare("UserPassword")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Select The Gender !")]
        [Display(Name = "Gender :")]
        public char UserGender { get; set; }

        [Required(ErrorMessage = "Upload Profile Image !")]
        [Display(Name = "Profile Image :")]
        public string Userimage { get; set; }
    }
}