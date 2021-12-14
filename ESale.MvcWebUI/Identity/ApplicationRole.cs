using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }    // kimler bu role sahip olabilir falan diye

        public ApplicationRole()
        {

        }

        public ApplicationRole(string rolename , string description)   // description yazabilmek için overload yaptık
        {
            this.Description = description;
        }

    }
}