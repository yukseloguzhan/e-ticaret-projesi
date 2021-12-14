using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESale.Entities.EnumVariable
{
    public enum OrderState
    {
        [Display(Name ="Awaiting approval")]
        Waiting,
        [Display(Name = "Approved")]
        Completed
    }
}
