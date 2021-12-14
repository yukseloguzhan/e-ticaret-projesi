using ESale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESale.DataAccess.Concrete
{
    public class SaleContext : DbContext
    {

        public SaleContext()  : base("SaleContext")
        {
           
        }

        public DbSet<Product>  Products { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Order>   Orders { get; set; }
        public DbSet<OrderLine>  OrderLines { get; set; }
    }
}
