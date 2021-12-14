using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Models
{
    public class ShippingDetail
    {
        public string FullName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string Neighbourhood { get; set; }
        public string PostCode { get; set; }
    }
}