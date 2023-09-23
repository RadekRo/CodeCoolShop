using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Codecool.CodecoolShop.Helpers;

namespace Codecool.CodecoolShop.Controllers
{
        [Route("checkout")]
        public class CheckoutController : BaseController
        {
            [Route("index")]
            public IActionResult Index()
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                SetCategoriesAndSuppliersInViewData();
                if (cart == null)
                {
                    ViewData["BasketEmpty"] = true;
                    ViewBag.total = 0.00;
                }
                else
                {
                    ViewData["BasketEmpty"] = false;
                    ViewBag.cart = cart;
                    ViewBag.total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity);
                    GetShoppingCartQty();
                }
                return View();
            }



         }
    
}
