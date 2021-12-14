using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }


        [Required]
        [Compare("Password",ErrorMessage ="Önceki yazığınız şifreyle eşleşmiyor")]
        public string RePassword { get; set; }


        [Required]
        public string Name { get; set; }


        [Required]
        public string Surname { get; set; }
    }
}