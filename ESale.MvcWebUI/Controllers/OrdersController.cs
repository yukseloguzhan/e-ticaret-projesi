using ESale.DataAccess.Concrete;
using ESale.Entities.EnumVariable;
using ESale.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESale.MvcWebUI.Controllers
{

    [Authorize(Roles = "admin")]
    public class OrdersController : Controller
    {
        private SaleContext db = new SaleContext();

        public ActionResult Index()
        {
            var orders = db.Orders.Select(x => new AdminOrderModel()
            {
                 Id = x.Id,
                 OrderDate = x.OrderDate,
                 OrderNumber = x.OrderNumber,
                 OrderState = x.OrderState,
                 Total = x.Total,
                 Count = x.OrderLines.Count
            }).OrderByDescending(i=>i.OrderDate).ToList();

            return View(orders);
        }


        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(x => x.Id == id).Select(x => new OrderDetailsModel()
            {
                OrderId = x.Id,
                OrderNumber = x.OrderNumber,
                OrderDate = x.OrderDate,
                FullName=x.FullName,
                Total = x.Total,
                OrderState = x.OrderState,
                Address = x.Address,
                City = x.City,
                PostCode = x.PostCode,
                District = x.District,
                Neighbourhood = x.Neighbourhood,

                OrderLines = x.OrderLines.Select(y => new OrderLineModel()
                {
                    ProductId = y.ProductId,
                    ProductName = y.Product.Name,
                    Image = y.Product.Image,
                    Quantity = y.Quantity,
                    Price = y.Price
                }).ToList()


            }).FirstOrDefault();

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(int OrderId, OrderState state)
        {
            var order = db.Orders.FirstOrDefault(x=>x.Id == OrderId);

            if (order!=null)
            {
                order.OrderState = state;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz kaydedildi";

                return RedirectToAction("Details",new { id=OrderId});
            }

            return RedirectToAction("Index");
        }


    }
}