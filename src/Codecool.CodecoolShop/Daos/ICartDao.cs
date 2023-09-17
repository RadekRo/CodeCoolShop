using Codecool.CodecoolShop.Models;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos
{
    public interface ICartDao : IDao<Product>
    {
        void AddToCart(Product product, int qty);
        void RemoveFromCart(Product product, int qty);
        IEnumerable<Product> GetCartContents();
        decimal CalculateTotalPrice();
    }
}
