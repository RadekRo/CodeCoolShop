using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class Product : BaseModel
    {
        internal ProductCategory ProductCategory;

        public string Currency { get; set; }
        public decimal DefaultPrice { get; set; }
        public HashSet<ProductCategory> ProductCategories { get; set; }

        public Supplier Supplier { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
            ProductCategories = new();
        }


        public void SetProductCategory(HashSet<ProductCategory> productCategories)
        {
            foreach (ProductCategory pc in productCategories)
            {
                pc.Products.Add(this);
            }
        }

        public string PriceToString()
        {
            return DefaultPrice.ToString() + " " + Currency;
        }

        public string CategoryToString(HashSet<ProductCategory> productCategories)
        {
            List<string> str = new List<string>();
            foreach (ProductCategory pc in productCategories)
            {
                str.Add(pc.Name);
            }
            return String.Join(", ", str);
        }
    }
}