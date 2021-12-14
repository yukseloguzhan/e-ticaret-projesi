using ESale.DataAccess.Concrete;
using ESale.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESale.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {

        SaleContext context = new SaleContext();


        public ActionResult Index()
        {

            var products = context.Products.Where(x => x.IsHome == true && x.IsApproved == true).Select(x => new ProductModel()
            {
                Id = x.Id,
                Description = x.Description.Length > 50 ? x.Description.Substring(0, 47) + "..." : x.Description,
                Name = x.Name.Length > 50 ? x.Name.Substring(0, 47) + "..." : x.Name,
                Stock = x.Stock,
                Price = x.Price,
                CategoryId = x.CategoryId,
                Image = x.Image
            }).ToList();

            return View(products);
        }

        public ActionResult Details(int id)
        {
            return View(context.Products.Where(x => x.Id == id).FirstOrDefault());
        }

        public ActionResult List(int? id)
        {
            var products = context.Products.Select(x => new ProductModel()
            {
                Id = x.Id,
                Description = x.Description.Length > 50 ? x.Description.Substring(0, 47) + "..." : x.Description,
                Name = x.Name.Length > 50 ? x.Name.Substring(0, 47) + "..." : x.Name,
                Stock = x.Stock,
                Price = x.Price,
                CategoryId = x.CategoryId,
                Image = x.Image ?? "default.jpg"
            }).AsQueryable();

            if (id != null)
            {
                products = products.Where(x=>x.CategoryId == id);
            }

            return View(products.ToList());
        }

        public PartialViewResult GetCategories()
        {
            var list = context.Categories.ToList();
            return PartialView(list);
        }


    }
}