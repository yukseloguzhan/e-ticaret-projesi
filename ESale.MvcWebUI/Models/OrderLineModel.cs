using ESale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Models
{
    public class OrderLineModel
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }  // fiyat o anki fiyat sonradan değişebilir o yüzden burda tekrar attribute tanımladık

        public string Image { get; set; }


        public int ProductId { set; get; }

    }
}