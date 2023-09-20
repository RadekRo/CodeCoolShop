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

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }
        public SupplierService SupplierService { get; set; }    

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
            SupplierService = new SupplierService(
                ProductDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
        }
        private void SetCategoriesInViewData()
        {
            ViewData["categories"] = ProductService.GetAllProductsCategories();
        }

        private void SetSuppliersInViewData()
        {
            ViewData["suppliers"] = SupplierService.GetAllSuppliers();
        }

        public IActionResult Index()
        {
            var products = ProductService.GetProductsForCategory(1);
            SetCategoriesInViewData();
            SetSuppliersInViewData();
            return View(products.ToList());
        }
        public IActionResult Categories()
        {
            SetCategoriesInViewData();
            SetSuppliersInViewData();
            return View();
        }
        public IActionResult Suppliers()
        {
            SetCategoriesInViewData();
            SetSuppliersInViewData();
            return View();
        }
        public IActionResult Privacy()
        {
            SetCategoriesInViewData();
            SetSuppliersInViewData();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
