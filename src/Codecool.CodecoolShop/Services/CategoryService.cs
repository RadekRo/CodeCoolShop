using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class CategoryService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao categoryDao;

        public CategoryService(IProductDao productDao, IProductCategoryDao categoryDao)
        {
            this.productDao = productDao;
            this.categoryDao = categoryDao;
        }

        public ProductCategory GetProductForCategory(int categoryId) => this.categoryDao.Get(categoryId);

        public IEnumerable<Product> GetProductsForSupplier(int categoryId)
        {
            ProductCategory category = this.categoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
        }
        public List<ProductCategory> GetAllProductCategory()
        {
            var categoryList = categoryDao.GetAll();
            return categoryList.ToList();
        }
    }
}