using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Daos.Implementations;

namespace Codecool.CodecoolShop.Controllers
{
    [Route("cart")]
    public class CartController : BaseController
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

        [Route("addtocart/{id}")]
        public IActionResult AddToCart(string id)
        {
 
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = ProductService.GetProduct(Convert.ToInt32(id)), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(Convert.ToInt32(id));
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = ProductService.GetProduct(Convert.ToInt32(id)), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(Convert.ToInt32(id));
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
