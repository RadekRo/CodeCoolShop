using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class CartDaoMemory : ICartDao
    {
        public void Add(Product item)
        {
            throw new System.NotImplementedException();
        }

        public void AddToCart(Product product, int qty)
        {
            throw new System.NotImplementedException();
        }

        public decimal CalculateTotalPrice()
        {
            throw new System.NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetCartContents()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFromCart(Product product, int qty)
        {
            throw new System.NotImplementedException();
        }
    }
}
