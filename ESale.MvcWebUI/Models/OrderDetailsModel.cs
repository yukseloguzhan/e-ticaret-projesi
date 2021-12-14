using ESale.Entities.EnumVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState OrderState { get; set; }

        public virtual List<OrderLineModel> OrderLines { set; get; }



        public string FullName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string PostCode { get; set; }
    }
}