// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Collections.Generic;
using System.Linq;

using BusinessLayer.Instruments;
using DataLayer;
using ToolsLibrary;

using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.BObjects
{
    public class BCategory
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public List<BCategory> SubCategories { get; set; }

        public List<BProduct> Products { get; set; }
        public List<BFirm> Firms { get; set; }
        public List<BImage> Images { get; set; }

        public BCategory() { }

        internal BCategory(Category category, bool loadFirms, bool loadProducts)
        {
            category.ExcIfNull();

            this.ID = category.ID;
            this.Name = category.Name;
            this.Description = category.Description.GetTrimmed();

            this.SubCategories = new List<BCategory>();
            if (category.ChildCategories.AreThereItems() == true)
            {
                foreach (Category cat in category.ChildCategories)
                {
                    SubCategories.Add(new BCategory(cat, loadFirms, loadProducts));
                }
            }
            
            this.Firms = new List<BFirm>();
            if (loadFirms == true && category.Firms.AreThereItems() == true)
            {
                foreach (Firm_Category fc in category.Firms)
                {
                    this.Firms.Add(new BFirm(fc.Firm));
                }
            }

            this.Products = new List<BProduct>();
            if (loadProducts == true)
            {
                this.LoadProducts(category);
            }
        }

        internal void LoadProducts(TrucksReserveEntities dc)
        {
            dc.ExcIfNull();
            if (this.ID < 1) { BTools.NewBException("this.ID < 1"); }

            Category category = dc.Categories.FirstOrDefault(c => c.ID == this.ID);
            category.ExcIfNull();

            this.LoadProducts(category);
        }

        private void LoadProducts(Category category)
        {
            category.ExcIfNull();

            this.Products = new List<BProduct>();
            if (category.Products.AreThereItems() == true)
            {
                foreach (Product_Category pc in category.Products)
                {
                    this.Products.Add(new BProduct(pc.Product, false));
                }
            }
        }

        internal void LoadImages(TrucksReserveEntities dc)
        {
            dc.ExcIfNull();
            if (this.ID < 1) { BTools.NewBException("this.ID < 1"); }

            this.Images = new List<BImage>();

            List<Gallery> images = dc.Gallery.Where(i => i.Type == (int)ImageType.Category && i.TypeID == this.ID).ToList();
            if (images.AreThereItems() == true)
            {
                this.Images = images.ConvertAll<BImage>(new Converter<Gallery, BImage>(BImage.ElementConverter));
                this.Images = this.Images.OrderByDescending(i => i.Main).ToList();
            }
        }

    }
}
