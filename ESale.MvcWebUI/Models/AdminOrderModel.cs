using ESale.Entities.EnumVariable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Models
{
    public class AdminOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public int Count { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderState OrderState { get; set; }
    }
}