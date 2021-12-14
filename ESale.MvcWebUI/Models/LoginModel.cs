using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }

       

    }
}