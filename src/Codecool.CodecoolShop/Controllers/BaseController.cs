using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ProductService ProductService;
        protected readonly SupplierService SupplierService;

        public BaseController()
        {
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());

            SupplierService = new SupplierService(
                ProductDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
        }

        protected void SetCategoriesAndSuppliersInViewData()
        {
            ViewData["Categories"] = ProductService.GetAllProductsCategories();
            ViewData["Suppliers"] = SupplierService.GetAllSuppliers();
        }

        protected void GetShoppingCartQty()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null) 
            {
                ViewData["BasketQty"] = cart.Sum(item => item.Quantity);
            }
            else
            {
                ViewData["BasketQty"] = 0;
            }
        }
    }
}
