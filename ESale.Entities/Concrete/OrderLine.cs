using ESale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESale.Entities.Concrete
{
    public class OrderLine : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }  // fiyat o anki fiyat sonradan değişebilir o yüzden burda tekrar attribute tanımladık


        public int OrderId { get; set; }
        public virtual Order Order { get; set; }


        public int ProductId { set; get; }
        public virtual Product Product { set; get; }

    }
}
