using ESale.DataAccess.Concrete;
using ESale.Entities.Concrete;
using ESale.Entities.EnumVariable;
using ESale.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESale.MvcWebUI.Controllers
{
    public class CartsController : Controller
    {

        private SaleContext db = new SaleContext();

        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult RemoveFromCart(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()   // kartı kişiye özel değişkende saklıycam (session)  , her seferinde yeni bir cart göndermiycem
        {
            Cart cart = (Cart)Session["Cart"];   // her gelen kullanıcıya yeni session nesnesi oluşturulur

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;   // ve o cartı session da saklıyorum
            }

            return cart;

        }
        public PartialViewResult Summary()   // kartı kişiye özel değişkende saklıycam (session)  , her seferinde yeni bir cart göndermiycem
        {
            return PartialView(GetCart());
        }

        [HttpGet]
        public ActionResult Checkout()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetail shipping)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("NotFoundProducts", "Sepetinizde hiç ürün yok");
            }
            else
                if (ModelState.IsValid)
            {
                // sipariş veritabanına kaydet
                SaveOrder(cart, shipping);

                cart.ClearCart();
                return View("Completed");
            }
            else
            {
                return View(shipping);
            }

            return View();
        }

        private void SaveOrder(Cart cart, ShippingDetail shipping)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(11111,99999).ToString();
            order.Total = cart.TotalPrice();
            order.OrderDate = DateTime.Now;
            order.OrderState = OrderState.Waiting;
            order.FullName = User.Identity.Name;

            order.Address = shipping.Address;
            order.City = shipping.City;
            order.District = shipping.District;
            order.Neighbourhood = shipping.Neighbourhood;
            order.PostCode = shipping.PostCode;

            order.OrderLines = new List<OrderLine>();

            foreach (var item in cart.CartLines)
            {
                var line = new OrderLine();
                line.Quantity = item.Quantity;
                line.Price = item.Product.Price * item.Quantity; // mesela 2 tane tv   = 2*tvfiyat 
                line.ProductId = item.Product.Id;
                order.OrderLines.Add(line);
            }

            db.Orders.Add(order);
            db.SaveChanges();

        }
    }
}