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
    public class ProductController : BaseController
    {
        private readonly ILogger<ProductController> _logger;
       
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            var products = ProductService.GetProductsForCategory(1);
            SetCategoriesAndSuppliersInViewData();
            return View(products.ToList());
        }
        public IActionResult Categories(int category)
        {
            SetCategoriesAndSuppliersInViewData();
            var products = ProductService.GetProductsForCategory(category);
            return View(products.ToList());
        }
        public IActionResult Suppliers(int supplier)
        {
            SetCategoriesAndSuppliersInViewData();
            var products = SupplierService.GetProductsForSupplier(supplier);
            return View(products.ToList());
        }
        public IActionResult Privacy()
        {
            SetCategoriesAndSuppliersInViewData();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
