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

namespace Codecool.CodecoolShop.Controllers
{
    [Route("supplier")]
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;
        public SupplierService SupplierService { get; set; }

        public SupplierController(ILogger<SupplierController> logger)
        {
            _logger = logger;
            SupplierService = new SupplierService(
                ProductDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var products = SupplierService.GetProductsForSupplier(id);
            return View(products.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
