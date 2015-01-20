// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Collections.Generic;
using System.Linq;

using DataLayer;
using BusinessLayer.BObjects;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    internal class Categories
    {
        public static BCategory GetCategory(TrucksReserveEntities trModel, int id)
        {
            trModel.ExcIfNull();

            BCategory category = null;

            Category dbCategory = trModel.Categories.FirstOrDefault(c => c.ID == id);
            if (dbCategory != null)
            {
                category = new BCategory(dbCategory, false, false);
            }

            return category;
        }

        public static List<BCategory> GetCategories(TrucksReserveEntities trModel, bool loadProducts = false)
        {
            trModel.ExcIfNull();

            List<BCategory> bCategories = new List<BCategory>();

            List<Category> dbCategories = trModel.Categories.ToList();
            if (dbCategories.AreThereItems() == true)
            {
                foreach (Category cat in dbCategories)
                {
                    bCategories.Add(new BCategory(cat, false, loadProducts));
                }
            }

            return bCategories;
        }

        public static List<BCategory> GetCategoriesWithProducts(TrucksReserveEntities trModel, bool loadCategories, int? onlyForCategoryID = null)
        {
            trModel.ExcIfNull();

            List<BCategory> bCategories = new List<BCategory>();

            if (onlyForCategoryID.HasValue == true)
            {
                BCategory wantedCategory = null;
                if (loadCategories == true)
                {
                    bCategories = GetCategories(trModel);
                    wantedCategory = bCategories.First(c => c.ID == onlyForCategoryID.Value);
                }
                else
                {
                    wantedCategory = GetCategory(trModel, onlyForCategoryID.Value);
                    bCategories.Add(wantedCategory);
                }
               
                wantedCategory.ExcIfNull();

                wantedCategory.LoadProducts(trModel);
                wantedCategory.LoadImages(trModel);
            }
            else
            {
                bCategories = GetCategories(trModel, true);
            }

            return bCategories;
        }





    }
}
