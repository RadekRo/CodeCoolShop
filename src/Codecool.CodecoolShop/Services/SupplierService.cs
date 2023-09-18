using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class SupplierService
    {
        private readonly IProductDao productDao;
        private readonly ISupplierDao supplierDao;

        public SupplierService(IProductDao productDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.supplierDao = supplierDao;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return supplierDao.GetAll();
        }

        public Supplier GetProductForSupplier(int supplierId)
        {
            return this.supplierDao.Get(supplierId);
        }

        public IEnumerable<Product> GetProductsForSupplier(int supplierId)
        {
            Supplier supplier = this.supplierDao.Get(supplierId);
            return this.productDao.GetBy(supplier);
        }
    }
}