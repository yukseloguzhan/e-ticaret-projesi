using ESale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESale.DataAccess.Concrete
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<SaleContext>
    {
        protected override void Seed(SaleContext context)
        {

            var categories = new List<Category>()
            {
                new Category() { Name="Kamera" , Description="Kamera ürünleri" },
                new Category() { Name="Bilgisayar" , Description="Bilgisayar ürünleri" },
                new Category() { Name="Telefon" , Description="Telefon ürünleri" },
                new Category() { Name="Elektronik" , Description="Elektronik ürünleri" },
                new Category() { Name="Beyaz Eşya" , Description="Beyaz Eşya ürünleri" }

            };

            foreach (var x in categories)
            {
                context.Categories.Add(x);
            }
            context.SaveChanges();



            var products = new List<Product>()
            {
                new Product() { Name="Samsung S5" , Description="Kamera ürünleri", Price=2356 , Stock= 1200 , IsApproved=true, CategoryId=2, IsHome=true, Image="1.jpg" },
                new Product() { Name="Samsung S56" ,  Description="Kamera ürünleri", Price=4567 , Stock= 1200 , IsApproved=false, CategoryId=2, Image="2.jpg" },
                new Product() { Name="Samsung S567" ,  Description="Kamera ürünleri", Price=4343 , Stock= 2500 , IsApproved=true, CategoryId=1,IsHome=true, Image="3.jpg"},
                new Product() { Name="Samsung S5678" ,  Description="Kamera ürünleri", Price=7878 , Stock= 500 , IsApproved=true, CategoryId=1, Image="4.jpg" },
                new Product() { Name="Samsung S56789" ,  Description="Kamera ürünleri", Price=454545 , Stock= 123 , IsApproved=true, CategoryId=3, Image="5.jpg" }

            };

            foreach (var x in products)
            {
                context.Products.Add(x);
            }
            context.SaveChanges();


            base.Seed(context);
        }
    }
}
