using System.Collections.Generic;

using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal price { get; set; }
    }

    public class ShoppingCartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Product.price * item.Quantity;
            }
            return total;
        }
    }

    public class CheckoutForm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
    }
}

