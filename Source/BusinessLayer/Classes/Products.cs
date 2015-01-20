// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Collections.Generic;
using System.Linq;

using DataLayer;
using BusinessLayer.BObjects;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    internal class Products
    {
        public static List<BProduct> GetProducts(TrucksReserveEntities dc, int? categoryId = null)
        {
            dc.ExcIfNull();

            List<BProduct> products = new List<BProduct>();
            List<Product> bProducts = new List<Product>();
            if(categoryId.HasValue == true)
            {
                bProducts = dc.Products.Where(p => p.Products_Categories.Count() > 0
                    && p.Products_Categories.FirstOrDefault(c => c.CategoryID == categoryId.Value) != null).ToList();
            }
            else
            {
                bProducts = dc.Products.ToList();
            }

            if (bProducts.AreThereItems() == true)
            {
                products = bProducts.ConvertAll<BProduct>(new Converter<Product, BProduct>(BProduct.ElementConverter));

                if (categoryId.HasValue == false) { products = products.OrderBy(p => p.FirstCategoryID).ToList(); }
            }
           

            return products;
        }
    }
}
