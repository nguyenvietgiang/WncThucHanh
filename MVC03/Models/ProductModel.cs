using System;
using System.Collections.Generic;

namespace MVC03.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ImageURL { get; set; }
        public string? Description {get; set;}
        public decimal ProductPrice { get; set; }

        public static List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();
            for (int i = 1; i <= 10; i++)
            {
                products.Add(new ProductModel
                {
                    ProductID = i,
                    ProductName = $"Product {i}",
                    Description= "Product Discription",
                    ProductPrice = i * 10.0m
                });
            }

            return products;
        }
    }
}
