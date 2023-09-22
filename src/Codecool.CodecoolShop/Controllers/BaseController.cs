using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    }
}
