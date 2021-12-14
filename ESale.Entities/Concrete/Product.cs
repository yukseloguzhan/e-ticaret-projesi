using ESale.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESale.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }



        public int CategoryId { set; get; }
        public Category Category { set; get; }

    }
}
