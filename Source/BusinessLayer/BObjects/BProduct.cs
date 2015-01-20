// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;
using System.Linq;

using DataLayer;
using ToolsLibrary;

namespace BusinessLayer.BObjects
{
    public class BProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<BCategory> Categories { get; set; }
        public int? FirstCategoryID {
            get
            {
                if (Categories.AreThereItems() == true) { return Categories.First().ID; }
                else { return null; }
            }
        }

        internal BProduct(Product product, bool loadCategories)
        {
            product.ExcIfNull();

            this.ID = product.ID;
            this.Name = product.Name;
            this.Description = product.Description.GetTrimmed();

            this.Categories = new List<BCategory>();
            if (loadCategories == true && product.Products_Categories.AreThereItems() == true)
            {
                foreach (Product_Category pc in product.Products_Categories)
                {
                    this.Categories.Add(new BCategory(pc.Category, false, false));
                }
            }
        }

        internal static BProduct ElementConverter(Product p)
        {
            return new BProduct(p, true);
        }

    }
}
