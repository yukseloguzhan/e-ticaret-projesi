using ESale.DataAccess.Concrete;
using ESale.MvcWebUI.Identity;
using ESale.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESale.MvcWebUI.Controllers
{
    public class AccountsController : Controller
    {
        private SaleContext db = new SaleContext();

        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountsController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager = new UserManager<ApplicationUser>(userStore);

           var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult MyAccount()
        {
            var userName = User.Identity.Name;
            var orders = db.Orders.Where(x => x.FullName == userName)
                .Select(x => new UserOrderModel()
                {
                     Id = x.Id,
                     OrderNumber = x.OrderNumber,
                     OrderDate = x.OrderDate,
                     OrderState = x.OrderState,
                     Total = x.Total 
                }).OrderByDescending(x=>x.OrderDate).ToList();

            return View(orders);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(x=>x.Id == id).Select(x=> new OrderDetailsModel() { 
             OrderId = x.Id,
             OrderNumber = x.OrderNumber,
             OrderDate = x.OrderDate,
             Total = x.Total,
             OrderState = x.OrderState,
             Address = x.Address,
             City = x.City,
             PostCode = x.PostCode,
             District = x.District,
             Neighbourhood = x.Neighbourhood,

             OrderLines = x.OrderLines.Select( y => new OrderLineModel() { 
                ProductId = y.ProductId,
                ProductName = y.Product.Name,
                Image = y.Product.Image,
                Quantity = y.Quantity,
                Price = y.Price
             }).ToList()
              
             
            }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Email = registerModel.Email;
                user.Surname = registerModel.Surname;
                user.Name = registerModel.Name;
                user.UserName = registerModel.UserName;


                var result = userManager.Create(user,registerModel.Password);

                if (result.Succeeded)
                {
                    // kullanıcı oluştu role atayabilirsin
                    if (roleManager.RoleExists("user"))
                    {
                        userManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login","Accounts");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError","Kullanıcı oluşturulamadı");   // error a hangi isim vereceksin
                }

            }

            return View(registerModel);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel , string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(loginModel.UserName, loginModel.Password);

                if (user!=null)
                {
                    // varolan kullanıcıyı sisteme dahil et
                    //ApplcationCookie oluştur sisteme bırak
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = loginModel.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);


                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }


                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Giriş Hatalı! Böyle kullanıcı yok");   // error a hangi isim vereceksin
                }

            }

            return View(loginModel);

        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;  // oluşturduğumuz cookie yi siliyoruz
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }


    }
}