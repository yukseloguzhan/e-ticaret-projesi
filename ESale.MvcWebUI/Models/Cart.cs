using ESale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESale.MvcWebUI.Models
{
    public class Cart
    {
        private List<CartLine> list = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get
            {
                return list;
            }
        }

        public void AddProduct(Product product , int quantity)
        {
            var entity = list.FirstOrDefault(x=>x.Product.Id == product.Id);

            if (entity == null)
            {
                list.Add(new CartLine() { 
                  Product = product,
                  Quantity = quantity
                });
            }
            else
            {
                entity.Quantity += quantity;
            }

        }

        public void DeleteProduct(Product product)
        {
            var entity = list.RemoveAll(x => x.Product.Id == product.Id);

        }

        public double TotalPrice()
        {
            return list.Sum(x=>x.Product.Price * x.Quantity);
        }

        public void ClearCart()
        {
            list.Clear();
        }

    }

    public class CartLine   // Alışveriş sepetinde her satir
    {
        public Product  Product{ get; set; }
        public int Quantity { get; set; }
    }

}